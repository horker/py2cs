using System;
using System.Linq;
using System.Collections;
using System.Collections.Generic;
using System.Threading;
using Horker.MXNet;
using Horker.MXNet.Compat;
using static Horker.MXNet.Base;
using static Horker.MXNet.Compat.Compat;
using static Horker.MXNet.Compat.Coercing;
using static Horker.MXNet.Compat.Array;
using static Horker.MXNet.MXNetCoercing;
using static Horker.MXNet.MXNetCompat;
using static Horker.MXNet.DType;
using NDArrayHandle = System.IntPtr;
using SymbolHandle = System.IntPtr;
using DisposableObject = Horker.MXNet.Interop.DisposableObject;
using _LIB = Horker.MXNet.Interop._LIB;
using MxInt = System.Int32;
using MxUint = System.Int32;
using MxInt64 = System.Int64;
using PySlice = Horker.MXNet.Compat.Slice;
using Tuple = System.Collections.ICollection;
using List = System.Collections.ICollection;
using _numpy = Horker.MXNet.Np;

namespace Horker.MXNet
{
    using Int = System.Int32;
    using List = System.Array;
    using static Helper;
    public static partial class Helper {}
    
    // Expr
    // ImportFrom
    // ImportFrom
    // Import
    // Import
    // ImportFrom
    // Import
    // ImportFrom
    // ImportFrom
    // ImportFrom
    // ImportFrom
    // ImportFrom
    // ImportFrom
    // ImportFrom
    // ImportFrom
    // ImportFrom
    // ImportFrom
    // ImportFrom
    // ImportFrom
    // ImportFrom
    // ImportFrom
    
    // Assignment of __all__
    
    public partial class Symbol : SymbolBase, IEnumerable<Symbol>
    {
        
        // Expr
        public static object __Slots__ = CoerceIntoObject(null);
        public static object __ArrayPriority__ = CoerceIntoObject(1000.0f);
        
        internal object __Repr__()
        {
            // Expr
            var name = this.Name;
            if (IsTrue((IsNone(name))))
            {
                name = ", ".Join(this.Select(i => i.Name).ToList());
                return ("<%s group [%s]>".PyFormat(ValueTuple.Create(this.GetType().Name, name)));
            }
            else
            {
                return ("<%s %s>".PyFormat(ValueTuple.Create(this.GetType().Name, name)));
            }
        }
        
        internal object __Iter__()
        {
            // Expr
            return Range(Len(this)).Select(i => this[i]);
        }
        
        internal object __Add__(object other)
        {
            // Expr
            throw new TypeError(("type %s not supported".PyFormat(Str(Type(other)))));
        }
        
        // Drop: __bool__
        public static object __Nonzero__ = CoerceIntoObject(__Bool__);
        
        // Drop: __iadd__
        
        internal object __Radd__(object other)
        {
            return this.__Add__(other);
        }
        
        internal object __Sub__(object other)
        {
            // Expr
            throw new TypeError(("type %s not supported".PyFormat(Str(Type(other)))));
        }
        
        // Drop: __isub__
        
        internal object __Rsub__(object other)
        {
            // Expr
            throw new TypeError(("type %s not supported".PyFormat(Str(Type(other)))));
        }
        
        internal object __Mul__(object other)
        {
            // Expr
            throw new TypeError(("type %s not supported".PyFormat(Str(Type(other)))));
        }
        
        // Drop: __imul__
        
        internal object __Rmul__(object other)
        {
            return this.__Mul__(other);
        }
        
        internal object __Div__(object other)
        {
            // Expr
            throw new TypeError(("type %s not supported".PyFormat(Str(Type(other)))));
        }
        
        internal object __Rdiv__(object other)
        {
            // Expr
            throw new TypeError(("type %s not supported".PyFormat(Str(Type(other)))));
        }
        
        internal object __Mod__(object other)
        {
            // Expr
            throw new TypeError(("type %s not supported".PyFormat(Str(Type(other)))));
        }
        
        internal object __Rmod__(object other)
        {
            // Expr
            throw new TypeError(("type %s not supported".PyFormat(Str(Type(other)))));
        }
        
        // Drop: __idiv__
        
        internal object __Truediv__(object other)
        {
            return this.__Div__(other);
        }
        
        internal object __Rtruediv__(object other)
        {
            return this.__Rdiv__(other);
        }
        
        // Drop: __itruediv__
        
        internal object __Pow__(object other)
        {
            // Expr
            throw new TypeError(("type %s not supported".PyFormat(Str(Type(other)))));
        }
        
        // Drop: __rpow__
        
        internal object __Neg__()
        {
            // Expr
            return this.__Mul__((-1.0f));
        }
        
        internal Symbol __Copy__()
        {
            return this.__Deepcopy__(null);
        }
        
        internal Symbol __Deepcopy__(object _ = null)
        {
            // Expr
            var handle = new SymbolHandle();
            CheckCall(_LIB.MXSymbolCopy(this.Handle, out handle));
            return new Symbol(handle);
        }
        
        internal object __Eq__(object other)
        {
            // Expr
            throw new TypeError(("type %s not supported".PyFormat(Str(Type(other)))));
        }
        
        internal object __Ne__(object other)
        {
            // Expr
            throw new TypeError(("type %s not supported".PyFormat(Str(Type(other)))));
        }
        
        internal object __Gt__(object other)
        {
            // Expr
            throw new TypeError(("type %s not supported".PyFormat(Str(Type(other)))));
        }
        
        internal object __Ge__(object other)
        {
            // Expr
            throw new TypeError(("type %s not supported".PyFormat(Str(Type(other)))));
        }
        
        internal object __Lt__(object other)
        {
            // Expr
            throw new TypeError(("type %s not supported".PyFormat(Str(Type(other)))));
        }
        
        internal object __Le__(object other)
        {
            // Expr
            throw new TypeError(("type %s not supported".PyFormat(Str(Type(other)))));
        }
        
        // Drop: __getstate__
        
        // Drop: __setstate__
        
        internal Symbol __Call__(SymbolList args)
        {
            // Expr
            var s = this.__Copy__();
            s._compose(args);
            return s;
        }
        
        internal void _compose(SymbolList args, string name = null)
        {
            string[] keys = null;
            var kwargs = new Dictionary<string, IntPtr>();
            // Expr
            name = name;
            if (IsTrue(name))
            {
                name = CStr(name);
            }
            if (IsTrue((IsTrue((Len(args) != 0)) && IsTrue((Len(kwargs) != 0)))))
            {
                throw new TypeError("compose only accept input Symbols                 either as positional or keyword arguments, not both");
            }
            foreach (var arg in args)
            {
                if (IsTrue((!IsTrue(Isinstance(arg, typeof(Symbol))))))
                {
                    throw new TypeError("Compose expect `Symbol` as arguments");
                }
            }
            foreach (var val in kwargs.Values())
            {
                if (IsTrue((!IsTrue(Isinstance(val, typeof(Symbol))))))
                {
                    throw new TypeError("Compose expect `Symbol` as arguments");
                }
            }
            var numArgs = BinOp.Add(Len(args), Len(kwargs));
            if (IsTrue((Len(kwargs) != 0)))
            {
                keys = CoerceIntoStringArray(CStrArray(kwargs.Keys()));
                args = CHandleArray(kwargs.Values());
            }
            else
            {
                keys = CoerceIntoStringArray(null);
                args = CHandleArray(args);
            }
            CheckCall(_LIB.MXSymbolCompose(this.Handle, name, numArgs, keys, args));
        }
        
        internal object __Getitem__(int index)
        {
            // Expr
            var outputCount = Len(this);
            if (IsTrue((index >= outputCount)))
            {
                throw new IndexError();
            }
            var handle = new SymbolHandle();
            CheckCall(_LIB.MXSymbolGetOutput(this.Handle, MxUint(index), out handle));
            return new Symbol(handle: handle);
        }
        
        internal object __Getitem__(PySlice index)
        {
            // Expr
            var outputCount = Len(this);
            var start = (IsTrue((IsNone(index.Start))) ? 0 : index.Start);
            var stop = (IsTrue((IsNone(index.Stop))) ? outputCount : index.Stop);
            var step = (IsTrue((IsNone(index.Step))) ? 1 : index.Step);
            return new Group(Range(start, stop, step).Select(i => this[i]).ToList());
        }
        
        internal object __Getitem__(string index)
        {
            // Expr
            var outputCount = Len(this);
            var outputNames = this.ListOutputs();
            var idx = CoerceIntoInt(null);
            foreach (var (i, name) in Enumerate(outputNames))
            {
                if (IsTrue((name == index)))
                {
                    if (IsTrue((!IsNone(idx))))
                    {
                        throw new ValueError(("There are multiple outputs with name \"%s\"".PyFormat(index)));
                    }
                    idx = CoerceIntoInt(i);
                }
            }
            if (IsTrue((IsNone(idx))))
            {
                throw new ValueError(("Cannot find output that matches name \"%s\"".PyFormat(index)));
            }
            var indexReassigned = idx;
            if (IsTrue((indexReassigned >= outputCount)))
            {
                throw new IndexError();
            }
            var handle = new SymbolHandle();
            CheckCall(_LIB.MXSymbolGetOutput(this.Handle, MxUint(indexReassigned), out handle));
            return new Symbol(handle: handle);
        }
        
        public string Name
        {
            get {
                // Expr
                var ret = CTypes.CCharP();
                var success = CTypes.CInt();
                CheckCall(_LIB.MXSymbolGetName(this.Handle, out ret, out success));
                if (IsTrue((success != 0)))
                {
                    return PyStr(ret);
                }
                else
                {
                    return null;
                }
            }
        }
        
        public string Attr(string key)
        {
            // Expr
            var ret = CTypes.CCharP();
            var success = CTypes.CInt();
            CheckCall(_LIB.MXSymbolGetAttr(this.Handle, CStr(key), out ret, out success));
            if (IsTrue((success != 0)))
            {
                return PyStr(ret);
            }
            else
            {
                return null;
            }
        }
        
        // Drop: list_attr
        
        // Drop: attr_dict
        
        internal void _setAttr(Dictionary<string, string> kwargs)
        {
            // Expr
            foreach (var (key, value) in kwargs.Items())
            {
                CheckCall(_LIB.MXSymbolSetAttr(this.Handle, CStr(key), CStr(Str(value))));
            }
        }
        
        public object GetInternals()
        {
            // Expr
            var handle = new SymbolHandle();
            CheckCall(_LIB.MXSymbolGetInternals(this.Handle, out handle));
            return new Symbol(handle: handle);
        }
        
        public object GetChildren()
        {
            // Expr
            var handle = new SymbolHandle();
            CheckCall(_LIB.MXSymbolGetChildren(this.Handle, out handle));
            var ret = new Symbol(handle: handle);
            if (IsTrue((Len(ret.ListOutputs()) == 0)))
            {
                return null;
            }
            return ret;
        }
        
        public object ListArguments()
        {
            // Expr
            var size = CTypes.CUint();
            var sarr = CTypes.POINTER(CTypes.CCharP)();
            CheckCall(_LIB.MXSymbolListArguments(this.Handle, out size, out sarr));
            return Range(size).Select(i => PyStr(sarr[i])).ToList();
        }
        
        public List<string> ListOutputs()
        {
            // Expr
            var size = CTypes.CUint();
            var sarr = CTypes.POINTER(CTypes.CCharP)();
            CheckCall(_LIB.MXSymbolListOutputs(this.Handle, out size, out sarr));
            return Range(size).Select(i => PyStr(sarr[i])).ToList();
        }
        
        internal int __Len__()
        {
            // Expr
            var outputCount = MxUint();
            CheckCall(_LIB.MXSymbolGetNumOutputs(this.Handle, out outputCount));
            return outputCount.Value;
        }
        
        public object ListAuxiliaryStates()
        {
            // Expr
            var size = CTypes.CUint();
            var sarr = CTypes.POINTER(CTypes.CCharP)();
            CheckCall(_LIB.MXSymbolListAuxiliaryStates(this.Handle, out size, out sarr));
            return Range(size).Select(i => PyStr(sarr[i])).ToList();
        }
        
        public object ListInputs()
        {
            // Expr
            var size = CTypes.CUint();
            var sarr = CTypes.POINTER(CTypes.CCharP)();
            CheckCall(_LIB.NNSymbolListInputNames(this.Handle, 0, out size, out sarr));
            return Range(size).Select(i => PyStr(sarr[i])).ToList();
        }
        
        public object InferType(object *args, object kwargs)
        {
            // Expr
        }
        
        public object InferTypePartial(object *args, object kwargs)
        {
            // Expr
            return this._inferTypeImpl(true, Args);
        }
        
        internal object _inferTypeImpl(object partial, object *args, object kwargs)
        {
            // Expr
            if (IsTrue((IsTrue((Len(Args) != 0)) && IsTrue((Len(kwargs) != 0)))))
            {
                throw new ValueError("Can only specify known argument                     types either by positional or kwargs way.");
            }
            var sdata = null;
            if (IsTrue((Len(Args) != 0)))
            {
                var keys = null.Cast<string>().ToArray();
                foreach (var s in Args)
                {
                    if (IsTrue((!IsNone(s))))
                    {
                        s = _numpy.DType(s).Type;
                        if (IsTrue((!_DTYPE_NP_TO_MX.Contains(s))))
                        {
                            throw new TypeError(BinOp.Add("Argument need to be one of ", Str(_DTYPE_NP_TO_MX)));
                        }
                        sdata.Append(_DTYPE_NP_TO_MX[s]);
                    }
                    else
                    {
                        sdata.Append((-1));
                    }
                }
            }
            else
            {
                var strKeys = null;
                foreach (var (k, v) in kwargs.Items())
                {
                    v = _numpy.DType(v).Type;
                    if (IsTrue((_DTYPE_NP_TO_MX.Contains(v))))
                    {
                        strKeys.Append(k);
                        sdata.Append(_DTYPE_NP_TO_MX[v]);
                    }
                }
                var keys = CStrArray(strKeys);
            }
            var argTypeSize = MxUint();
            var argTypeData = CTypes.POINTER(CTypes.CInt)();
            var outTypeSize = MxUint();
            var outTypeData = CTypes.POINTER(CTypes.CInt)();
            var auxTypeSize = MxUint();
            var auxTypeData = CTypes.POINTER(CTypes.CInt)();
            var complete = CTypes.CInt();
            if (IsTrue(partial))
            {
                var inferFunc = _LIB.MXSymbolInferTypePartial;
            }
            else
            {
                var inferFunc = _LIB.MXSymbolInferType;
            }
            CheckCall(InferFunc(this.Handle, MxUint(Len(sdata)), Keys, CArrayBuf(CTypes.CInt, Array("i", sdata)), out argTypeSize, out argTypeData, out outTypeSize, out outTypeData, out auxTypeSize, out auxTypeData, out complete));
            if (IsTrue((complete != 0)))
            {
                var argTypes = Range(argTypeSize.Value).Select(i => _DTYPE_MX_TO_NP[argTypeData[i]]).ToList();
                var outTypes = Range(outTypeSize.Value).Select(i => _DTYPE_MX_TO_NP[outTypeData[i]]).ToList();
                var auxTypes = Range(auxTypeSize.Value).Select(i => _DTYPE_MX_TO_NP[auxTypeData[i]]).ToList();
                return ValueTuple.Create(argTypes, outTypes, auxTypes);
            }
            else
            {
                return ValueTuple.Create(null, null, null);
            }
        }
        
        public object InferShape(object *args, object kwargs)
        {
            // Expr
        }
        
        public object InferShapePartial(object *args, object kwargs)
        {
            // Expr
            return this._inferShapeImpl(true, Args);
        }
        
        internal object _inferShapeImpl(object partial, object *args, object kwargs)
        {
            // Expr
            if (IsTrue((IsTrue((Len(Args) != 0)) && IsTrue((Len(kwargs) != 0)))))
            {
                throw new ValueError("Can only specify known argument                     shapes either by positional or kwargs way.");
            }
            var sdata = null;
            var indptr = new [] { 0 };
            if (IsTrue((Len(Args) != 0)))
            {
                var keys = null.Cast<string>().ToArray();
                foreach (var (i, s) in Enumerate(Args))
                {
                    if (IsTrue((!IsNone(s))))
                    {
                        if (IsTrue((!IsTrue(Isinstance(s, typeof(Tuple))))))
                        {
                            throw new TypeError(("Arguments need to be shapes (tuple), but argument %d is %s.".PyFormat(ValueTuple.Create(i, Type(s)))));
                        }
                        sdata.Extend(s);
                    }
                    indptr.Append(Len(sdata));
                }
            }
            else
            {
                var strKeys = null;
                foreach (var (k, v) in kwargs.Items())
                {
                    if (IsTrue((!IsTrue(Isinstance(v, typeof(Tuple))))))
                    {
                        throw new TypeError(("Arguments need to be shapes (tuple), but '%s' is %s.".PyFormat(ValueTuple.Create(k, Type(v)))));
                    }
                    strKeys.Append(k);
                    sdata.Extend(v);
                    indptr.Append(Len(sdata));
                }
                var keys = CStrArray(strKeys);
            }
            var argShapeSize = MxUint();
            var argShapeNdim = CTypes.POINTER(typeof(MxInt))();
            var argShapeData = CTypes.POINTER(CTypes.POINTER(typeof(MxInt)))();
            var outShapeSize = MxUint();
            var outShapeNdim = CTypes.POINTER(typeof(MxInt))();
            var outShapeData = CTypes.POINTER(CTypes.POINTER(typeof(MxInt)))();
            var auxShapeSize = MxUint();
            var auxShapeNdim = CTypes.POINTER(typeof(MxInt))();
            var auxShapeData = CTypes.POINTER(CTypes.POINTER(typeof(MxInt)))();
            var complete = CTypes.CInt();
            if (IsTrue(partial))
            {
                var inferFunc = _LIB.MXSymbolInferShapePartialEx;
            }
            else
            {
                var inferFunc = _LIB.MXSymbolInferShapeEx;
            }
            CheckCall(InferFunc(this.Handle, MxUint((Len(indptr) - 1)), Keys, CArrayBuf(typeof(MxUint), Array("I", indptr)), CArrayBuf(typeof(MxInt), Array("i", sdata)), out argShapeSize, out argShapeNdim, out argShapeData, out outShapeSize, out outShapeNdim, out outShapeData, out auxShapeSize, out auxShapeNdim, out auxShapeData, out complete));
            if (IsTrue((complete != 0)))
            {
                var argShapes = Range(argShapeSize.Value).Select(i => (IsTrue((argShapeNdim[i] >= 0)) ? Tuple(argShapeData[i].Slice(null, argShapeNdim[i], null)) : null)).ToList();
                var outShapes = Range(outShapeSize.Value).Select(i => (IsTrue((outShapeNdim[i] >= 0)) ? Tuple(outShapeData[i].Slice(null, outShapeNdim[i], null)) : null)).ToList();
                var auxShapes = Range(auxShapeSize.Value).Select(i => (IsTrue((auxShapeNdim[i] >= 0)) ? Tuple(auxShapeData[i].Slice(null, auxShapeNdim[i], null)) : null)).ToList();
                return ValueTuple.Create(argShapes, outShapes, auxShapes);
            }
            else
            {
                return ValueTuple.Create(null, null, null);
            }
        }
        
        public object DebugStr()
        {
            // Expr
            var debugStr = CTypes.CCharP();
            CheckCall(_LIB.MXSymbolPrint(this.Handle, out debugStr));
            return PyStr(debugStr);
        }
        
        public object Save(string fname, bool removeAmpCast = true)
        {
            // Expr
            if (IsTrue(removeAmpCast))
            {
                var handle = new SymbolHandle();
                CheckCall(_LIB.MXSymbolRemoveAmpCast(this.Handle, out handle));
                CheckCall(_LIB.MXSymbolSaveToFile(handle, CStr(fname)));
            }
            else
            {
                CheckCall(_LIB.MXSymbolSaveToFile(this.Handle, CStr(fname)));
            }
        }
        
        public object Tojson()
        {
            // Expr
            var jsonStr = CTypes.CCharP();
            CheckCall(_LIB.MXSymbolSaveToJSON(this.Handle, out jsonStr));
            return PyStr(jsonStr);
        }
        
        internal object _getNdarrayInputs(object argKey, object args, string argNames, object allowMissing)
        {
            // Expr
            var argHandles = null;
            var argArrays = null;
            throw new TypeError("Only accept list of NDArrays or dict of str to NDArray");
        }
        
        internal object _genAtomicSymbol()
        {
            var handle = new SymbolHandle();
            CheckCall(_LIB.MXGenAtomicSymbolFromSymbol(this.Handle, out handle));
            return new Symbol(handle);
        }
        
        public object SimpleBind(Context ctx, string gradReq = "write", object typeDict = null, object stypeDict = null, object group2ctx = null, string sharedArgNames = null, object sharedExec = null, object sharedBuffer = null, object kwargs)
        {
            // Expr
            var numProvidedArgTypes = 0;
            var providedArgTypeNames = CTypes.POINTER(CTypes.CCharP)();
            var providedArgTypeData = CTypes.POINTER(typeof(MxUint))();
            if (IsTrue((!IsNone(typeDict))))
            {
                providedArgTypeNames = null;
                providedArgTypeData = null;
                foreach (var (k, v) in typeDict.Items())
                {
                    v = _numpy.DType(v).Type;
                    if (IsTrue((_DTYPE_NP_TO_MX.Contains(v))))
                    {
                        providedArgTypeNames.Append(k);
                        providedArgTypeData.Append(_DTYPE_NP_TO_MX[v]);
                    }
                }
                numProvidedArgTypes = MxUint(Len(providedArgTypeNames));
                providedArgTypeNames = CStrArray(providedArgTypeNames);
                providedArgTypeData = CArrayBuf(CTypes.CInt, Array("i", providedArgTypeData));
            }
            var numProvidedArgStypes = 0;
            var providedArgStypeNames = CTypes.POINTER(CTypes.CCharP)();
            var providedArgStypeData = CTypes.POINTER(typeof(MxUint))();
            if (IsTrue((!IsNone(stypeDict))))
            {
                providedArgStypeNames = null;
                providedArgStypeData = null;
                foreach (var (k, v) in stypeDict.Items())
                {
                    if (IsTrue((_STORAGE_TYPE_STR_TO_ID.Contains(v))))
                    {
                        providedArgStypeNames.Append(k);
                        providedArgStypeData.Append(_STORAGE_TYPE_STR_TO_ID[v]);
                    }
                }
                numProvidedArgStypes = MxUint(Len(providedArgStypeNames));
                providedArgStypeNames = CStrArray(providedArgStypeNames);
                providedArgStypeData = CArrayBuf(CTypes.CInt, Array("i", providedArgStypeData));
            }
            var providedArgShapeData = null;
            var providedArgShapeIdx = new [] { 0 };
            var providedArgShapeNames = null;
            foreach (var (k, v) in kwargs.Items())
            {
                if (IsTrue(Isinstance(v, typeof(Tuple))))
                {
                    var local0 = (tuple)v;
                    providedArgShapeNames.Append(k);
                    providedArgShapeData.Extend(local0);
                    providedArgShapeIdx.Append(Len(providedArgShapeData));
                }
            }
            var providedReqTypeListLen = 0;
            var providedGradReqTypes = CTypes.POINTER(CTypes.CCharP)();
            var providedGradReqNames = CTypes.POINTER(CTypes.CCharP)();
            if (IsTrue((!IsNone(gradReq))))
            {
                providedReqTypeListLen = 0;
                providedGradReqTypes = new [] { gradReq };
                providedGradReqTypes = CStrArray(providedGradReqTypes);
            }
            var numCtxMapKeys = MxUint(0);
            var ctxMapKeys = CTypes.POINTER(CTypes.CCharP)();
            var ctxMapDevTypes = CTypes.POINTER(CTypes.CInt)();
            var ctxMapDevIds = CTypes.POINTER(CTypes.CInt)();
            if (IsTrue((!IsNone(group2ctx))))
            {
                ctxMapKeys = null;
                ctxMapDevTypes = null;
                ctxMapDevIds = null;
                foreach (var (key, val) in group2ctx.Items())
                {
                    ctxMapKeys.Append(key);
                    ctxMapDevTypes.Append(val.DeviceTypeid);
                    ctxMapDevIds.Append(val.DeviceId);
                }
                numCtxMapKeys = MxUint(Len(ctxMapKeys));
                ctxMapKeys = CStrArray(ctxMapKeys);
                ctxMapDevTypes = Array("i", ctxMapDevTypes).Cast<int>().ToArray();
                ctxMapDevIds = Array("i", ctxMapDevIds).Cast<int>().ToArray();
            }
            var sharedArgNameList = null;
            if (IsTrue((!IsNone(sharedArgNames))))
            {
                throw new ValueError("shared_arg_names in simple_bind must be a list or None");
            }
            if (IsTrue((IsNone(sharedBuffer))))
            {
                var sharedBufferLen = CTypes.CInt((-1));
                var sharedBufferNames = CTypes.POINTER(CTypes.CCharP)();
                var sharedBufferHandles = CTypes.POINTER(typeof(NDArrayHandle))();
            }
            else
            {
                throw new ValueError("shared_buffer in simple_bind must be dict or None");
            }
            var updatedSharedBufferNames = CTypes.POINTER(CTypes.CCharP)();
            var updatedSharedBufferHandles = CTypes.POINTER(typeof(NDArrayHandle))();
            var sharedExecHandle = (IsTrue((!IsNone(sharedExec))) ? sharedExec.Handle : new ExecutorHandle());
            var exeHandle = new ExecutorHandle();
            var numInArgs = CTypes.CUint();
            var inArgHandles = CTypes.POINTER(typeof(NDArrayHandle))();
            var argGradHandles = CTypes.POINTER(typeof(NDArrayHandle))();
            var numAuxStates = CTypes.CUint();
            var auxStateHandles = CTypes.POINTER(typeof(NDArrayHandle))();
            if (IsTrue((!IsNone(sharedBuffer))))
            {
                foreach (var i in Range(SharedBufferLen.Value))
                {
                    var k = PyStr(updatedSharedBufferNames[i]);
                    var v = new NDArray(new NDArrayHandle(updatedSharedBufferHandles[i]));
                    sharedBuffer[k] = v;
                }
            }
            var argArrays = Range(numInArgs).Select(i => _ndarrayCls(new NDArrayHandle(inArgHandles[i]))).ToList();
            var gradArrays = Range(numInArgs).Select(i => (IsTrue((!IsNone(argGradHandles[i]))) ? _ndarrayCls(new NDArrayHandle(argGradHandles[i])) : null)).ToList();
            var auxArrays = Range(numAuxStates).Select(i => _ndarrayCls(new NDArrayHandle(auxStateHandles[i]))).ToList();
            var executor = new Executor(exeHandle, this, ctx, gradReq, group2ctx);
            executor.ArgArrays = argArrays;
            executor.GradArrays = gradArrays;
            executor.AuxArrays = auxArrays;
            return executor;
        }
        
        public object Bind(Context ctx, object args, object argsGrad = null, string gradReq = "write", object auxStates = null, object group2ctx = null, object sharedExec = null)
        {
            // Expr
            var listedArguments = this.ListArguments();
            var (argsHandle, local0) = this._getNdarrayInputs("args", args, listedArguments, false);
            args = local0;
            if (IsTrue((IsNone(argsGrad))))
            {
                var argsGradHandle = BinOp.Mult(new [] { null }, Len(args)).Cast<NDArrayHandle>().ToArray();
            }
            else
            {
                var (argsGradHandle, local1) = this._getNdarrayInputs("args_grad", argsGrad, listedArguments, true);
                argsGrad = local1;
            }
            if (IsTrue((IsNone(auxStates))))
            {
                auxStates = null;
            }
            var (auxArgsHandle, local1) = this._getNdarrayInputs("aux_states", auxStates, this.ListAuxiliaryStates(), false);
            auxStates = local1;
            if (IsTrue((!_GRAD_REQ_MAP.Contains(gradReq))))
            {
                throw new ValueError(("grad_req must be in %s".PyFormat(Str(_GRAD_REQ_MAP))));
            }
            var reqsArray = CArrayBuf(typeof(MxUint), Array("I", BinOp.Mult(new [] { _GRAD_REQ_MAP[gradReq] }, Len(listedArguments))));
            var ctxMapKeys = null;
            var ctxMapDevTypes = null;
            var ctxMapDevIds = null;
            if (IsTrue(group2ctx))
            {
                foreach (var (key, val) in group2ctx.Items())
                {
                    ctxMapKeys.Append(key);
                    ctxMapDevTypes.Append(val.DeviceTypeid);
                    ctxMapDevIds.Append(val.DeviceId);
                }
            }
            var handle = new ExecutorHandle();
            var sharedHandle = (IsTrue((!IsNone(sharedExec))) ? sharedExec.Handle : new ExecutorHandle());
            CheckCall(_LIB.MXExecutorBindEX(this.Handle, CTypes.CInt(ctx.DeviceTypeid), CTypes.CInt(ctx.DeviceId), MxUint(Len(ctxMapKeys)), CStrArray(ctxMapKeys), CArrayBuf(CTypes.CInt, Array("i", ctxMapDevTypes)), CArrayBuf(CTypes.CInt, Array("i", ctxMapDevIds)), MxUint(Len(args)), argsHandle, ArgsGradHandle, reqsArray, MxUint(Len(auxStates)), auxArgsHandle, sharedHandle, out handle));
            var executor = new Executor(handle, this, ctx, gradReq, group2ctx);
            executor.ArgArrays = args;
            executor.GradArrays = argsGrad;
            executor.AuxArrays = auxStates;
            return executor;
        }
        
        public object Gradient(object wrt)
        {
            // Expr
            var handle = new SymbolHandle();
            var cWrt = CStrArray(wrt);
            CheckCall(_LIB.MXSymbolGrad(this.Handle, MxUint(Len(wrt)), cWrt, out handle));
            return new Symbol(handle);
        }
        
        public object Eval(Context ctx = null, object kwargs)
        {
            // Expr
            if (IsTrue((IsNone(ctx))))
            {
                ctx = CurrentContext();
            }
            return this.Bind(ctx, kwargs).Forward();
        }
        
        public object Reshape(object *args, object kwargs)
        {
            // Expr
            return Op.Reshape(this, Args);
        }
        
        public object ReshapeLike(object *args, object kwargs)
        {
            // Expr
            return Op.ReshapeLike(this, Args);
        }
        
        public string Astype(object *args, object kwargs)
        {
            // Expr
            return Op.Cast(this, Args);
        }
        
        public object ZerosLike(object *args, object kwargs)
        {
            // Expr
            return Op.ZerosLike(this, Args);
        }
        
        public object OnesLike(object *args, object kwargs)
        {
            // Expr
            return Op.OnesLike(this, Args);
        }
        
        public object BroadcastAxes(object *args, object kwargs)
        {
            // Expr
            return Op.BroadcastAxes(this, Args);
        }
        
        public object Repeat(object *args, object kwargs)
        {
            // Expr
            return Op.Repeat(this, Args);
        }
        
        public object Pad(object *args, object kwargs)
        {
            // Expr
            return Op.Pad(this, Args);
        }
        
        public object Swapaxes(object *args, object kwargs)
        {
            // Expr
            return Op.Swapaxes(this, Args);
        }
        
        public object Split(object *args, object kwargs)
        {
            // Expr
            return Op.Split(this, Args);
        }
        
        public object SplitV2(object *args, object kwargs)
        {
            // Expr
            return SplitV2(this, Args);
        }
        
        public object Slice(object *args, object kwargs)
        {
            // Expr
            return Op.Slice(this, Args);
        }
        
        public object SliceAxis(object *args, object kwargs)
        {
            // Expr
            return Op.SliceAxis(this, Args);
        }
        
        public object SliceLike(object *args, object kwargs)
        {
            // Expr
            return Op.SliceLike(this, Args);
        }
        
        public object Take(object *args, object kwargs)
        {
            // Expr
            return Op.Take(this, Args);
        }
        
        public object OneHot(object *args, object kwargs)
        {
            // Expr
            return Op.OneHot(this, Args);
        }
        
        public object Pick(object *args, object kwargs)
        {
            // Expr
            return Op.Pick(this, Args);
        }
        
        public object Sort(object *args, object kwargs)
        {
            // Expr
            return Op.Sort(this, Args);
        }
        
        public object Topk(object *args, object kwargs)
        {
            // Expr
            return Op.Topk(this, Args);
        }
        
        public object Argsort(object *args, object kwargs)
        {
            // Expr
            return Op.Argsort(this, Args);
        }
        
        public object Argmax(object *args, object kwargs)
        {
            // Expr
            return Op.Argmax(this, Args);
        }
        
        public object ArgmaxChannel(object *args, object kwargs)
        {
            // Expr
            return Op.ArgmaxChannel(this, Args);
        }
        
        public object Argmin(object *args, object kwargs)
        {
            // Expr
            return Op.Argmin(this, Args);
        }
        
        public object Clip(object *args, object kwargs)
        {
            // Expr
            return Op.Clip(this, Args);
        }
        
        public object Abs(object *args, object kwargs)
        {
            // Expr
            return Op.Abs(this, Args);
        }
        
        public object Sign(object *args, object kwargs)
        {
            // Expr
            return Op.Sign(this, Args);
        }
        
        public object Flatten(object *args, object kwargs)
        {
            // Expr
            return Op.Flatten(this, Args);
        }
        
        public object ShapeArray(object *args, object kwargs)
        {
            // Expr
            return Op.ShapeArray(this, Args);
        }
        
        public object SizeArray(object *args, object kwargs)
        {
            // Expr
            return Op.SizeArray(this, Args);
        }
        
        public object ExpandDims(object *args, object kwargs)
        {
            // Expr
            return Op.ExpandDims(this, Args);
        }
        
        public object BroadcastTo(object *args, object kwargs)
        {
            // Expr
            return Op.BroadcastTo(this, Args);
        }
        
        public object BroadcastLike(object *args, object kwargs)
        {
            // Expr
            return Op.BroadcastLike(this, Args);
        }
        
        public object Tile(object *args, object kwargs)
        {
            // Expr
            return Op.Tile(this, Args);
        }
        
        public object Transpose(object *args, object kwargs)
        {
            // Expr
            return Op.Transpose(this, Args);
        }
        
        public object Flip(object *args, object kwargs)
        {
            // Expr
            return Op.Flip(this, Args);
        }
        
        public object DepthToSpace(object *args, object kwargs)
        {
            // Expr
            return Op.DepthToSpace(this, Args);
        }
        
        public object SpaceToDepth(object *args, object kwargs)
        {
            // Expr
            return Op.SpaceToDepth(this, Args);
        }
        
        public object Diag(int k = 0, object kwargs)
        {
            // Expr
            return Op.Diag(this, k);
        }
        
        public object Sum(object *args, object kwargs)
        {
            // Expr
            return Op.Sum(this, Args);
        }
        
        public object Nansum(object *args, object kwargs)
        {
            // Expr
            return Op.Nansum(this, Args);
        }
        
        public object Prod(object *args, object kwargs)
        {
            // Expr
            return Op.Prod(this, Args);
        }
        
        public object Nanprod(object *args, object kwargs)
        {
            // Expr
            return Op.Nanprod(this, Args);
        }
        
        public object Mean(object *args, object kwargs)
        {
            // Expr
            return Op.Mean(this, Args);
        }
        
        public object Max(object *args, object kwargs)
        {
            // Expr
            return Op.Max(this, Args);
        }
        
        public object Min(object *args, object kwargs)
        {
            // Expr
            return Op.Min(this, Args);
        }
        
        public object Norm(object *args, object kwargs)
        {
            // Expr
            return Op.Norm(this, Args);
        }
        
        public object Round(object *args, object kwargs)
        {
            // Expr
            return Op.Round(this, Args);
        }
        
        public object Rint(object *args, object kwargs)
        {
            // Expr
            return Op.Rint(this, Args);
        }
        
        public object Fix(object *args, object kwargs)
        {
            // Expr
            return Op.Fix(this, Args);
        }
        
        public object Floor(object *args, object kwargs)
        {
            // Expr
            return Op.Floor(this, Args);
        }
        
        public object Ceil(object *args, object kwargs)
        {
            // Expr
            return Op.Ceil(this, Args);
        }
        
        public object Trunc(object *args, object kwargs)
        {
            // Expr
            return Op.Trunc(this, Args);
        }
        
        public object Sin(object *args, object kwargs)
        {
            // Expr
            return Op.Sin(this, Args);
        }
        
        public object Cos(object *args, object kwargs)
        {
            // Expr
            return Op.Cos(this, Args);
        }
        
        public object Tan(object *args, object kwargs)
        {
            // Expr
            return Op.Tan(this, Args);
        }
        
        public object Arcsin(object *args, object kwargs)
        {
            // Expr
            return Op.Arcsin(this, Args);
        }
        
        public object Arccos(object *args, object kwargs)
        {
            // Expr
            return Op.Arccos(this, Args);
        }
        
        public object Arctan(object *args, object kwargs)
        {
            // Expr
            return Op.Arctan(this, Args);
        }
        
        public object Degrees(object *args, object kwargs)
        {
            // Expr
            return Op.Degrees(this, Args);
        }
        
        public object Radians(object *args, object kwargs)
        {
            // Expr
            return Op.Radians(this, Args);
        }
        
        public object Sinh(object *args, object kwargs)
        {
            // Expr
            return Op.Sinh(this, Args);
        }
        
        public object Cosh(object *args, object kwargs)
        {
            // Expr
            return Op.Cosh(this, Args);
        }
        
        public object Tanh(object *args, object kwargs)
        {
            // Expr
            return Op.Tanh(this, Args);
        }
        
        public object Arcsinh(object *args, object kwargs)
        {
            // Expr
            return Op.Arcsinh(this, Args);
        }
        
        public object Arccosh(object *args, object kwargs)
        {
            // Expr
            return Op.Arccosh(this, Args);
        }
        
        public object Arctanh(object *args, object kwargs)
        {
            // Expr
            return Op.Arctanh(this, Args);
        }
        
        public object Exp(object *args, object kwargs)
        {
            // Expr
            return Op.Exp(this, Args);
        }
        
        public object Expm1(object *args, object kwargs)
        {
            // Expr
            return Op.Expm1(this, Args);
        }
        
        public object Log(object *args, object kwargs)
        {
            // Expr
            return Op.Log(this, Args);
        }
        
        public object Log10(object *args, object kwargs)
        {
            // Expr
            return Op.Log10(this, Args);
        }
        
        public object Log2(object *args, object kwargs)
        {
            // Expr
            return Op.Log2(this, Args);
        }
        
        public object Log1p(object *args, object kwargs)
        {
            // Expr
            return Op.Log1p(this, Args);
        }
        
        public object Sqrt(object *args, object kwargs)
        {
            // Expr
            return Op.Sqrt(this, Args);
        }
        
        public object Rsqrt(object *args, object kwargs)
        {
            // Expr
            return Op.Rsqrt(this, Args);
        }
        
        public object Cbrt(object *args, object kwargs)
        {
            // Expr
            return Op.Cbrt(this, Args);
        }
        
        public object Rcbrt(object *args, object kwargs)
        {
            // Expr
            return Op.Rcbrt(this, Args);
        }
        
        public object Square(object *args, object kwargs)
        {
            // Expr
            return Op.Square(this, Args);
        }
        
        public object Reciprocal(object *args, object kwargs)
        {
            // Expr
            return Op.Reciprocal(this, Args);
        }
        
        public object Relu(object *args, object kwargs)
        {
            // Expr
            return Op.Relu(this, Args);
        }
        
        public object Sigmoid(object *args, object kwargs)
        {
            // Expr
            return Op.Sigmoid(this, Args);
        }
        
        public object Softmax(object *args, object kwargs)
        {
            // Expr
            return Op.Softmax(this, Args);
        }
        
        public object LogSoftmax(object *args, object kwargs)
        {
            // Expr
            return Op.LogSoftmax(this, Args);
        }
        
        public object Softmin(object *args, object kwargs)
        {
            // Expr
            return Op.Softmin(this, Args);
        }
        
        public object Squeeze(object *args, object kwargs)
        {
            // Expr
            return Op.Squeeze(this, Args);
        }
        
        public object GetBackendSymbol(object backend)
        {
            // Expr
            var @out = new SymbolHandle();
            CheckCall(_LIB.MXGenBackendSubgraph(this.Handle, CStr(backend), out @out));
            return new Symbol(@out);
        }
        
        public object WaitToRead()
        {
            throw new NotImplementedForSymbol(this.WaitToRead, null);
        }
        
        public object Asnumpy()
        {
            throw new NotImplementedForSymbol(this.Asnumpy, null);
        }
        
        public object Asscalar()
        {
            throw new NotImplementedForSymbol(this.Asscalar, null);
        }
        
        public object Copy()
        {
            throw new NotImplementedForSymbol(this.Copy, null);
        }
        
        public object AsInContext()
        {
            throw new NotImplementedForSymbol(this.AsInContext, null);
        }
        
        public object Detach()
        {
            throw new NotImplementedForSymbol(this.Detach, null);
        }
        
        public object Backward()
        {
            throw new NotImplementedForSymbol(this.Backward, null);
        }
    }
    
    public static partial class Helper
    {
        public static object Var(string name, object attr = null, Shape shape = null, object lrMult = null, object wdMult = null, DType dtype = null, Initializer init = null, string stype = null, object kwargs)
        {
            // Expr
            var handle = new SymbolHandle();
            CheckCall(_LIB.MXSymbolCreateVariable(CStr(name), out handle));
            var ret = new Symbol(handle);
            if (IsTrue((!IsTrue(Hasattr(AttrScope._current, "value")))))
            {
                AttrScope._current.Value = new AttrScope();
            }
            attr = AttrScope._current.Value.Get(attr);
            attr = (IsTrue((IsNone(attr))) ? new System.Collections.Hashtable(){
            }
             : attr);
            if (IsTrue((!IsNone(shape))))
            {
                attr["__shape__"] = Str(shape);
            }
            if (IsTrue((!IsNone(lrMult))))
            {
                attr["__lr_mult__"] = Str(lrMult);
            }
            if (IsTrue((!IsNone(wdMult))))
            {
                attr["__wd_mult__"] = Str(wdMult);
            }
            if (IsTrue((!IsNone(dtype))))
            {
                attr["__dtype__"] = Str(_DTYPE_NP_TO_MX[_numpy.DType(dtype).Type]);
            }
            if (IsTrue((!IsNone(init))))
            {
                init = init.Dumps();
                attr["__init__"] = init;
            }
            if (IsTrue((!IsNone(stype))))
            {
                attr["__storage_type__"] = Str(_STORAGE_TYPE_STR_TO_ID[stype]);
            }
            foreach (var (k, v) in kwargs.Items())
            {
                if (IsTrue((IsTrue(k.Startswith("__")) && IsTrue(k.Endswith("__")))))
                {
                    attr[k] = Str(v);
                }
                else
                {
                    throw new ValueError(("Attribute name=%s is not supported. Additional attributes must start and end with double underscores, e.g, __yourattr__".PyFormat(k)));
                }
            }
            ret._setAttr(on: attr);
            return ret;
        }
    }
    
    public static partial class Helper
    {
        public static object Variable = CoerceIntoObject(Var);
    }
    
    public static partial class Helper
    {
        public static object Group(object symbols)
        {
            // Expr
            if (IsTrue((IsTrue((!IsTrue(symbols))) || IsTrue(Any(symbols.Select(sym => (!IsTrue(Isinstance(sym, typeof(Symbol))))))))))
            {
                throw new TypeError("Expected a list of symbols as input");
            }
            var handle = new SymbolHandle();
            CheckCall(_LIB.MXSymbolCreateGroup(MxUint(Len(symbols)), CHandleArray(symbols), out handle));
            return new Symbol(handle);
        }
    }
    
    public static partial class Helper
    {
        public static object Load(string fname)
        {
            // Expr
            var handle = new SymbolHandle();
            CheckCall(_LIB.MXSymbolCreateFromFile(CStr(fname), out handle));
            return new Symbol(handle);
        }
    }
    
    public static partial class Helper
    {
        public static object LoadJson(object jsonStr)
        {
            // Expr
            throw new TypeError("fname required to be string");
        }
    }
    
    public static partial class Helper
    {
        public static object Pow(object base, object exp)
        {
            // Expr
            if (IsTrue((IsTrue(Isinstance(@base, typeof(Symbol))) && IsTrue(Isinstance(exp, typeof(Symbol))))))
            {
                return _internal.Power(@base, exp);
            }
            if (IsTrue((IsTrue(Isinstance(@base, typeof(Symbol))) && IsTrue(Isinstance(exp, Number)))))
            {
                return _internal.PowerScalar(@base, scalar: exp);
            }
            if (IsTrue((IsTrue(Isinstance(@base, Number)) && IsTrue(Isinstance(exp, typeof(Symbol))))))
            {
                return _internal.RPowerScalar(exp, scalar: @base);
            }
            if (IsTrue((IsTrue(Isinstance(@base, Number)) && IsTrue(Isinstance(exp, Number)))))
            {
                return System.FMath.Pow(@base, exp);
            }
            else
            {
                throw new TypeError(("types (%s, %s) not supported".PyFormat(ValueTuple.Create(Str(Type(@base)), Str(Type(exp))))));
            }
        }
    }
    
    public static partial class Helper
    {
        public static object Power(object base, object exp)
        {
            // Expr
            return Pow(@base, exp);
        }
    }
    
    public static partial class Helper
    {
        public static object Maximum(object left, object right)
        {
            // Expr
            if (IsTrue((IsTrue(Isinstance(left, typeof(Symbol))) && IsTrue(Isinstance(right, typeof(Symbol))))))
            {
                return _internal.Maximum(left, right);
            }
            if (IsTrue((IsTrue(Isinstance(left, typeof(Symbol))) && IsTrue(Isinstance(right, Number)))))
            {
                return _internal.MaximumScalar(left, scalar: right);
            }
            if (IsTrue((IsTrue(Isinstance(left, Number)) && IsTrue(Isinstance(right, typeof(Symbol))))))
            {
                return _internal.MaximumScalar(right, scalar: left);
            }
            if (IsTrue((IsTrue(Isinstance(left, Number)) && IsTrue(Isinstance(right, Number)))))
            {
                return (IsTrue((left > right)) ? left : right);
            }
            else
            {
                throw new TypeError(("types (%s, %s) not supported".PyFormat(ValueTuple.Create(Str(Type(left)), Str(Type(right))))));
            }
        }
    }
    
    public static partial class Helper
    {
        public static object Minimum(object left, object right)
        {
            // Expr
            if (IsTrue((IsTrue(Isinstance(left, typeof(Symbol))) && IsTrue(Isinstance(right, typeof(Symbol))))))
            {
                return _internal.Minimum(left, right);
            }
            if (IsTrue((IsTrue(Isinstance(left, typeof(Symbol))) && IsTrue(Isinstance(right, Number)))))
            {
                return _internal.MinimumScalar(left, scalar: right);
            }
            if (IsTrue((IsTrue(Isinstance(left, Number)) && IsTrue(Isinstance(right, typeof(Symbol))))))
            {
                return _internal.MinimumScalar(right, scalar: left);
            }
            if (IsTrue((IsTrue(Isinstance(left, Number)) && IsTrue(Isinstance(right, Number)))))
            {
                return (IsTrue((left < right)) ? left : right);
            }
            else
            {
                throw new TypeError(("types (%s, %s) not supported".PyFormat(ValueTuple.Create(Str(Type(left)), Str(Type(right))))));
            }
        }
    }
    
    public static partial class Helper
    {
        public static object Hypot(object left, object right)
        {
            // Expr
            if (IsTrue((IsTrue(Isinstance(left, typeof(Symbol))) && IsTrue(Isinstance(right, typeof(Symbol))))))
            {
                return _internal.Hypot(left, right);
            }
            if (IsTrue((IsTrue(Isinstance(left, typeof(Symbol))) && IsTrue(Isinstance(right, Number)))))
            {
                return _internal.HypotScalar(left, scalar: right);
            }
            if (IsTrue((IsTrue(Isinstance(left, Number)) && IsTrue(Isinstance(right, typeof(Symbol))))))
            {
                return _internal.HypotScalar(right, scalar: left);
            }
            if (IsTrue((IsTrue(Isinstance(left, Number)) && IsTrue(Isinstance(right, Number)))))
            {
                return _numpy.Hypot(left, right);
            }
            else
            {
                throw new TypeError(("types (%s, %s) not supported".PyFormat(ValueTuple.Create(Str(Type(left)), Str(Type(right))))));
            }
        }
    }
    
    public static partial class Helper
    {
        public static object Eye(object N, int M = 0, int k = 0, DType dtype = null, object kwargs)
        {
            // Expr
            if (IsTrue((IsNone(dtype))))
            {
                dtype = _numpy.Float32;
            }
            return _internal._eye(N, M, k, dtype: dtype);
        }
    }
    
    public static partial class Helper
    {
        public static object Zeros(Shape shape, DType dtype = null, object kwargs)
        {
            // Expr
            if (IsTrue((IsNone(dtype))))
            {
                dtype = _numpy.Float32;
            }
            return _internal._zeros(shape: shape, dtype: dtype);
        }
    }
    
    public static partial class Helper
    {
        public static object Ones(Shape shape, DType dtype = null, object kwargs)
        {
            // Expr
            if (IsTrue((IsNone(dtype))))
            {
                dtype = _numpy.Float32;
            }
            return _internal._ones(shape: shape, dtype: dtype);
        }
    }
    
    public static partial class Helper
    {
        public static object Full(Shape shape, object val, DType dtype = null, object kwargs)
        {
            // Expr
            if (IsTrue((IsNone(dtype))))
            {
                dtype = _numpy.Float32;
            }
            return _internal._full(shape: shape, dtype: dtype, value: Float(val));
        }
    }
    
    public static partial class Helper
    {
        public static object Arange(object start, object stop = null, float step = 1.0f, int repeat = 1, bool inferRange = false, string name = null, DType dtype = null)
        {
            // Expr
            if (IsTrue((IsNone(dtype))))
            {
                dtype = _numpy.Float32;
            }
            return _internal._arange(start: start, stop: stop, step: step, repeat: repeat, inferRange: inferRange, name: name, dtype: dtype);
        }
    }
    
    public static partial class Helper
    {
        public static object Linspace(object start, object stop, object num, bool endpoint = true, string name = null, DType dtype = null)
        {
            // Expr
            if (IsTrue((IsNone(dtype))))
            {
                dtype = _numpy.Float32;
            }
            return _internal._linspace(start: start, stop: stop, num: num, endpoint: endpoint, name: name, dtype: dtype);
        }
    }
    
    public static partial class Helper
    {
        public static object Histogram(object a, int bins = 10, object range = null, object kwargs)
        {
            // Expr
            if (IsTrue((IsNone(range))))
            {
                throw new ValueError("null range is not supported in symbol mode");
            }
            return _internal._histogram(data: a, binCnt: bins, range: range);
        }
    }
    
    public static partial class Helper
    {
        public static object SplitV2(object ary, object indicesOrSections, int axis = 0, bool squeezeAxis = false)
        {
            // Expr
            var indices = null;
            var sections = 0;
            throw new ValueError("indices_or_sections must either int or tuple of ints");
        }
    }
    // Expr
}
