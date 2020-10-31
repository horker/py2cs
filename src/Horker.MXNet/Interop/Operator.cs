/*****************************************************************************
   Copyright 2018 The MxNet.Sharp Authors. All Rights Reserved.

   Licensed under the Apache License, Version 2.0 (the "License");
   you may not use this file except in compliance with the License.
   You may obtain a copy of the License at

       http://www.apache.org/licenses/LICENSE-2.0

   Unless required by applicable law or agreed to in writing, software
   distributed under the License is distributed on an "AS IS" BASIS,
   WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
   See the License for the specific language governing permissions and
   limitations under the License.
******************************************************************************/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using static Horker.MXNet.Base; // CheckCall
using SymbolHandle = System.IntPtr;
using NDArrayHandle = System.IntPtr;
using mx_uint = System.UInt32;

namespace Horker.MXNet.Interop
{
    public sealed class Operator : DisposableObject
    {
        #region Fields

        private static readonly OpMap _opMap = new OpMap();

        private readonly Dictionary<string, string> _params = new Dictionary<string, string>();

        private readonly List<SymbolHandle> _inputSymbols = new List<SymbolHandle>();

        private readonly List<NDArrayHandle> _inputNDArrays = new List<NDArrayHandle>();

        private readonly List<string> _inputKeys = new List<string>();

        private readonly List<string> _argNames = new List<string>();

        private readonly SymbolHandle _handle;

        #endregion

        #region Constructors

        public Operator(SymbolHandle handle)
        {
            _handle = handle;
        }

        public Operator(string operatorName)
        {
            _name = operatorName;
            _handle = _opMap.GetSymbolCreator(operatorName);

            var return_type = SymbolHandle.Zero;
            CheckCall(_LIB.MXSymbolGetAtomicSymbolInfo(_handle,
                out var name,
                out var description,
                out var numArgs,
                out var argNames,
                out var argTypeInfos,
                out var argDescriptions,
                out var keyVarNumArgs,
                ref return_type));

            var argNamesArray = InteropHelper.ToPointerArray(argNames, numArgs);
            for (var i = 0; i < numArgs; ++i)
            {
                var pArgName = argNamesArray[i];
                _argNames.Add(Marshal.PtrToStringAnsi(pArgName));
            }
        }

        #endregion

        #region Properties

        public SymbolHandle Handle => _handle;

        private readonly string _name;

        public string Name
        {
            get
            {
                ThrowIfDisposed();
                return _name;
            }
        }

        #endregion

        #region Methods

        public Symbol CreateSymbol(string name = "")
        {
//            if (_InputKeys.Count > 0)
//                CheckCall(_InputKeys.Count, _InputSymbols.Count);

            var pname = name == "" ? null : name;

            var keys = _params.Keys.ToArray();
            var paramKeys = new string[keys.Length];
            var paramValues = new string[keys.Length];
            for (var index = 0; index < keys.Length; index++)
            {
                var key = keys[index];
                paramKeys[index] = key;
                paramValues[index] = _params[key];
            }

            var inputKeys = _inputKeys.Count != 0 ? _inputKeys.ToArray() : null;

            CheckCall(_LIB.MXSymbolCreateAtomicSymbol(_handle,
                (uint)paramKeys.Length,
                paramKeys,
                paramValues,
                out var symbolHandle));

            CheckCall(_LIB.MXSymbolCompose(symbolHandle,
                pname,
                (uint)_inputSymbols.Count,
                inputKeys,
                _inputSymbols.ToArray()));

            return new Symbol(symbolHandle);
        }

        public NDArray Invoke()
        {
            var output = new NDArray();
            Invoke(output);
            return output;
        }

        public void Invoke(NDArray output)
        {
            if (output == null)
                throw new ArgumentNullException(nameof(output));

            var outputs = new NDArrayList(output);
            Invoke(outputs);
        }

        public NDArrayList Invoke(NDArrayList outputs)
        {
            var paramKeys = new List<string>();
            var paramValues = new List<string>();

            foreach (var data in _params)
            {
                paramKeys.Add(data.Key);
                paramValues.Add(data.Value);
            }

            var numInputs = _inputNDArrays.Count;
            var numOutputs = outputs.Count;

            var outputHandles = outputs.Select(s => s.Handle).ToArray();
            var outputsReceiver = IntPtr.Zero;
            GCHandle? gcHandle = null;
            try
            {
                if (outputs.Count > 0)
                {
                    gcHandle = GCHandle.Alloc(outputHandles, GCHandleType.Pinned);
                    outputsReceiver = gcHandle.Value.AddrOfPinnedObject();
                }

                NDArrayHandle[] outputsReceivers = { outputsReceiver };

                CheckCall(_LIB.MXImperativeInvoke(_handle, numInputs, _inputNDArrays.ToArray(), ref numOutputs,
                    ref outputsReceiver,
                    paramKeys.Count, paramKeys.ToArray(), paramValues.ToArray()));

                if (outputs.Count > 0)
                {
                    gcHandle?.Free();
                    return outputs;
                }

                outputHandles = new NDArrayHandle[numOutputs];

                Marshal.Copy(outputsReceiver, outputHandles, 0, numOutputs);

                foreach (var outputHandle in outputHandles) outputs.Add(new NDArray(outputHandle));

                gcHandle?.Free();
            }
            catch(Exception ex)
            {
                throw ex;
            }
            finally
            {
                gcHandle?.Free();
            }

            return outputs;
        }

        public void PushInput(Symbol symbol)
        {
            if (symbol == null)
                throw new ArgumentNullException(nameof(symbol));

            _inputSymbols.Add(symbol.Handle);
        }

        public Operator PushInput(NDArray ndarray)
        {
            if (ndarray == null)
                throw new ArgumentNullException(nameof(ndarray));

            _inputNDArrays.Add(ndarray.Handle);
            return this;
        }

        public Operator Set(params object[] args)
        {
            for (var i = 0; i < args.Length; i++)
            {
                var arg = args[i];
                if (arg is Symbol)
                    SetParam(i, (Symbol) arg);
                else if (arg is NDArray)
                    SetParam(i, (NDArray) arg);
                else if (arg is IEnumerable<Symbol>)
                    SetParam(i, (IEnumerable<Symbol>) arg);
                else
                    SetParam(i, arg);
            }

            return this;
        }

        public Operator SetInput(string name, Symbol symbol)
        {
            if (symbol == null)
                return this;

            _inputKeys.Add(name);
            _inputSymbols.Add(symbol.Handle);
            return this;
        }

        public Operator SetInput(SymbolList symbols)
        {
            foreach (var item in symbols) _inputSymbols.Add(item.Handle);

            return this;
        }

        public Operator SetInput(string name, NDArray ndarray)
        {
            if (ndarray == null)
                return this;

            _inputKeys.Add(name);
            _inputNDArrays.Add(ndarray.Handle);
            return this;
        }

        public Operator SetInput(NDArray ndarray)
        {
            _inputNDArrays.Add(ndarray.Handle);

            return this;
        }

        public Operator SetInput(NDArrayList ndlist)
        {
            foreach (var item in ndlist.Handles) _inputNDArrays.Add(item);

            return this;
        }

        public Operator SetParam(string key, object value)
        {
            if (value == null) return this;

            _params[key] = value.ToValueString();
            return this;
        }

        public Operator SetParam(string key, float[] value)
        {
            if (value == null) return this;

            _params[key] = value.ToValueString();
            return this;
        }

        public Operator SetParam(int pos, NDArray val)
        {
            _inputNDArrays.Add(val.Handle);
            return this;
        }

        public Operator SetParam(int pos, Symbol val)
        {
            _inputSymbols.Add(val.Handle);
            return this;
        }

        public Operator SetParam(int pos, IEnumerable<Symbol> val)
        {
            _inputSymbols.AddRange(val.Select(s => s.Handle));
            return this;
        }

        public Operator SetParam(int pos, object val)
        {
            _params[_argNames[pos]] = val.ToString();
            return this;
        }

        #region Overrides

        protected override void DisposeUnmanaged()
        {
            base.DisposeUnmanaged();
            _LIB.MXSymbolFree(_handle);
        }

        #endregion

        #endregion
    }
}