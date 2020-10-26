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
    // ImportFrom
    // Import
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
    
    // Assignment of __all__
    
    public static partial class Helper
    {
        public static int _STORAGE_TYPE_UNDEFINED = CoerceIntoInt((-1));
    }
    
    public static partial class Helper
    {
        public static int _STORAGE_TYPE_DEFAULT = CoerceIntoInt(0);
    }
    
    public static partial class Helper
    {
        public static int _STORAGE_TYPE_ROW_SPARSE = CoerceIntoInt(1);
    }
    
    public static partial class Helper
    {
        public static int _STORAGE_TYPE_CSR = CoerceIntoInt(2);
    }
    
    public static partial class Helper
    {
        public static Dictionary<DType, int> _DTYPE_NP_TO_MX = CoerceIntoDictionary<DType, int>(new Dictionary<DType, int>{
            { null, (-1) },
            { Np.Float32, 0 },
            { Np.Float64, 1 },
            { Np.Float16, 2 },
            { Np.UInt8, 3 },
            { Np.Int32, 4 },
            { Np.Int8, 5 },
            { Np.Int64, 6 },
        }
        );
    }
    
    public static partial class Helper
    {
        public static Dictionary<int, DType> _DTYPE_MX_TO_NP = CoerceIntoDictionary<int, DType>(new Dictionary<int, DType>{
            { (-1), null },
            { 0, Np.Float32 },
            { 1, Np.Float64 },
            { 2, Np.Float16 },
            { 3, Np.UInt8 },
            { 4, Np.Int32 },
            { 5, Np.Int8 },
            { 6, Np.Int64 },
        }
        );
    }
    
    public static partial class Helper
    {
        public static Dictionary<string, int> _STORAGE_TYPE_STR_TO_ID = CoerceIntoDictionary<string, int>(new Dictionary<string, int>{
            { "undefined", _STORAGE_TYPE_UNDEFINED },
            { "default", _STORAGE_TYPE_DEFAULT },
            { "row_sparse", _STORAGE_TYPE_ROW_SPARSE },
            { "csr", _STORAGE_TYPE_CSR },
        }
        );
    }
    
    public static partial class Helper
    {
        public static Dictionary<int, string> _STORAGE_TYPE_ID_TO_STR = CoerceIntoDictionary<int, string>(new Dictionary<int, string>{
            { _STORAGE_TYPE_UNDEFINED, "undefined" },
            { _STORAGE_TYPE_DEFAULT, "default" },
            { _STORAGE_TYPE_ROW_SPARSE, "row_sparse" },
            { _STORAGE_TYPE_CSR, "csr" },
        }
        );
    }
    
    public static partial class Helper
    {
        public static Dictionary<string, int> _GRAD_REQ_MAP = CoerceIntoDictionary<string, int>(new Dictionary<string, int>{
            { "null", 0 },
            { "write", 1 },
            { "add", 3 },
        }
        );
    }
    
    public static partial class Helper
    {
        public static int _NDARRAY_UNSUPPORTED_INDEXING = CoerceIntoInt((-1));
    }
    
    public static partial class Helper
    {
        public static int _NDARRAY_BASIC_INDEXING = CoerceIntoInt(0);
    }
    
    public static partial class Helper
    {
        public static int _NDARRAY_ADVANCED_INDEXING = CoerceIntoInt(1);
    }
    
    public static partial class Helper
    {
        internal static NDArrayHandle _newEmptyHandle()
        {
            // Expr
            var hdl = new NDArrayHandle();
            CheckCall(_LIB.MXNDArrayCreateNone(out hdl));
            return hdl;
        }
    }
    
    public static partial class Helper
    {
        internal static NDArrayHandle _newAllocHandle(Shape shape, Context ctx, bool delayAlloc, DType dtype = default)
        {
            // Expr
            var hdl = new NDArrayHandle();
            CheckCall(_LIB.MXNDArrayCreateEx(CArrayBuf(typeof(MxUint), NativeArray("I", shape)), MxUint(Len(shape)), CTypes.CInt(ctx.DeviceTypeid), CTypes.CInt(ctx.DeviceId), CTypes.CInt(Int(delayAlloc)), CTypes.CInt(Int(_DTYPE_NP_TO_MX[Np.DType(dtype).Type])), out hdl));
            return hdl;
        }
    }
    
    public static partial class Helper
    {
        internal static NDArrayHandle _newFromSharedMem(int sharedPid, int sharedId, Shape shape, DType dtype)
        {
            var hdl = new NDArrayHandle();
            CheckCall(_LIB.MXNDArrayCreateFromSharedMemEx(CTypes.CInt(sharedPid), CTypes.CInt(sharedId), CArray(typeof(MxInt), shape), MxInt(Len(shape)), CTypes.CInt(Int(_DTYPE_NP_TO_MX[Np.DType(dtype).Type])), out hdl));
            return hdl;
        }
    }
    
    public static partial class Helper
    {
        public static void Waitall()
        {
            // Expr
            CheckCall(_LIB.MXNDArrayWaitAll());
        }
    }
    
    public static partial class Helper
    {
        internal static int _storageType(NDArrayHandle handle)
        {
            var storageType = CTypes.CInt(0);
            CheckCall(_LIB.MXNDArrayGetStorageType(handle, out storageType));
            return storageType;
        }
    }
    
    public partial class NDArray : NDArrayBase
    {
        
        // Expr
        public static object __Slots__ = CoerceIntoObject(null);
        public static object __ArrayPriority__ = CoerceIntoObject(1000.0);
        public static object _tvmTcode = CoerceIntoObject(19);
        
        // Drop: _tvm_handle
        
        internal object __Repr__()
        {
            // Expr
            var shapeInfo = "x".Join(this.Shape.Select(x => ("%d".PyFormat(x))).ToList());
            return ("\n%s\n<%s %s @%s>".PyFormat(ValueTuple.Create(Str(this.Asnumpy()), this.GetType().Name, shapeInfo, this.Context)));
        }
        
        // Drop: __reduce__
        
        internal object __ToSharedMem__()
        {
            var sharedPid = CTypes.CInt();
            var sharedId = CTypes.CInt();
            CheckCall(_LIB.MXNDArrayGetSharedMemHandle(this.Handle, out sharedPid, out sharedId));
            return ValueTuple.Create(sharedPid, sharedId, this.Shape, this.DType);
        }
        
        internal object __Add__(object other)
        {
            // Expr
            return Add(this, other);
        }
        
        internal object __Iadd__(object other)
        {
            // Expr
            if (IsTrue((!IsTrue(this.Writable))))
            {
                throw new ValueError("trying to add to a readonly NDArray");
            }
            throw new TypeError(("type %s not supported".PyFormat(Str(Type(other)))));
        }
        
        internal object __Radd__(object other)
        {
            return this.__Add__(other);
        }
        
        internal object __Sub__(object other)
        {
            // Expr
            return Subtract(this, other);
        }
        
        internal object __Isub__(object other)
        {
            // Expr
            if (IsTrue((!IsTrue(this.Writable))))
            {
                throw new ValueError("trying to subtract from a readonly NDArray");
            }
            throw new TypeError(("type %s not supported".PyFormat(Str(Type(other)))));
        }
        
        internal object __Rsub__(object other)
        {
            // Expr
            return Subtract(other, this);
        }
        
        internal object __Mul__(object other)
        {
            // Expr
            return Multiply(this, other);
        }
        
        internal object __Neg__()
        {
            // Expr
            return _internal._mulScalar(this, (-1.0));
        }
        
        internal object __Imul__(object other)
        {
            // Expr
            if (IsTrue((!IsTrue(this.Writable))))
            {
                throw new ValueError("trying to multiply to a readonly NDArray");
            }
            throw new TypeError(("type %s not supported".PyFormat(Str(Type(other)))));
        }
        
        internal object __Rmul__(object other)
        {
            return this.__Mul__(other);
        }
        
        internal object __Div__(object other)
        {
            // Expr
            return Divide(this, other);
        }
        
        internal object __Rdiv__(object other)
        {
            // Expr
            return Divide(other, this);
        }
        
        internal object __Idiv__(object other)
        {
            // Expr
            if (IsTrue((!IsTrue(this.Writable))))
            {
                throw new ValueError("trying to divide from a readonly NDArray");
            }
            throw new TypeError(("type %s not supported".PyFormat(Str(Type(other)))));
        }
        
        internal object __Truediv__(object other)
        {
            return Divide(this, other);
        }
        
        internal object __Rtruediv__(object other)
        {
            return Divide(other, this);
        }
        
        internal object __Itruediv__(object other)
        {
            return this.__Idiv__(other);
        }
        
        internal object __Mod__(object other)
        {
            // Expr
            return Modulo(this, other);
        }
        
        internal object __Rmod__(object other)
        {
            // Expr
            return Modulo(other, this);
        }
        
        internal object __Imod__(object other)
        {
            // Expr
            if (IsTrue((!IsTrue(this.Writable))))
            {
                throw new ValueError("trying to take modulo from a readonly NDArray");
            }
            throw new TypeError(("type %s not supported".PyFormat(Str(Type(other)))));
        }
        
        internal object __Pow__(object other)
        {
            // Expr
            return Power(this, other);
        }
        
        internal object __Rpow__(object other)
        {
            // Expr
            return Power(other, this);
        }
        
        internal object __Eq__(object other)
        {
            // Expr
            return Equal(this, other);
        }
        
        internal object __Hash__()
        {
            // Expr
            return (Id(this) / 16);
        }
        
        internal object __Ne__(object other)
        {
            // Expr
            return NotEqual(this, other);
        }
        
        internal object __Gt__(object other)
        {
            // Expr
            return Greater(this, other);
        }
        
        internal object __Ge__(object other)
        {
            // Expr
            return GreaterEqual(this, other);
        }
        
        internal object __Lt__(object other)
        {
            // Expr
            return Lesser(this, other);
        }
        
        internal object __Le__(object other)
        {
            // Expr
            return LesserEqual(this, other);
        }
        
        internal object __Bool__()
        {
            var numElements = Reduce(Operator.Mul, this.Shape, 1);
            if (IsTrue((numElements == 0)))
            {
                return false;
            }
            else
            {
                if (IsTrue((numElements == 1)))
                {
                    return Bool(this.Asscalar());
                }
                else
                {
                    throw new ValueError("The truth value of an NDArray with multiple elements is ambiguous.");
                }
            }
        }
        public static object __Nonzero__ = CoerceIntoObject(__Bool__);
        
        internal object __Len__()
        {
            // Expr
            return this.Shape.Item1;
        }
        
        // Drop: __getstate__
        
        // Drop: __setstate__
        
        internal object __Setitem__(object key, object value)
        {
            // Expr
            var indexingDispatchCode = _getIndexingDispatchCode(key);
            if (IsTrue((indexingDispatchCode == _NDARRAY_BASIC_INDEXING)))
            {
                this._setNdBasicIndexing(key, value);
            }
            else
            {
                if (IsTrue((indexingDispatchCode == _NDARRAY_ADVANCED_INDEXING)))
                {
                    this._setNdAdvancedIndexing(key, value);
                }
                else
                {
                    throw new ValueError(("Indexing NDArray with index=%s and type=%s is not supported".PyFormat(ValueTuple.Create(Str(key), Str(Type(key))))));
                }
            }
        }
        
        internal object __Getitem__(NDArray key)
        {
            // Expr
            var indexingDispatchCode = _getIndexingDispatchCode(key);
            if (IsTrue((indexingDispatchCode == _NDARRAY_BASIC_INDEXING)))
            {
                return this._getNdBasicIndexing(key);
            }
            else
            {
                if (IsTrue((indexingDispatchCode == _NDARRAY_ADVANCED_INDEXING)))
                {
                    return this._getNdAdvancedIndexing(key);
                }
                else
                {
                    throw new ValueError(("Indexing NDArray with index=%s and type=%s is not supported".PyFormat(ValueTuple.Create(Str(key), Str(Type(key))))));
                }
            }
        }
        
        // Drop: _get_index_nd
        
        internal object _prepareValueNd(object value, object vshape)
        {
            // Expr
            if (IsTrue((ValueNd.Shape != vshape)))
            {
                var valueNd = ValueNd.BroadcastTo(vshape);
            }
            return ValueNd;
        }
        
        internal object _setNdBasicIndexing(object key, object value)
        {
            // Expr
            var shape = this.Shape;
            Assert(IsTrue(Isinstance(key, typeof(Tuple))), "Isinstance(key, typeof(Tuple))");
            Assert(IsTrue((Len(key) <= Len(shape))), "(Len(key) <= Len(shape))");
            var begin = null;
            var end = null;
            var steps = null;
            var oshape = null;
            var vshape = null;
            foreach (var (i, sliceI) in Enumerate(key))
            {
                var dimSize = 1;
                if (IsTrue(Isinstance(sliceI, typeof(PySlice))))
                {
                    var local0 = (py_slice)sliceI;
                    begin.Append(local0.Start);
                    end.Append(local0.Stop);
                    steps.Append(local0.Step);
                    var (start, stop, step) = _getIndexRange(local0.Start, local0.Stop, shape[i], local0.Step);
                    dimSize = _getDimSize(start, stop, step);
                    vshape.Append(dimSize);
                }
                else
                {
                    if (IsTrue(Isinstance(sliceI, typeof(IntegerTypes))))
                    {
                        var local0 = (integer_types)sliceI;
                        begin.Append(local0);
                        end.Append((IsTrue((local0 != (-1))) ? BinOp.Add(local0, 1) : this.Shape[i]));
                        steps.Append(1);
                    }
                    else
                    {
                        throw new ValueError(("basic indexing does not support index=%s of type=%s".PyFormat(ValueTuple.Create(Str(sliceI), Str(Type(sliceI))))));
                    }
                }
                oshape.Append(dimSize);
            }
            oshape.Extend(shape.Slice(Len(key), null, null));
            vshape.Extend(shape.Slice(Len(key), null, null));
            if (IsTrue((Len(vshape) == 0)))
            {
                vshape.Append(1);
            }
            oshape = Tuple(oshape);
            vshape = Tuple(vshape);
            var valueNd = this._prepareValueNd(value, vshape);
            if (IsTrue((vshape != oshape)))
            {
                valueNd = valueNd.Reshape(oshape);
            }
            _internal._sliceAssign(this, valueNd, begin, end, steps, @out: this);
        }
        
        internal object _setNdAdvancedIndexing(object key, object value)
        {
            // Expr
            var indices = this._getIndexNd(key);
            var vshape = _getOshapeOfGatherNdOp(this.Shape, indices.Shape);
            var valueNd = this._prepareValueNd(value, vshape);
            _internal._scatterSetNd(lhs: this, rhs: valueNd, indices: indices, shape: this.Shape, @out: this);
        }
        
        internal NDArray _getNdBasicIndexing(int key)
        {
            // Expr
            var shape = this.Shape;
            if (IsTrue((key > (shape.Item1 - 1))))
            {
                throw new IndexError("index {} is out of bounds for axis 0 with size {}".Format(key, shape.Item1));
            }
            return this._at(key);
        }
        
        internal NDArray _getNdBasicIndexing(IEnumerable<int> key)
        {
            // Expr
            var shape = this.Shape;
            Assert(IsTrue((Len(key) != 0)), "(Len(key) != 0)");
            var begin = CoerceIntoList<int>(null);
            var end = CoerceIntoList<int>(null);
            var step = CoerceIntoList<int>(null);
            var keptAxes = CoerceIntoList<int>(null);
            var i = (-1);
            foreach (var (i, sliceI) in Enumerate(key))
            {
                begin.Append(sliceI);
                end.Append((IsTrue((sliceI != (-1))) ? BinOp.Add(sliceI, 1) : this.Shape[i]));
                step.Append(1);
            }
            keptAxes.Extend(Range(BinOp.Add(i, 1), Len(shape)));
            var slicedNd = Op.Slice(this, begin, end, step);
            if (IsTrue((Len(keptAxes) == Len(shape))))
            {
                return slicedNd;
            }
            var oshape = null;
            var slicedShape = slicedNd.Shape;
            foreach (var axis in keptAxes)
            {
                oshape.Append(slicedShape[axis]);
            }
            if (IsTrue((Len(oshape) == 0)))
            {
                oshape.Append(1);
            }
            oshape = Tuple(oshape);
            Assert(IsTrue((Np.Prod(oshape) == Np.Prod(slicedShape))), "(Np.Prod(oshape) == Np.Prod(slicedShape))");
            return slicedNd.Reshape(oshape);
        }
        
        internal NDArray _getNdBasicIndexing(IEnumerable<PySlice> key)
        {
            // Expr
            var shape = this.Shape;
            throw new ValueError(("index=%s must be a slice, or an ineger, or a tuple of slices and integers to use basic indexing, received type=%s".PyFormat(ValueTuple.Create(Str(key), Str(Type(key))))));
        }
        
        internal object _getNdAdvancedIndexing(object key)
        {
            // Expr
            return Op.GatherNd(this, this._getIndexNd(key));
        }
        
        internal object _syncCopyfrom(object sourceArray)
        {
            // Expr
            if (IsTrue((!IsTrue(Isinstance(sourceArray, Np.NDArray)))))
            {
            }
            sourceArray = Np.Asarray(sourceArray, dtype: this.DType, order: "C");
            if (IsTrue((sourceArray.Shape != this.Shape)))
            {
                throw new ValueError(("Shape inconsistent: expected %s vs got %s".PyFormat(ValueTuple.Create(Str(sourceArray.Shape), Str(this.Shape)))));
            }
            CheckCall(_LIB.MXNDArraySyncCopyFromCPU(this.Handle, sourceArray.CTypes.DataAs(CTypes.CVoidP), CTypes.CSizeT(sourceArray.Size)));
        }
        
        internal NDArray _slice(int start, int stop)
        {
            // Expr
            var handle = new NDArrayHandle();
            var (local0, local1, _) = _getIndexRange(start, stop, this.Shape.Item1);
            start = local0;
            stop = local1;
            CheckCall(_LIB.MXNDArraySlice(this.Handle, MxUint(start), MxUint(stop), out handle));
            return new NDArray(handle: handle, writable: this.Writable);
        }
        
        internal NDArray _at(int idx)
        {
            // Expr
            var handle = new NDArrayHandle();
            if (IsTrue((idx < 0)))
            {
                var length = this.Shape.Item1;
                idx = BinOp.Add(idx, length);
                if (IsTrue((idx < 0)))
                {
                    throw new IndexError(("index %d is out of bounds for axis 0 with size %d".PyFormat(ValueTuple.Create((idx - length), length))));
                }
            }
            CheckCall(_LIB.MXNDArrayAt(this.Handle, MxUint(idx), out handle));
            return new NDArray(handle: handle, writable: this.Writable);
        }
        
        public NDArray Reshape(Shape shape, bool reverse)
        {
            var kwargs = new string[0];
            // Expr
            if (IsTrue((IsTrue((Len(shape) == 1)) && IsTrue(Isinstance(shape.Item1, ValueTuple.Create(typeof(List), typeof(Tuple)))))))
            {
                shape = shape.Item1;
            }
            else
            {
                if (IsTrue((!IsTrue(shape))))
                {
                    shape = shape;
                    Assert(IsTrue(shape), "shape");
                }
            }
            if (IsTrue((!IsTrue(All(kwargs.Select(k => (new [] { "shape", "reverse" }.Contains(k))))))))
            {
                throw new TypeError("Got unknown keywords in reshape: {}. Accepted keyword arguments are 'shape' and 'reverse'.".Format(", ".Join(kwargs.Where(k => (!new [] { "shape", "reverse" }.Contains(k))).Select(k => k).ToList())));
            }
            reverse = reverse;
            var handle = new NDArrayHandle();
            CheckCall(_LIB.MXNDArrayReshape64(this.Handle, Len(shape), CArray(CTypes.CInt64, shape), reverse, out handle));
            return new NDArray(handle: handle, writable: this.Writable);
        }
        
        public object ReshapeLike(object *args)
        {
            var kwargs = new Dictionary<string, string>();
            // Expr
            return Op.ReshapeLike(this, Args);
        }
        
        public object ZerosLike(object *args)
        {
            var kwargs = new Dictionary<string, string>();
            // Expr
            return Op.ZerosLike(this, Args);
        }
        
        public object OnesLike(object *args)
        {
            var kwargs = new Dictionary<string, string>();
            // Expr
            return Op.OnesLike(this, Args);
        }
        
        public object BroadcastAxes(object *args)
        {
            var kwargs = new Dictionary<string, string>();
            // Expr
            return Op.BroadcastAxes(this, Args);
        }
        
        public object Repeat(object *args)
        {
            var kwargs = new Dictionary<string, string>();
            // Expr
            return Op.Repeat(this, Args);
        }
        
        public object Pad(object *args)
        {
            var kwargs = new Dictionary<string, string>();
            // Expr
            return Op.Pad(this, Args);
        }
        
        public object Swapaxes(object *args)
        {
            var kwargs = new Dictionary<string, string>();
            // Expr
            return Op.Swapaxes(this, Args);
        }
        
        public object Split(object *args)
        {
            var kwargs = new Dictionary<string, string>();
            // Expr
            return Op.Split(this, Args);
        }
        
        public object SplitV2(object *args)
        {
            var kwargs = new Dictionary<string, string>();
            // Expr
            return SplitV2(this, Args);
        }
        
        public object Slice(object *args)
        {
            var kwargs = new Dictionary<string, string>();
            // Expr
            return Op.Slice(this, Args);
        }
        
        public object SliceAxis(object *args)
        {
            var kwargs = new Dictionary<string, string>();
            // Expr
            return Op.SliceAxis(this, Args);
        }
        
        public object SliceLike(object *args)
        {
            var kwargs = new Dictionary<string, string>();
            // Expr
            return Op.SliceLike(this, Args);
        }
        
        public object Take(object *args)
        {
            var kwargs = new Dictionary<string, string>();
            // Expr
            return Op.Take(this, Args);
        }
        
        public object OneHot(object *args)
        {
            var kwargs = new Dictionary<string, string>();
            // Expr
            return Op.OneHot(this, Args);
        }
        
        public object Pick(object *args)
        {
            var kwargs = new Dictionary<string, string>();
            // Expr
            return Op.Pick(this, Args);
        }
        
        public object Sort(object *args)
        {
            var kwargs = new Dictionary<string, string>();
            // Expr
            return Op.Sort(this, Args);
        }
        
        public object Topk(object *args)
        {
            var kwargs = new Dictionary<string, string>();
            // Expr
            return Op.Topk(this, Args);
        }
        
        public object Argsort(object *args)
        {
            var kwargs = new Dictionary<string, string>();
            // Expr
            return Op.Argsort(this, Args);
        }
        
        public object Argmax(object *args)
        {
            var kwargs = new Dictionary<string, string>();
            // Expr
            return Op.Argmax(this, Args);
        }
        
        public object ArgmaxChannel(object *args)
        {
            var kwargs = new Dictionary<string, string>();
            // Expr
            return Op.ArgmaxChannel(this, Args);
        }
        
        public object Argmin(object *args)
        {
            var kwargs = new Dictionary<string, string>();
            // Expr
            return Op.Argmin(this, Args);
        }
        
        public object Clip(object *args)
        {
            var kwargs = new Dictionary<string, string>();
            // Expr
            return Op.Clip(this, Args);
        }
        
        public object Abs(object *args)
        {
            var kwargs = new Dictionary<string, string>();
            // Expr
            return Op.Abs(this, Args);
        }
        
        public object Sign(object *args)
        {
            var kwargs = new Dictionary<string, string>();
            // Expr
            return Op.Sign(this, Args);
        }
        
        public object Flatten(object *args)
        {
            var kwargs = new Dictionary<string, string>();
            // Expr
            return Op.Flatten(this, Args);
        }
        
        public object ShapeArray(object *args)
        {
            var kwargs = new Dictionary<string, string>();
            // Expr
            return Op.ShapeArray(this, Args);
        }
        
        public object SizeArray(object *args)
        {
            var kwargs = new Dictionary<string, string>();
            // Expr
            return Op.SizeArray(this, Args);
        }
        
        public object ExpandDims(object *args)
        {
            var kwargs = new Dictionary<string, string>();
            // Expr
            return Op.ExpandDims(this, Args);
        }
        
        public object Tile(object *args)
        {
            var kwargs = new Dictionary<string, string>();
            // Expr
            return Op.Tile(this, Args);
        }
        
        public object Transpose(object *args)
        {
            var kwargs = new Dictionary<string, string>();
            // Expr
            return Op.Transpose(this, Args);
        }
        
        public object Flip(object *args)
        {
            var kwargs = new Dictionary<string, string>();
            // Expr
            return Op.Flip(this, Args);
        }
        
        public object DepthToSpace(object *args)
        {
            var kwargs = new Dictionary<string, string>();
            // Expr
            return Op.DepthToSpace(this, Args);
        }
        
        public object SpaceToDepth(object *args)
        {
            var kwargs = new Dictionary<string, string>();
            // Expr
            return Op.SpaceToDepth(this, Args);
        }
        
        public object Diag(int k = 0)
        {
            var kwargs = new Dictionary<string, string>();
            // Expr
            return Op.Diag(this, k);
        }
        
        public object Sum(object *args)
        {
            var kwargs = new Dictionary<string, string>();
            // Expr
            return Op.Sum(this, Args);
        }
        
        public object Nansum(object *args)
        {
            var kwargs = new Dictionary<string, string>();
            // Expr
            return Op.Nansum(this, Args);
        }
        
        public object Prod(object *args)
        {
            var kwargs = new Dictionary<string, string>();
            // Expr
            return Op.Prod(this, Args);
        }
        
        public object Nanprod(object *args)
        {
            var kwargs = new Dictionary<string, string>();
            // Expr
            return Op.Nanprod(this, Args);
        }
        
        public object Mean(object *args)
        {
            var kwargs = new Dictionary<string, string>();
            // Expr
            return Op.Mean(this, Args);
        }
        
        public object Max(object *args)
        {
            var kwargs = new Dictionary<string, string>();
            // Expr
            return Op.Max(this, Args);
        }
        
        public object Min(object *args)
        {
            var kwargs = new Dictionary<string, string>();
            // Expr
            return Op.Min(this, Args);
        }
        
        public object Norm(object *args)
        {
            var kwargs = new Dictionary<string, string>();
            // Expr
            return Op.Norm(this, Args);
        }
        
        public object Round(object *args)
        {
            var kwargs = new Dictionary<string, string>();
            // Expr
            return Op.Round(this, Args);
        }
        
        public object Rint(object *args)
        {
            var kwargs = new Dictionary<string, string>();
            // Expr
            return Op.Rint(this, Args);
        }
        
        public object Fix(object *args)
        {
            var kwargs = new Dictionary<string, string>();
            // Expr
            return Op.Fix(this, Args);
        }
        
        public object Floor(object *args)
        {
            var kwargs = new Dictionary<string, string>();
            // Expr
            return Op.Floor(this, Args);
        }
        
        public object Ceil(object *args)
        {
            var kwargs = new Dictionary<string, string>();
            // Expr
            return Op.Ceil(this, Args);
        }
        
        public object Trunc(object *args)
        {
            var kwargs = new Dictionary<string, string>();
            // Expr
            return Op.Trunc(this, Args);
        }
        
        public object Sin(object *args)
        {
            var kwargs = new Dictionary<string, string>();
            // Expr
            return Op.Sin(this, Args);
        }
        
        public object Cos(object *args)
        {
            var kwargs = new Dictionary<string, string>();
            // Expr
            return Op.Cos(this, Args);
        }
        
        public object Tan(object *args)
        {
            var kwargs = new Dictionary<string, string>();
            // Expr
            return Op.Tan(this, Args);
        }
        
        public object Arcsin(object *args)
        {
            var kwargs = new Dictionary<string, string>();
            // Expr
            return Op.Arcsin(this, Args);
        }
        
        public object Arccos(object *args)
        {
            var kwargs = new Dictionary<string, string>();
            // Expr
            return Op.Arccos(this, Args);
        }
        
        public object Arctan(object *args)
        {
            var kwargs = new Dictionary<string, string>();
            // Expr
            return Op.Arctan(this, Args);
        }
        
        public object Degrees(object *args)
        {
            var kwargs = new Dictionary<string, string>();
            // Expr
            return Op.Degrees(this, Args);
        }
        
        public object Radians(object *args)
        {
            var kwargs = new Dictionary<string, string>();
            // Expr
            return Op.Radians(this, Args);
        }
        
        public object Sinh(object *args)
        {
            var kwargs = new Dictionary<string, string>();
            // Expr
            return Op.Sinh(this, Args);
        }
        
        public object Cosh(object *args)
        {
            var kwargs = new Dictionary<string, string>();
            // Expr
            return Op.Cosh(this, Args);
        }
        
        public object Tanh(object *args)
        {
            var kwargs = new Dictionary<string, string>();
            // Expr
            return Op.Tanh(this, Args);
        }
        
        public object Arcsinh(object *args)
        {
            var kwargs = new Dictionary<string, string>();
            // Expr
            return Op.Arcsinh(this, Args);
        }
        
        public object Arccosh(object *args)
        {
            var kwargs = new Dictionary<string, string>();
            // Expr
            return Op.Arccosh(this, Args);
        }
        
        public object Arctanh(object *args)
        {
            var kwargs = new Dictionary<string, string>();
            // Expr
            return Op.Arctanh(this, Args);
        }
        
        public object Exp(object *args)
        {
            var kwargs = new Dictionary<string, string>();
            // Expr
            return Op.Exp(this, Args);
        }
        
        public object Expm1(object *args)
        {
            var kwargs = new Dictionary<string, string>();
            // Expr
            return Op.Expm1(this, Args);
        }
        
        public object Log(object *args)
        {
            var kwargs = new Dictionary<string, string>();
            // Expr
            return Op.Log(this, Args);
        }
        
        public object Log10(object *args)
        {
            var kwargs = new Dictionary<string, string>();
            // Expr
            return Op.Log10(this, Args);
        }
        
        public object Log2(object *args)
        {
            var kwargs = new Dictionary<string, string>();
            // Expr
            return Op.Log2(this, Args);
        }
        
        public object Log1p(object *args)
        {
            var kwargs = new Dictionary<string, string>();
            // Expr
            return Op.Log1p(this, Args);
        }
        
        public object Sqrt(object *args)
        {
            var kwargs = new Dictionary<string, string>();
            // Expr
            return Op.Sqrt(this, Args);
        }
        
        public object Rsqrt(object *args)
        {
            var kwargs = new Dictionary<string, string>();
            // Expr
            return Op.Rsqrt(this, Args);
        }
        
        public object Cbrt(object *args)
        {
            var kwargs = new Dictionary<string, string>();
            // Expr
            return Op.Cbrt(this, Args);
        }
        
        public object Rcbrt(object *args)
        {
            var kwargs = new Dictionary<string, string>();
            // Expr
            return Op.Rcbrt(this, Args);
        }
        
        public object Square(object *args)
        {
            var kwargs = new Dictionary<string, string>();
            // Expr
            return Op.Square(this, Args);
        }
        
        public object Reciprocal(object *args)
        {
            var kwargs = new Dictionary<string, string>();
            // Expr
            return Op.Reciprocal(this, Args);
        }
        
        public object Relu(object *args)
        {
            var kwargs = new Dictionary<string, string>();
            // Expr
            return Op.Relu(this, Args);
        }
        
        public object Sigmoid(object *args)
        {
            var kwargs = new Dictionary<string, string>();
            // Expr
            return Op.Sigmoid(this, Args);
        }
        
        public object Softmax(object *args)
        {
            var kwargs = new Dictionary<string, string>();
            // Expr
            return Op.Softmax(this, Args);
        }
        
        public object LogSoftmax(object *args)
        {
            var kwargs = new Dictionary<string, string>();
            // Expr
            return Op.LogSoftmax(this, Args);
        }
        
        public object Softmin(object *args)
        {
            var kwargs = new Dictionary<string, string>();
            // Expr
            return Op.Softmin(this, Args);
        }
        
        public object Squeeze(object *args)
        {
            var kwargs = new Dictionary<string, string>();
            // Expr
            return Op.Squeeze(this, Args);
        }
        
        public object BroadcastTo(Shape shape)
        {
            // Expr
            var curShape = this.Shape;
            var errStr = "operands could not be broadcast together with remapped shapes[original->remapped]: {} and requested shape {}".Format(curShape, shape);
            if (IsTrue((Len(shape) < Len(curShape))))
            {
                throw new ValueError(errStr);
            }
            curShape = BinOp.Add(BinOp.Mult(ValueTuple.Create(1), (Len(shape) - Len(curShape))), curShape);
            var curShapeArr = Np.Array(curShape);
            var broadcastingAxes = Np.Nonzero((curShapeArr != Np.Array(shape)));
            if (IsTrue((curShapeArr[broadcastingAxes] != 1).Any()))
            {
                throw new ValueError(errStr);
            }
            if (IsTrue((curShape != this.Shape)))
            {
                return Op.BroadcastTo(this.Reshape(curShape), shape: shape);
            }
            else
            {
                return Op.BroadcastTo(this, shape: Tuple(shape));
            }
        }
        
        public object BroadcastLike(object other)
        {
            // Expr
            return this.BroadcastTo(other.Shape);
        }
        
        public object WaitToRead()
        {
            // Expr
            CheckCall(_LIB.MXNDArrayWaitToRead(this.Handle));
        }
        
        public object Ndim
        {
            get {
                // Expr
                return Len(this.Shape);
            }
        }
        
        public Shape Shape
        {
            get {
                // Expr
                var ndim = MxInt();
                var pdata = CTypes.POINTER(typeof(MxInt))();
                CheckCall(_LIB.MXNDArrayGetShapeEx(this.Handle, out ndim, out pdata));
                if (IsTrue((ndim.Value == (-1))))
                {
                    return null;
                }
                else
                {
                    return Tuple(pdata.Slice(null, ndim.Value, null));
                }
            }
        }
        
        public object Size
        {
            get {
                // Expr
                var size = 1;
                foreach (var i in this.Shape)
                {
                    size = BinOp.Mult(size, i);
                }
                return size;
            }
        }
        
        public Context Context
        {
            get {
                // Expr
                var devTypeid = CTypes.CInt();
                var devId = CTypes.CInt();
                CheckCall(_LIB.MXNDArrayGetContext(this.Handle, out devTypeid, out devId));
                return new Context(Context.Devtype2str[devTypeid], devId);
            }
        }
        
        public DType DType
        {
            get {
                // Expr
                var mxDtype = CTypes.CInt();
                CheckCall(_LIB.MXNDArrayGetDType(this.Handle, out mxDtype));
                return _DTYPE_MX_TO_NP[mxDtype];
            }
        }
        
        public string SType
        {
            get {
                // Expr
                return _STORAGE_TYPE_ID_TO_STR[_storageType(this.Handle)];
            }
        }
        
        public NDArray T
        {
            get {
                // Expr
                if (IsTrue((Len(this.Shape) < 2)))
                {
                    return this;
                }
                return Op.Transpose(this);
            }
        }
        
        public object _freshGrad(object self)
        {
            // Expr
            var @out = CTypes.CInt();
            CheckCall(_LIB.MXNDArrayGetGradState(this.Handle, out @out));
            return @out;
        }
        
        internal void Set_freshGrad(object state)
        {
            CheckCall(_LIB.MXNDArraySetGradState(this.Handle, CTypes.CInt(state)));
        }
        
        public object Asnumpy()
        {
            // Expr
            var data = Np.Empty(this.Shape, dtype: this.DType);
            CheckCall(_LIB.MXNDArraySyncCopyToCPU(this.Handle, data.CTypes.DataAs(CTypes.CVoidP), CTypes.CSizeT(data.Size)));
            return data;
        }
        
        public object Asscalar()
        {
            // Expr
            if (IsTrue((this.Shape != ValueTuple.Create(1))))
            {
                throw new ValueError("The current array is not a scalar");
            }
            return this.Asnumpy().Item1;
        }
        
        public string Astype(DType dtype, bool copy = true)
        {
            // Expr
            if (IsTrue((IsTrue((!IsTrue(copy))) && IsTrue((Np.DType(dtype) == this.DType)))))
            {
                return this;
            }
            var res = Empty(this.Shape, ctx: this.Context, dtype: dtype);
            this.Copyto(res);
            return res;
        }
        
        public object Copyto(object other)
        {
            // Expr
            throw new TypeError(BinOp.Add("copyto does not support type ", Str(Type(other))));
        }
        
        public object Copy()
        {
            // Expr
            return this.Copyto(this.Context);
        }
        
        public object AsInContext(object context)
        {
            // Expr
            if (IsTrue((this.Context == context)))
            {
                return this;
            }
            return this.Copyto(context);
        }
        
        public object AttachGrad(string gradReq = "write", string stype = null)
        {
            // Expr
            // ImportFrom
            if (IsTrue((!IsNone(stype))))
            {
                var grad = _zeros(this.Shape, stype: stype);
            }
            else
            {
                var grad = Op.ZerosLike(this);
            }
            gradReq = _GRAD_REQ_MAP[gradReq];
            CheckCall(_LIB.MXAutogradMarkVariables(1, CTypes.Pointer(this.Handle), CTypes.Pointer(MxUint(gradReq)), CTypes.Pointer(Grad.Handle)));
        }
        
        public object Grad
        {
            get {
                // Expr
                // ImportFrom
                var hdl = new NDArrayHandle();
                CheckCall(_LIB.MXNDArrayGetGrad(this.Handle, out hdl));
                if (IsTrue((IsNone(hdl.Value))))
                {
                    return null;
                }
                return _ndarrayCls(hdl);
            }
        }
        
        public object Detach()
        {
            // Expr
            // ImportFrom
            var hdl = new NDArrayHandle();
            CheckCall(_LIB.MXNDArrayDetach(this.Handle, out hdl));
            return _ndarrayCls(hdl);
        }
        
        public object Backward(NDArray outGrad = null, bool retainGraph = false, bool trainMode = true)
        {
            NDArrayHandle[] ogradHandles = null;
            // Expr
            if (IsTrue((IsNone(outGrad))))
            {
                ogradHandles = CoerceIntoNDArrayHandleArray(new [] { new NDArrayHandle(0) });
            }
            else
            {
                ogradHandles = CoerceIntoNDArrayHandleArray(new [] { outGrad.Handle });
            }
            CheckCall(_LIB.MXAutogradBackwardEx(1, CHandleArray(new [] { this }), CArray(typeof(NDArrayHandle), ogradHandles), 0, CTypes.CVoidP(0), CTypes.CInt(retainGraph), CTypes.CInt(0), CTypes.CInt(trainMode), CTypes.CVoidP(0), CTypes.CVoidP(0)));
        }
        
        public string Tostype(string stype)
        {
            // Expr
            return Op.CastStorage(this, stype: stype);
        }
        
        // Drop: to_dlpack_for_read
        
        // Drop: to_dlpack_for_write
    }
    
    public static partial class Helper
    {
        internal static int _getIndexingDispatchCode(NDArray key)
        {
            // Expr
            if (IsTrue(Isinstance(key, ValueTuple.Create(typeof(NDArray), Np.NDArray))))
            {
                return _NDARRAY_ADVANCED_INDEXING;
            }
            else
            {
                return _NDARRAY_UNSUPPORTED_INDEXING;
            }
        }
    }
    
    public static partial class Helper
    {
        internal static int _getIndexingDispatchCode(object key)
        {
            // Expr
            if (IsTrue(Isinstance(key, ValueTuple.Create(typeof(NDArray), Np.NDArray))))
            {
                return _NDARRAY_ADVANCED_INDEXING;
            }
            else
            {
                return _NDARRAY_UNSUPPORTED_INDEXING;
            }
        }
    }
    
    public static partial class Helper
    {
        internal static ValueTuple<int, int, int> _getIndexRange(int start, int stop, int length, int step = 1)
        {
            // Expr
            if (IsTrue((step == 0)))
            {
                throw new ValueError("step size cannot be zero");
            }
            if (IsTrue((length < 0)))
            {
                throw new ValueError("array length cannot be less than zero");
            }
            if (IsTrue((IsNone(step))))
            {
                step = 1;
            }
            if (IsTrue((IsNone(start))))
            {
                if (IsTrue((step > 0)))
                {
                    start = 0;
                }
                else
                {
                    start = (length - 1);
                }
            }
            else
            {
                if (IsTrue((start < 0)))
                {
                    start = BinOp.Add(start, length);
                    if (IsTrue((start < 0)))
                    {
                        throw new IndexError(("Slicing start %d exceeds limit of %d".PyFormat(ValueTuple.Create((start - length), length))));
                    }
                }
                else
                {
                    if (IsTrue((start >= length)))
                    {
                        throw new IndexError(("Slicing start %d exceeds limit of %d".PyFormat(ValueTuple.Create(start, length))));
                    }
                }
            }
            if (IsTrue((IsNone(stop))))
            {
                if (IsTrue((step > 0)))
                {
                    stop = length;
                }
                else
                {
                    stop = (-1);
                }
            }
            else
            {
                if (IsTrue((stop < 0)))
                {
                    stop = BinOp.Add(stop, length);
                    if (IsTrue((stop < 0)))
                    {
                        throw new IndexError(("Slicing stop %d exceeds limit of %d".PyFormat(ValueTuple.Create((stop - length), length))));
                    }
                }
                else
                {
                    if (IsTrue((stop > length)))
                    {
                        throw new IndexError(("Slicing stop %d exceeds limit of %d".PyFormat(ValueTuple.Create(stop, length))));
                    }
                }
            }
            return ValueTuple.Create(start, stop, step);
        }
    }
    
    public static partial class Helper
    {
        internal static object _getOshapeOfGatherNdOp(Shape dshape, Shape ishape)
        {
            // Expr
            Assert(IsTrue((IsTrue((Len(dshape) > 0)) && IsTrue((Len(ishape) > 0)))), "(IsTrue((Len(dshape) > 0)) && IsTrue((Len(ishape) > 0)))");
            var oshape = List(ishape.Slice(1, null, null));
            if (IsTrue((ishape.Item1 < Len(dshape))))
            {
                oshape.Extend(dshape.Slice(ishape.Item1, null, null));
            }
            return Tuple(oshape);
        }
    }
    
    public static partial class Helper
    {
        internal static object _getDimSize(int start, int stop, int step)
        {
            int dimSize = 0;
            // Expr
            Assert(IsTrue((step != 0)), "(step != 0)");
            if (IsTrue((step > 0)))
            {
                Assert(IsTrue((start < stop)), "(start < stop)");
                dimSize = CoerceIntoInt(BinOp.Add((((stop - start) - 1) / step), 1));
            }
            else
            {
                Assert(IsTrue((stop < start)), "(stop < start)");
                dimSize = CoerceIntoInt(BinOp.Add((((start - stop) - 1) / (-step)), 1));
            }
            return dimSize;
        }
    }
    
    public static partial class Helper
    {
        internal static object _getBroadcastShape(Shape shape1, Shape shape2)
        {
            Shape shape;
            // Expr
            if (IsTrue((shape1 == shape2)))
            {
                return shape1;
            }
            var length1 = Len(shape1);
            var length2 = Len(shape2);
            if (IsTrue((length1 > length2)))
            {
                shape = CoerceIntoShape(List(shape1));
            }
            else
            {
                shape = CoerceIntoShape(List(shape2));
            }
            var i = (Max(length1, length2) - 1);
            foreach (var (a, b) in Zip(shape1.Slice(null, null, null), shape2.Slice(null, null, null)))
            {
                if (IsTrue((IsTrue((a != 1)) && IsTrue((b != 1)) && IsTrue((a != b)))))
                {
                    throw new ValueError(("shape1=%s is not broadcastable to shape2=%s".PyFormat(ValueTuple.Create(shape1, shape2))));
                }
                shape[i] = Max(a, b);
                i = (i - 1);
            }
            return Tuple(shape);
        }
    }
    
    public static partial class Helper
    {
        public static object OnehotEncode(object indices, object @out)
        {
            // Expr
            return _internal._onehotEncode(indices, @out, @out: @out);
        }
    }
    
    public static partial class Helper
    {
        public static object Ones(Shape shape, Context ctx = null, DType dtype = default)
        {
            var kwargs = new Dictionary<string, string>();
            // Expr
            if (IsTrue((IsNone(ctx))))
            {
                ctx = CurrentContext();
            }
            dtype = (IsTrue((IsNone(dtype))) ? MxRealT : dtype);
            return _internal._ones(shape: shape, ctx: ctx, dtype: dtype);
        }
    }
    
    public static partial class Helper
    {
        public static NDArray Full(Shape shape, object val, Context ctx = null, DType dtype = default, NDArray @out = null)
        {
            // Expr
            @out = (IsTrue((IsNone(@out))) ? Empty(shape, ctx, dtype) : @out);
            @out.Slice(null, null, null) = val;
            return @out;
        }
    }
    
    public static partial class Helper
    {
        public static object Array(NDArray sourceArray, Context ctx = null, DType dtype = default)
        {
            // Expr
            dtype = (IsTrue((IsNone(dtype))) ? sourceArray.DType : dtype);
            var arr = Empty(sourceArray.Shape, ctx, dtype);
            arr.Slice(null, null, null) = sourceArray;
            return arr;
        }
    }
    
    public static partial class Helper
    {
        public static object Moveaxis(object tensor, object source, object destination)
        {
            // Expr
            if (IsTrue((Len(source) != Len(destination))))
            {
                throw new ValueError("`source` and `destination` arguments must have the same number of elements");
            }
            var order = Range(tensor.Ndim).Where(n => (!source.Contains(n))).Select(n => n).ToList();
            foreach (var (dest, src) in Sorted(Zip(destination, source)))
            {
                order.Insert(dest, src);
            }
            return Op.Transpose(tensor, order);
        }
    }
    
    public static partial class Helper
    {
        public static object Arange(object start, object stop = null, float step = 1.0f, int repeat = 1, object inferRange = null, Context ctx = null, DType dtype = default)
        {
            // Expr
            if (IsTrue((!IsNone(inferRange))))
            {
                Warnings.Warn("`infer_range` argument has been deprecated", typeof(DeprecationWarning));
            }
            if (IsTrue((IsNone(ctx))))
            {
                ctx = CurrentContext();
            }
            return _internal._arange(start: start, stop: stop, step: step, repeat: repeat, inferRange: false, dtype: dtype, ctx: Str(ctx));
        }
    }
    
    public static partial class Helper
    {
        public static object Linspace(object start, object stop, object num, bool endpoint = true, Context ctx = null, DType dtype = default)
        {
            // Expr
            if (IsTrue((IsNone(ctx))))
            {
                ctx = CurrentContext();
            }
            return _internal._linspace(start: start, stop: stop, num: num, endpoint: endpoint, dtype: dtype, ctx: Str(ctx));
        }
    }
    
    // Drop: _ufunc_helper
    
    public static partial class Helper
    {
        public static NDArray Add(NDArray lhs, NDArray rhs)
        {
            // Expr
            return Op.BroadcastAdd(lhs, rhs);;
        }
    }
    
    public static partial class Helper
    {
        public static NDArray Add(NDArray lhs, float rhs)
        {
            // Expr
            return _internal._plusScalar(lhs, rhs);;
        }
    }
    
    public static partial class Helper
    {
        public static NDArray Add(float lhs, NDArray rhs)
        {
            // Expr
            return _internal._plusScalar(lhs, rhs);;
        }
    }
    
    public static partial class Helper
    {
        public static float Add(float lhs, float rhs)
        {
            // Expr
            return Operator.Add(lhs, rhs);;
        }
    }
    
    public static partial class Helper
    {
        public static NDArray Subtract(NDArray lhs, NDArray rhs)
        {
            // Expr
            return Op.BroadcastSub(lhs, rhs);;
        }
    }
    
    public static partial class Helper
    {
        public static NDArray Subtract(NDArray lhs, float rhs)
        {
            // Expr
            return _internal._minusScalar(lhs, rhs);;
        }
    }
    
    public static partial class Helper
    {
        public static NDArray Subtract(float lhs, NDArray rhs)
        {
            // Expr
            return _internal._rminusScalar(rhs, lhs);;
        }
    }
    
    public static partial class Helper
    {
        public static float Subtract(float lhs, float rhs)
        {
            // Expr
            return Operator.Sub(lhs, rhs);;
        }
    }
    
    public static partial class Helper
    {
        public static NDArray Multiply(NDArray lhs, NDArray rhs)
        {
            // Expr
            return Op.BroadcastMul(lhs, rhs);;
        }
    }
    
    public static partial class Helper
    {
        public static NDArray Multiply(NDArray lhs, float rhs)
        {
            // Expr
            return _internal._mulScalar(lhs, rhs);;
        }
    }
    
    public static partial class Helper
    {
        public static NDArray Multiply(float lhs, NDArray rhs)
        {
            // Expr
            return _internal._mulScalar(lhs, rhs);;
        }
    }
    
    public static partial class Helper
    {
        public static float Multiply(float lhs, float rhs)
        {
            // Expr
            return Operator.Mul(lhs, rhs);;
        }
    }
    
    public static partial class Helper
    {
        public static NDArray Divide(NDArray lhs, NDArray rhs)
        {
            // Expr
            return Op.BroadcastDiv(lhs, rhs);;
        }
    }
    
    public static partial class Helper
    {
        public static NDArray Divide(NDArray lhs, float rhs)
        {
            // Expr
            return _internal._divScalar(lhs, rhs);;
        }
    }
    
    public static partial class Helper
    {
        public static NDArray Divide(float lhs, NDArray rhs)
        {
            // Expr
            return _internal._rdivScalar(rhs, lhs);;
        }
    }
    
    public static partial class Helper
    {
        public static float Divide(float lhs, float rhs)
        {
            // Expr
            return Operator.Truediv(lhs, rhs);;
        }
    }
    
    public static partial class Helper
    {
        public static NDArray Modulo(NDArray lhs, NDArray rhs)
        {
            // Expr
            return Op.BroadcastMod(lhs, rhs);;
        }
    }
    
    public static partial class Helper
    {
        public static NDArray Modulo(NDArray lhs, float rhs)
        {
            // Expr
            return _internal._modScalar(lhs, rhs);;
        }
    }
    
    public static partial class Helper
    {
        public static NDArray Modulo(float lhs, NDArray rhs)
        {
            // Expr
            return _internal._rmodScalar(rhs, lhs);;
        }
    }
    
    public static partial class Helper
    {
        public static float Modulo(float lhs, float rhs)
        {
            // Expr
            return Operator.Mod(lhs, rhs);;
        }
    }
    
    public static partial class Helper
    {
        public static NDArray Power(NDArray @base, NDArray exp)
        {
            // Expr
            return Op.BroadcastPower(base, exp);;
        }
    }
    
    public static partial class Helper
    {
        public static NDArray Power(NDArray @base, float exp)
        {
            // Expr
            return _internal._powerScalar(base, exp);;
        }
    }
    
    public static partial class Helper
    {
        public static NDArray Power(float @base, NDArray exp)
        {
            // Expr
            return _internal._rpowerScalar(exp, base);;
        }
    }
    
    public static partial class Helper
    {
        public static float Power(float @base, float exp)
        {
            // Expr
            return Operator.Pow(base, exp);;
        }
    }
    
    public static partial class Helper
    {
        public static NDArray Maximum(NDArray lhs, NDArray rhs)
        {
            // Expr
            return Op.BroadcastMaximum(lhs, rhs);;
        }
    }
    
    public static partial class Helper
    {
        public static NDArray Maximum(NDArray lhs, float rhs)
        {
            // Expr
            return _internal._maximumScalar(lhs, rhs);;
        }
    }
    
    public static partial class Helper
    {
        public static NDArray Maximum(float lhs, NDArray rhs)
        {
            // Expr
            return _internal._maximumScalar(lhs, rhs);;
        }
    }
    
    public static partial class Helper
    {
        public static float Maximum(float lhs, float rhs)
        {
            // Expr
            return (IsTrue((lhs > rhs)) ? lhs : rhs);
        }
    }
    
    public static partial class Helper
    {
        public static NDArray Minimum(NDArray lhs, NDArray rhs)
        {
            // Expr
            return Op.BroadcastMinimum(lhs, rhs);;
        }
    }
    
    public static partial class Helper
    {
        public static NDArray Minimum(NDArray lhs, float rhs)
        {
            // Expr
            return _internal._minimumScalar(lhs, rhs);;
        }
    }
    
    public static partial class Helper
    {
        public static NDArray Minimum(float lhs, NDArray rhs)
        {
            // Expr
            return _internal._minimumScalar(lhs, rhs);;
        }
    }
    
    public static partial class Helper
    {
        public static float Minimum(float lhs, float rhs)
        {
            // Expr
            return (IsTrue((lhs < rhs)) ? lhs : rhs);
        }
    }
    
    public static partial class Helper
    {
        public static NDArray Equal(NDArray lhs, NDArray rhs)
        {
            // Expr
            return Op.BroadcastEqual(lhs, rhs);;
        }
    }
    
    public static partial class Helper
    {
        public static NDArray Equal(NDArray lhs, float rhs)
        {
            // Expr
            return _internal._equalScalar(lhs, rhs);;
        }
    }
    
    public static partial class Helper
    {
        public static NDArray Equal(float lhs, NDArray rhs)
        {
            // Expr
            return _internal._equalScalar(lhs, rhs);;
        }
    }
    
    public static partial class Helper
    {
        public static float Equal(float lhs, float rhs)
        {
            // Expr
            return (IsTrue((lhs == rhs)) ? 1 : 0);
        }
    }
    
    public static partial class Helper
    {
        public static NDArray NotEqual(NDArray lhs, NDArray rhs)
        {
            // Expr
            return Op.BroadcastNotEqual(lhs, rhs);;
        }
    }
    
    public static partial class Helper
    {
        public static NDArray NotEqual(NDArray lhs, float rhs)
        {
            // Expr
            return _internal._notEqualScalar(lhs, rhs);;
        }
    }
    
    public static partial class Helper
    {
        public static NDArray NotEqual(float lhs, NDArray rhs)
        {
            // Expr
            return _internal._notEqualScalar(lhs, rhs);;
        }
    }
    
    public static partial class Helper
    {
        public static float NotEqual(float lhs, float rhs)
        {
            // Expr
            return (IsTrue((lhs != rhs)) ? 1 : 0);
        }
    }
    
    public static partial class Helper
    {
        public static NDArray Greater(NDArray lhs, NDArray rhs)
        {
            // Expr
            return Op.BroadcastGreater(lhs, rhs);;
        }
    }
    
    public static partial class Helper
    {
        public static NDArray Greater(NDArray lhs, float rhs)
        {
            // Expr
            return _internal._greaterScalar(lhs, rhs);;
        }
    }
    
    public static partial class Helper
    {
        public static NDArray Greater(float lhs, NDArray rhs)
        {
            // Expr
            return _internal._lesserScalar(rhs, lhs);;
        }
    }
    
    public static partial class Helper
    {
        public static float Greater(float lhs, float rhs)
        {
            // Expr
            return (IsTrue((lhs > rhs)) ? 1 : 0);
        }
    }
    
    public static partial class Helper
    {
        public static NDArray GreaterEqual(NDArray lhs, NDArray rhs)
        {
            // Expr
            return Op.BroadcastGreaterEqual(lhs, rhs);;
        }
    }
    
    public static partial class Helper
    {
        public static NDArray GreaterEqual(NDArray lhs, float rhs)
        {
            // Expr
            return _internal._greaterEqualScalar(lhs, rhs);;
        }
    }
    
    public static partial class Helper
    {
        public static NDArray GreaterEqual(float lhs, NDArray rhs)
        {
            // Expr
            return _internal._lesserEqualScalar(rhs, lhs);;
        }
    }
    
    public static partial class Helper
    {
        public static float GreaterEqual(float lhs, float rhs)
        {
            // Expr
            return (IsTrue((lhs >= rhs)) ? 1 : 0);
        }
    }
    
    public static partial class Helper
    {
        public static NDArray Lesser(NDArray lhs, NDArray rhs)
        {
            // Expr
            return Op.BroadcastLesser(lhs, rhs);;
        }
    }
    
    public static partial class Helper
    {
        public static NDArray Lesser(NDArray lhs, float rhs)
        {
            // Expr
            return _internal._lesserScalar(lhs, rhs);;
        }
    }
    
    public static partial class Helper
    {
        public static NDArray Lesser(float lhs, NDArray rhs)
        {
            // Expr
            return _internal._greaterScalar(rhs, lhs);;
        }
    }
    
    public static partial class Helper
    {
        public static float Lesser(float lhs, float rhs)
        {
            // Expr
            return (IsTrue((lhs < rhs)) ? 1 : 0);
        }
    }
    
    public static partial class Helper
    {
        public static NDArray LesserEqual(NDArray lhs, NDArray rhs)
        {
            // Expr
            return Op.BroadcastLesserEqual(lhs, rhs);;
        }
    }
    
    public static partial class Helper
    {
        public static NDArray LesserEqual(NDArray lhs, float rhs)
        {
            // Expr
            return _internal._lesserEqualScalar(lhs, rhs);;
        }
    }
    
    public static partial class Helper
    {
        public static NDArray LesserEqual(float lhs, NDArray rhs)
        {
            // Expr
            return _internal._greaterEqualScalar(rhs, lhs);;
        }
    }
    
    public static partial class Helper
    {
        public static float LesserEqual(float lhs, float rhs)
        {
            // Expr
            return (IsTrue((lhs <= rhs)) ? 1 : 0);
        }
    }
    
    public static partial class Helper
    {
        public static NDArray LogicalAnd(NDArray lhs, NDArray rhs)
        {
            // Expr
            return Op.BroadcastLogicalAnd(lhs, rhs);;
        }
    }
    
    public static partial class Helper
    {
        public static NDArray LogicalAnd(NDArray lhs, float rhs)
        {
            // Expr
            return _internal._logicalAndScalar(lhs, rhs);;
        }
    }
    
    public static partial class Helper
    {
        public static NDArray LogicalAnd(float lhs, NDArray rhs)
        {
            // Expr
            return _internal._logicalAndScalar(lhs, rhs);;
        }
    }
    
    public static partial class Helper
    {
        public static float LogicalAnd(float lhs, float rhs)
        {
            // Expr
            return (IsTrue((IsTrue(lhs) && IsTrue(rhs))) ? 1 : 0);
        }
    }
    
    public static partial class Helper
    {
        public static NDArray LogicalOr(NDArray lhs, NDArray rhs)
        {
            // Expr
            return Op.BroadcastLogicalOr(lhs, rhs);;
        }
    }
    
    public static partial class Helper
    {
        public static NDArray LogicalOr(NDArray lhs, float rhs)
        {
            // Expr
            return _internal._logicalOrScalar(lhs, rhs);;
        }
    }
    
    public static partial class Helper
    {
        public static NDArray LogicalOr(float lhs, NDArray rhs)
        {
            // Expr
            return _internal._logicalOrScalar(lhs, rhs);;
        }
    }
    
    public static partial class Helper
    {
        public static float LogicalOr(float lhs, float rhs)
        {
            // Expr
            return (IsTrue((IsTrue(lhs) || IsTrue(rhs))) ? 1 : 0);
        }
    }
    
    public static partial class Helper
    {
        public static NDArray LogicalXor(NDArray lhs, NDArray rhs)
        {
            // Expr
            return Op.BroadcastLogicalXor(lhs, rhs);;
        }
    }
    
    public static partial class Helper
    {
        public static NDArray LogicalXor(NDArray lhs, float rhs)
        {
            // Expr
            return _internal._logicalXorScalar(lhs, rhs);;
        }
    }
    
    public static partial class Helper
    {
        public static NDArray LogicalXor(float lhs, NDArray rhs)
        {
            // Expr
            return _internal._logicalXorScalar(lhs, rhs);;
        }
    }
    
    public static partial class Helper
    {
        public static float LogicalXor(float lhs, float rhs)
        {
            // Expr
            return (IsTrue((Bool(lhs) ^ Bool(rhs))) ? 1 : 0);
        }
    }
    
    public static partial class Helper
    {
        public static NDArray TrueDivide(NDArray lhs, NDArray rhs)
        {
            // Expr
            return Divide(lhs, rhs);
        }
    }
    
    public static partial class Helper
    {
        public static NDArray TrueDivide(NDArray lhs, float rhs)
        {
            // Expr
            return Divide(lhs, rhs);
        }
    }
    
    public static partial class Helper
    {
        public static NDArray TrueDivide(float lhs, NDArray rhs)
        {
            // Expr
            return Divide(lhs, rhs);
        }
    }
    
    public static partial class Helper
    {
        public static NDArray TrueDivide(float lhs, float rhs)
        {
            // Expr
            return Divide(lhs, rhs);
        }
    }
    
    public static partial class Helper
    {
        public static object Concatenate(NDArrayList arrays, int axis = 0, bool alwaysCopy = true)
        {
            // Expr
            Assert(IsTrue(Isinstance(arrays, typeof(List))), "Isinstance(arrays, typeof(List))");
            Assert(IsTrue((Len(arrays) > 0)), "(Len(arrays) > 0)");
            Assert(IsTrue(Isinstance(arrays.Item1, typeof(NDArray))), "Isinstance(arrays.Item1, typeof(NDArray))");
            if (IsTrue((IsTrue((!IsTrue(alwaysCopy))) && IsTrue((Len(arrays) == 1)))))
            {
                return arrays.Item1;
            }
            var shapeAxis = arrays.Item1.Shape[axis];
            var shapeRest1 = arrays.Item1.Shape.Slice(0, axis, null);
            var shapeRest2 = arrays.Item1.Shape.Slice(BinOp.Add(axis, 1), null, null);
            var dtype = arrays.Item1.DType;
            foreach (var arr in arrays.Slice(1, null, null))
            {
                shapeAxis = BinOp.Add(shapeAxis, arr.Shape[axis]);
                Assert(IsTrue((shapeRest1 == arr.Shape.Slice(0, axis, null))), "(shapeRest1 == arr.Shape.Slice(0, axis, null))");
                Assert(IsTrue((shapeRest2 == arr.Shape.Slice(BinOp.Add(axis, 1), null, null))), "(shapeRest2 == arr.Shape.Slice(BinOp.Add(axis, 1), null, null))");
                Assert(IsTrue((dtype == arr.DType)), "(dtype == arr.DType)");
            }
            var retShape = BinOp.Add(BinOp.Add(shapeRest1, ValueTuple.Create(shapeAxis)), shapeRest2);
            var ret = Empty(retShape, ctx: arrays.Item1.Context, dtype: dtype);
            var idx = 0;
            var begin = retShape.Select(_ => 0).ToList();
            var end = List(retShape);
            foreach (var arr in arrays)
            {
                if (IsTrue((axis == 0)))
                {
                    ret.Slice(idx, BinOp.Add(idx, arr.Shape.Item1), null) = arr;
                }
                else
                {
                    begin[axis] = idx;
                    end[axis] = BinOp.Add(idx, arr.Shape[axis]);
                    _internal._cropAssign(ret, arr, @out: ret, begin: Tuple(begin), end: Tuple(end));
                }
                idx = BinOp.Add(idx, arr.Shape[axis]);
            }
            return ret;
        }
    }
    
    public static partial class Helper
    {
        public static NDArray Imdecode(string strImg, ValueTuple<int, int, int, int> clipRect, NDArray @out = null, int index = 0, int channels = 3, object mean = null)
        {
            // Expr
            if (IsTrue((IsNone(mean))))
            {
                mean = new NDArray(_newEmptyHandle());
            }
            if (IsTrue((IsNone(@out))))
            {
                return _internal._imdecode(mean, index, clipRect.Item1, clipRect.Item2, clipRect.Item3, clipRect.Item4, channels, Len(strImg), strImg: strImg);
            }
            else
            {
                return _internal._imdecode(mean, index, clipRect.Item1, clipRect.Item2, clipRect.Item3, clipRect.Item4, channels, Len(strImg), strImg: strImg, @out: @out);
            }
        }
    }
    
    public static partial class Helper
    {
        public static object Zeros(Shape shape, Context ctx = null, DType dtype = default)
        {
            var kwargs = new Dictionary<string, string>();
            // Expr
            if (IsTrue((IsNone(ctx))))
            {
                ctx = CurrentContext();
            }
            dtype = (IsTrue((IsNone(dtype))) ? MxRealT : dtype);
            return _internal._zeros(shape: shape, ctx: ctx, dtype: dtype);
        }
    }
    
    public static partial class Helper
    {
        public static object Eye(object N, int M = 0, int k = 0, Context ctx = null, DType dtype = default)
        {
            var kwargs = new Dictionary<string, string>();
            // Expr
            if (IsTrue((IsNone(ctx))))
            {
                ctx = CurrentContext();
            }
            dtype = (IsTrue((IsNone(dtype))) ? MxRealT : dtype);
            return _internal._eye(N: N, M: M, k: k, ctx: ctx, dtype: dtype);
        }
    }
    
    public static partial class Helper
    {
        public static NDArray Empty(Shape shape, Context ctx = null, DType dtype = default)
        {
            // Expr
            if (IsTrue((IsNone(ctx))))
            {
                ctx = CurrentContext();
            }
            if (IsTrue((IsNone(dtype))))
            {
                dtype = MxRealT;
            }
            return new NDArray(handle: _newAllocHandle(shape, ctx, false, dtype));
        }
    }
    
    public static partial class Helper
    {
        public static object Histogram(object a, int bins = 10, object range = null)
        {
            // Expr
            if (IsTrue((IsNone(range))))
            {
                Warnings.Warn("range is not specified, using numpy's result to ensure consistency with numpy");
                var (res, binBounds) = Np.Histogram(a.Asnumpy(), bins: bins);
                return ValueTuple.Create(Array(res), Array(binBounds));
            }
            return _internal._histogram(data: a, binCnt: bins, range: range);
        }
    }
    
    public static partial class Helper
    {
        public static NDArray SplitV2(NDArray ary, int indicesOrSections, int axis = 0, bool squeezeAxis = false)
        {
            // Expr
            var indices = CoerceIntoList<int>(null);
            var axisSize = ary.Shape[axis];
            var sections = indicesOrSections;
            if (IsTrue((axisSize % sections)))
            {
                throw new ValueError("array split does not result in an equal division");
            }
            var sectionSize = Int((axisSize / sections));
            indices = CoerceIntoList<int>(Range(sections).Select(i => BinOp.Mult(i, sectionSize)).ToList());
            return _internal._splitV2(ary, indices, axis, squeezeAxis);
        }
    }
    
    public static partial class Helper
    {
        public static NDArray SplitV2(NDArray ary, IEnumerable<int> indicesOrSections, int axis = 0, bool squeezeAxis = false)
        {
            // Expr
            var indices = CoerceIntoList<int>(null);
            var axisSize = ary.Shape[axis];
            indices = CoerceIntoList<int>(BinOp.Add(new [] { 0 }, List(indicesOrSections)));
            return _internal._splitV2(ary, indices, axis, squeezeAxis);
        }
    }
    
    // Drop: PyCapsuleDestructor
    
    // Drop: _c_str_dltensor
    
    // Drop: _c_str_used_dltensor
    
    // Drop: _dlpack_deleter
    
    // Drop: _c_dlpack_deleter
    
    // Drop: to_dlpack_for_read
    
    // Drop: to_dlpack_for_write
    
    // Drop: from_dlpack
    
    // Drop: DLContext
    
    // Drop: DLDataType
    
    // Drop: DLTensor
    
    // Drop: DLManagedTensor
    
    // Drop: DeleterFunc
    
    // Assignment of attribute
    
    // Drop: dl_managed_tensor_deleter
    
    // Drop: from_numpy
}
