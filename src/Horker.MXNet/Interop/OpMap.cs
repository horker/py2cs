﻿/*****************************************************************************
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
using System.Collections.Generic;
using System.Runtime.InteropServices;
using static Horker.MXNet.Base;
using AtomicSymbolCreator = System.IntPtr;
using OpHandle = System.IntPtr;

namespace Horker.MXNet.Interop
{
    /// <summary>
    ///     OpMap instance holds a map of all the symbol creators so we can get symbol creators by name. This is used
    ///     internally by Symbol and Operator. This class cannot be inherited.
    /// </summary>
    public sealed class OpMap
    {
        #region Constructors

        public OpMap()
        {
            CheckCall(_LIB.MXSymbolListAtomicSymbolCreators(out var numSymbolCreators, out var symbolCreators));

            _SymbolCreators = new Dictionary<string, AtomicSymbolCreator>((int) numSymbolCreators);

            var symbolCreatorsArray = InteropHelper.ToPointerArray(symbolCreators, numSymbolCreators);
            for (var i = 0; i < numSymbolCreators; i++)
            {
                var return_type = AtomicSymbolCreator.Zero;
                CheckCall(_LIB.MXSymbolGetAtomicSymbolInfo(symbolCreatorsArray[i],
                    out var name,
                    out var description,
                    out var numArgs,
                    out var argNames,
                    out var argTypeInfos,
                    out var argDescriptions,
                    out var nameBuilder,
                    ref return_type));
                var str = Marshal.PtrToStringAnsi(name);
                _SymbolCreators.Add(str, symbolCreatorsArray[i]);
            }

            CheckCall(_LIB.NNListAllOpNames(out var numOps, out var opNames));

            _OpHandles = new Dictionary<string, AtomicSymbolCreator>((int) numOps);

            var opNamesArray = InteropHelper.ToPointerArray(opNames, numOps);
            for (var i = 0; i < numOps; i++)
            {
                CheckCall(_LIB.NNGetOpHandle(opNamesArray[i], out var handle));
                var str = Marshal.PtrToStringAnsi(opNamesArray[i]);
                _OpHandles.Add(str, handle);
            }
        }

        #endregion

        #region Fields

        private readonly Dictionary<string, AtomicSymbolCreator> _SymbolCreators;

        private readonly Dictionary<string, OpHandle> _OpHandles;

        #endregion

        #region Methods

        public OpHandle GetOpHandle(string name)
        {
            return _OpHandles[name];
        }

        public AtomicSymbolCreator GetSymbolCreator(string name)
        {
            if (!_SymbolCreators.TryGetValue(name, out var handle))
                return GetOpHandle(name);

            return handle;
        }

        #endregion
    }
}