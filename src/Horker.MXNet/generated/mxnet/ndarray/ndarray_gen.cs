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
using Op = Horker.MXNet.NDArray.Op;
using _internal = Horker.MXNet.NDArray._internal;

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
            CheckCall(_LIB.MXNDArrayCreateFromSharedMemEx(CTypes.CInt(sharedPid), CTypes.CInt(sharedId), shape.Cast<int>().ToArray(), MxInt(Len(shape)), CTypes.CInt(Int(_DTYPE_NP_TO_MX[Np.DType(dtype).Type])), out hdl));
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
        public static object __ArrayPriority__ = CoerceIntoObject(1000.0f);
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
        
        internal object __Add__(NDArray other)
        {
            // Expr
            return Add(this, other);
        }
        
        internal object __Iadd__(NDArray other)
        {
            // Expr
            if (IsTrue((!IsTrue(this.Writable))))
            {
                throw new ValueError("trying to add to a readonly NDArray");
            }
            return Op.BroadcastAdd(this, other, @out: this);
        }
        
        internal object __Radd__(NDArray other)
        {
            return this.__Add__(other);
        }
        
        internal object __Sub__(NDArray other)
        {
            // Expr
            return Subtract(this, other);
        }
        
        internal object __Isub__(NDArray other)
        {
            // Expr
            if (IsTrue((!IsTrue(this.Writable))))
            {
                throw new ValueError("trying to subtract from a readonly NDArray");
            }
            return Op.BroadcastSub(this, other, @out: this);
        }
        
        internal object __Rsub__(NDArray other)
        {
            // Expr
            return Subtract(other, this);
        }
        
        internal object __Mul__(NDArray other)
        {
            // Expr
            return Multiply(this, other);
        }
        
        internal object __Neg__()
        {
            // Expr
            return _internal._mulScalar(this, (-1.0f));
        }
        
        internal object __Imul__(NDArray other)
        {
            // Expr
            if (IsTrue((!IsTrue(this.Writable))))
            {
                throw new ValueError("trying to multiply to a readonly NDArray");
            }
            return Op.BroadcastMul(this, other, @out: this);
        }
        
        internal object __Rmul__(NDArray other)
        {
            return this.__Mul__(other);
        }
        
        internal object __Div__(NDArray other)
        {
            // Expr
            return Divide(this, other);
        }
        
        internal object __Rdiv__(NDArray other)
        {
            // Expr
            return Divide(other, this);
        }
        
        internal object __Idiv__(NDArray other)
        {
            // Expr
            if (IsTrue((!IsTrue(this.Writable))))
            {
                throw new ValueError("trying to divide from a readonly NDArray");
            }
            return Op.BroadcastDiv(this, other, @out: this);
        }
        
        internal object __Truediv__(NDArray other)
        {
            return Divide(this, other);
        }
        
        internal object __Rtruediv__(NDArray other)
        {
            return Divide(other, this);
        }
        
        internal object __Itruediv__(NDArray other)
        {
            return this.__Idiv__(other);
        }
        
        internal object __Mod__(NDArray other)
        {
            // Expr
            return Modulo(this, other);
        }
        
        internal object __Rmod__(NDArray other)
        {
            // Expr
            return Modulo(other, this);
        }
        
        internal object __Imod__(NDArray other)
        {
            // Expr
            if (IsTrue((!IsTrue(this.Writable))))
            {
                throw new ValueError("trying to take modulo from a readonly NDArray");
            }
            return Op.BroadcastMod(this, other, @out: this);
        }
        
        internal object __Pow__(NDArray other)
        {
            // Expr
            return Power(this, other);
        }
        
        internal object __Rpow__(NDArray other)
        {
            // Expr
            return Power(other, this);
        }
        
        internal object __Eq__(NDArray other)
        {
            // Expr
            return Equal(this, other);
        }
        
        internal object __Hash__()
        {
            // Expr
            return (Id(this) / 16);
        }
        
        internal object __Ne__(NDArray other)
        {
            // Expr
            return NotEqual(this, other);
        }
        
        internal object __Gt__(NDArray other)
        {
            // Expr
            return Greater(this, other);
        }
        
        internal object __Ge__(NDArray other)
        {
            // Expr
            return GreaterEqual(this, other);
        }
        
        internal object __Lt__(NDArray other)
        {
            // Expr
            return Lesser(this, other);
        }
        
        internal object __Le__(NDArray other)
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
        
        // Drop: __nonzero__
        
        internal object __Len__()
        {
            // Expr
            return this.Shape.Item1;
        }
        
        // Drop: __getstate__
        
        // Drop: __setstate__
        
        internal void __Setitem__(int key, NDArray value)
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
        
        internal void __Setitem__(PySlice key, NDArray value)
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
        
        internal object _prepareValueNd(float value, Shape vshape)
        {
            // Expr
            var valueNd = Full(shape: vshape, val: value, ctx: this.Context, dtype: this.DType);
            if (IsTrue((valueNd.Shape != vshape)))
            {
                valueNd = valueNd.BroadcastTo(vshape);
            }
            return valueNd;
        }
        
        internal object _prepareValueNd(NDArray value, Shape vshape)
        {
            // Expr
            var valueNd = value.AsInContext(this.Context);
            if (IsTrue((valueNd.DType != this.DType)))
            {
                valueNd = valueNd.Astype(this.DType);
            }
            if (IsTrue((valueNd.Shape != vshape)))
            {
                valueNd = valueNd.BroadcastTo(vshape);
            }
            return valueNd;
        }
        
        internal void _setNdBasicIndexing(int key, NDArray value)
        {
            // Expr
            var shape = this.Shape;
            if (IsTrue((key < 0)))
            {
                key = BinOp.Add(key, shape.Item1);
            }
            if (IsTrue((IsTrue((key < 0)) || IsTrue((key >= shape.Item1)))))
            {
                if (IsTrue((key < 0)))
                {
                    key = (key - shape.Item1);
                }
                throw new IndexError(("index %d is out of bounds for axis 0 with size %d".PyFormat(ValueTuple.Create(key, shape.Item1))));
            }
            key = PySlice(key, BinOp.Add(key, 1));
            Assert(IsTrue(Isinstance(key, typeof(Tuple))), "Isinstance(key, typeof(Tuple))");
            Assert(IsTrue((Len(key) <= Len(shape))), "(Len(key) <= Len(shape))");
            var begin = CoerceIntoShape(null);
            var end = CoerceIntoShape(null);
            var steps = CoerceIntoShape(null);
            var oshape = CoerceIntoShape(null);
            var vshape = CoerceIntoShape(null);
            foreach (var (i, sliceI) in Enumerate(key))
            {
                var dimSize = 1;
                begin.Append(sliceI);
                end.Append((IsTrue((sliceI != (-1))) ? BinOp.Add(sliceI, 1) : this.Shape[i]));
                steps.Append(1);
                oshape.Append(dimSize);
            }
            oshape.Extend(shape.Slice(Len(key), null, null));
            vshape.Extend(shape.Slice(Len(key), null, null));
            if (IsTrue((Len(vshape) == 0)))
            {
                vshape.Append(1);
            }
            oshape = CoerceIntoShape(Tuple(oshape));
            vshape = CoerceIntoShape(Tuple(vshape));
            var valueNd = this._prepareValueNd(value, vshape);
            if (IsTrue((vshape != oshape)))
            {
                valueNd = valueNd.Reshape(oshape);
            }
            _internal._sliceAssign(this, valueNd, begin, end, steps, @out: this);
        }
        
        internal void _setNdBasicIndexing(PySlice key, NDArray value)
        {
            // Expr
            var shape = this.Shape;
            var assignToSelf = (IsTrue((IsNone(key.Step))) || IsTrue((key.Step == 1)));
            assignToSelf = (assignToSelf & (IsTrue((IsNone(key.Start))) || IsTrue((key.Start == 0))));
            assignToSelf = (assignToSelf & (IsTrue((IsNone(key.Stop))) || IsTrue((key.Stop == shape.Item1))));
            if (IsTrue(assignToSelf))
            {
                if (IsTrue((!(value.Handle is this.Handle))))
                {
                    if (IsTrue((value.Shape != shape)))
                    {
                        value = value.BroadcastTo(shape);
                    }
                    value.Copyto(this);
                }
                return;
            }
            else
            {
                key = ValueTuple.Create(key);
            }
            Assert(IsTrue(Isinstance(key, typeof(Tuple))), "Isinstance(key, typeof(Tuple))");
            Assert(IsTrue((Len(key) <= Len(shape))), "(Len(key) <= Len(shape))");
            var begin = CoerceIntoShape(null);
            var end = CoerceIntoShape(null);
            var steps = CoerceIntoShape(null);
            var oshape = CoerceIntoShape(null);
            var vshape = CoerceIntoShape(null);
            foreach (var (i, sliceI) in Enumerate(key))
            {
                var dimSize = 1;
                begin.Append(sliceI);
                end.Append((IsTrue((sliceI != (-1))) ? BinOp.Add(sliceI, 1) : this.Shape[i]));
                steps.Append(1);
                oshape.Append(dimSize);
            }
            oshape.Extend(shape.Slice(Len(key), null, null));
            vshape.Extend(shape.Slice(Len(key), null, null));
            if (IsTrue((Len(vshape) == 0)))
            {
                vshape.Append(1);
            }
            oshape = CoerceIntoShape(Tuple(oshape));
            vshape = CoerceIntoShape(Tuple(vshape));
            var valueNd = this._prepareValueNd(value, vshape);
            if (IsTrue((vshape != oshape)))
            {
                valueNd = valueNd.Reshape(oshape);
            }
            _internal._sliceAssign(this, valueNd, begin, end, steps, @out: this);
        }
        
        // Drop: _set_nd_advanced_indexing
        
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
        
        internal NDArray _getNdBasicIndexing(PySlice key)
        {
            // Expr
            var shape = this.Shape;
            if (IsTrue((IsTrue((!IsNone(key.Step))) && IsTrue((key.Step != 1)))))
            {
                if (IsTrue((key.Step == 0)))
                {
                    throw new ValueError("slice step cannot be zero");
                }
                return Op.Slice(this, begin: ValueTuple.Create(key.Start), end: ValueTuple.Create(key.Stop), step: ValueTuple.Create(key.Step));
            }
            else
            {
                if (IsTrue((IsTrue((!IsNone(key.Start))) || IsTrue((!IsNone(key.Stop))))))
                {
                    return this._slice(key.Start, key.Stop);
                }
                else
                {
                    return this;
                }
            }
            Assert(IsTrue((Len(key) != 0)), "(Len(key) != 0)");
            var begin = null;
            var end = null;
            var step = null;
            var keptAxes = null;
            var i = (-1);
            foreach (var (i, sliceI) in Enumerate(key))
            {
                if (IsTrue(Isinstance(sliceI, typeof(IntegerTypes))))
                {
                    var local0 = (integer_types)sliceI;
                    begin.Append(local0);
                    end.Append((IsTrue((local0 != (-1))) ? BinOp.Add(local0, 1) : this.Shape[i]));
                    step.Append(1);
                }
                else
                {
                    if (IsTrue(Isinstance(sliceI, typeof(PySlice))))
                    {
                        var local0 = (py_slice)sliceI;
                        if (IsTrue((local0.Step == 0)))
                        {
                            throw new ValueError(("basic index=%s cannot have slice=%s with step = 0".PyFormat(ValueTuple.Create(Str(key), Str(local0)))));
                        }
                        begin.Append(local0.Start);
                        end.Append(local0.Stop);
                        step.Append(local0.Step);
                        keptAxes.Append(i);
                    }
                    else
                    {
                        throw new ValueError(("basic_indexing does not support slicing with index=%s of type=%s.".PyFormat(ValueTuple.Create(Str(sliceI), Str(Type(sliceI))))));
                    }
                }
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
        
        // Drop: _get_nd_advanced_indexing
        
        internal object _syncCopyfrom(object sourceArray)
        {
            // Expr
            if (IsTrue((!IsTrue(Isinstance(sourceArray, typeof(Np.NDArray))))))
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
        
        public NDArray Reshape(Shape shape, bool reverse = false)
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
            CheckCall(_LIB.MXNDArrayReshape64(this.Handle, Len(shape), shape.Cast<long>().ToArray(), reverse, out handle));
            return new NDArray(handle: handle, writable: this.Writable);
        }
        
        public NDArray ReshapeLike(NDArray rhs, NDArray @out = null)
        {
            // Expr
            return Op.ReshapeLike(this, rhs, @out);
        }
        
        public NDArray ZerosLike(NDArray @out = null)
        {
            // Expr
            return Op.ZerosLike(this, @out);
        }
        
        public NDArray OnesLike(NDArray @out = null)
        {
            // Expr
            return Op.OnesLike(this, @out);
        }
        
        // Drop: broadcast_axes
        
        public NDArray Repeat(int repeat, int axis, NDArray @out = null)
        {
            // Expr
            return Op.Repeat(this, repeat, axis);
        }
        
        public NDArray Pad(string mode, Shape padWidth, double constantValue, NDArray @out = null)
        {
            // Expr
            return Op.Pad(this, mode, padWidth, constantValue, @out);
        }
        
        // Drop: swapaxes
        
        // Drop: split
        
        // Drop: split_v2
        
        public NDArray Slice(Shape begin, Shape end, Shape step, NDArrayList @out = null)
        {
            // Expr
            return Op.Slice(this, begin, end, step, @out);
        }
        
        public NDArray SliceAxis(int axis, int begin, int end, NDArrayList @out = null)
        {
            // Expr
            return Op.SliceAxis(this, axis, begin, end, @out);
        }
        
        public NDArray SliceLike(NDArray shapeLike, Shape axes, NDArrayList @out = null)
        {
            // Expr
            return Op.SliceLike(this, shapeLike, axes, @out);
        }
        
        public NDArray Take(NDArray indices, int axis, string mode, NDArrayList @out = null)
        {
            // Expr
            return Op.Take(this, indices, axis, mode, @out);
        }
        
        public NDArray OneHot(int depth, double onValue, double offValue, DType dtype, NDArrayList @out = null)
        {
            // Expr
            return Op.OneHot(this, depth, onValue, offValue, dtype, @out);
        }
        
        public NDArray Pick(NDArray index, int axis, bool keepdims, string mode, NDArrayList @out = null)
        {
            // Expr
            return Op.Pick(this, index, axis, keepdims, mode, @out);
        }
        
        public NDArray Sort(int axis, bool isAscend, NDArrayList @out = null)
        {
            // Expr
            return Op.Sort(this, axis, isAscend, @out);
        }
        
        public NDArray Topk(int axis, int k, string retTyp, bool isAscend, DType dtype, NDArrayList @out = null)
        {
            // Expr
            return Op.Topk(this, axis, k, retTyp, isAscend, dtype, @out);
        }
        
        public NDArray Argsort(object *args)
        {
            // Expr
            return Op.Argsort(this, Args);
        }
        
        public NDArray Argmax(object *args)
        {
            // Expr
            return Op.Argmax(this, Args);
        }
        
        public NDArray ArgmaxChannel(object *args)
        {
            // Expr
            return Op.ArgmaxChannel(this, Args);
        }
        
        public NDArray Argmin(object *args)
        {
            // Expr
            return Op.Argmin(this, Args);
        }
        
        public NDArray Clip(object *args)
        {
            // Expr
            return Op.Clip(this, Args);
        }
        
        public NDArray Abs(object *args)
        {
            // Expr
            return Op.Abs(this, Args);
        }
        
        public NDArray Sign(object *args)
        {
            // Expr
            return Op.Sign(this, Args);
        }
        
        public NDArray Flatten(object *args)
        {
            // Expr
            return Op.Flatten(this, Args);
        }
        
        public NDArray ShapeArray(object *args)
        {
            // Expr
            return Op.ShapeArray(this, Args);
        }
        
        public NDArray SizeArray(object *args)
        {
            // Expr
            return Op.SizeArray(this, Args);
        }
        
        public NDArray ExpandDims(object *args)
        {
            // Expr
            return Op.ExpandDims(this, Args);
        }
        
        public NDArray Tile(object *args)
        {
            // Expr
            return Op.Tile(this, Args);
        }
        
        public object Transpose(object *args)
        {
            // Expr
            return Op.Transpose(this, Args);
        }
        
        public NDArray Flip(object *args)
        {
            // Expr
            return Op.Flip(this, Args);
        }
        
        public NDArray DepthToSpace(object *args)
        {
            // Expr
            return Op.DepthToSpace(this, Args);
        }
        
        public NDArray SpaceToDepth(object *args)
        {
            // Expr
            return Op.SpaceToDepth(this, Args);
        }
        
        public NDArray Diag(int k = 0)
        {
            // Expr
            return Op.Diag(this, k);
        }
        
        public NDArray Sum(object *args)
        {
            // Expr
            return Op.Sum(this, Args);
        }
        
        public NDArray Nansum(object *args)
        {
            // Expr
            return Op.Nansum(this, Args);
        }
        
        public NDArray Prod(object *args)
        {
            // Expr
            return Op.Prod(this, Args);
        }
        
        public NDArray Nanprod(object *args)
        {
            // Expr
            return Op.Nanprod(this, Args);
        }
        
        public NDArray Mean(object *args)
        {
            // Expr
            return Op.Mean(this, Args);
        }
        
        public NDArray Max(object *args)
        {
            // Expr
            return Op.Max(this, Args);
        }
        
        public NDArray Min(object *args)
        {
            // Expr
            return Op.Min(this, Args);
        }
        
        public NDArray Norm(object *args)
        {
            // Expr
            return Op.Norm(this, Args);
        }
        
        public NDArray Round(object *args)
        {
            // Expr
            return Op.Round(this, Args);
        }
        
        public NDArray Rint(object *args)
        {
            // Expr
            return Op.Rint(this, Args);
        }
        
        public NDArray Fix(object *args)
        {
            // Expr
            return Op.Fix(this, Args);
        }
        
        public NDArray Floor(object *args)
        {
            // Expr
            return Op.Floor(this, Args);
        }
        
        public NDArray Ceil(object *args)
        {
            // Expr
            return Op.Ceil(this, Args);
        }
        
        public NDArray Trunc(object *args)
        {
            // Expr
            return Op.Trunc(this, Args);
        }
        
        public NDArray Sin(object *args)
        {
            // Expr
            return Op.Sin(this, Args);
        }
        
        public NDArray Cos(object *args)
        {
            // Expr
            return Op.Cos(this, Args);
        }
        
        public NDArray Tan(object *args)
        {
            // Expr
            return Op.Tan(this, Args);
        }
        
        public NDArray Arcsin(object *args)
        {
            // Expr
            return Op.Arcsin(this, Args);
        }
        
        public NDArray Arccos(object *args)
        {
            // Expr
            return Op.Arccos(this, Args);
        }
        
        public NDArray Arctan(object *args)
        {
            // Expr
            return Op.Arctan(this, Args);
        }
        
        public NDArray Degrees(object *args)
        {
            // Expr
            return Op.Degrees(this, Args);
        }
        
        public NDArray Radians(object *args)
        {
            // Expr
            return Op.Radians(this, Args);
        }
        
        public NDArray Sinh(object *args)
        {
            // Expr
            return Op.Sinh(this, Args);
        }
        
        public NDArray Cosh(object *args)
        {
            // Expr
            return Op.Cosh(this, Args);
        }
        
        public NDArray Tanh(object *args)
        {
            // Expr
            return Op.Tanh(this, Args);
        }
        
        public NDArray Arcsinh(object *args)
        {
            // Expr
            return Op.Arcsinh(this, Args);
        }
        
        public NDArray Arccosh(object *args)
        {
            // Expr
            return Op.Arccosh(this, Args);
        }
        
        public NDArray Arctanh(object *args)
        {
            // Expr
            return Op.Arctanh(this, Args);
        }
        
        public NDArray Exp(object *args)
        {
            // Expr
            return Op.Exp(this, Args);
        }
        
        public NDArray Expm1(object *args)
        {
            // Expr
            return Op.Expm1(this, Args);
        }
        
        public NDArray Log(object *args)
        {
            // Expr
            return Op.Log(this, Args);
        }
        
        public NDArray Log10(object *args)
        {
            // Expr
            return Op.Log10(this, Args);
        }
        
        public NDArray Log2(object *args)
        {
            // Expr
            return Op.Log2(this, Args);
        }
        
        public NDArray Log1p(object *args)
        {
            // Expr
            return Op.Log1p(this, Args);
        }
        
        public NDArray Sqrt(object *args)
        {
            // Expr
            return Op.Sqrt(this, Args);
        }
        
        public NDArray Rsqrt(object *args)
        {
            // Expr
            return Op.Rsqrt(this, Args);
        }
        
        public NDArray Cbrt(object *args)
        {
            // Expr
            return Op.Cbrt(this, Args);
        }
        
        public NDArray Rcbrt(object *args)
        {
            // Expr
            return Op.Rcbrt(this, Args);
        }
        
        public NDArray Square(object *args)
        {
            // Expr
            return Op.Square(this, Args);
        }
        
        public NDArray Reciprocal(object *args)
        {
            // Expr
            return Op.Reciprocal(this, Args);
        }
        
        public NDArray Relu(object *args)
        {
            // Expr
            return Op.Relu(this, Args);
        }
        
        public NDArray Sigmoid(object *args)
        {
            // Expr
            return Op.Sigmoid(this, Args);
        }
        
        public NDArray Softmax(object *args)
        {
            // Expr
            return Op.Softmax(this, Args);
        }
        
        public NDArray LogSoftmax(object *args)
        {
            // Expr
            return Op.LogSoftmax(this, Args);
        }
        
        public NDArray Softmin(object *args)
        {
            // Expr
            return Op.Softmin(this, Args);
        }
        
        public NDArray Squeeze(Shape axis)
        {
            // Expr
            return Op.Squeeze(this, axis);
        }
        
        public NDArray BroadcastTo(Shape shape)
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
        
        public NDArray BroadcastLike(NDArray other)
        {
            // Expr
            return this.BroadcastTo(other.Shape);
        }
        
        public object WaitToRead()
        {
            // Expr
            CheckCall(_LIB.MXNDArrayWaitToRead(this.Handle));
        }
        
        public int Ndim
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
        
        public int Size
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
        
        public Np.NDArray Asnumpy()
        {
            // Expr
            var data = Np.Empty(this.Shape, dtype: this.DType);
            CheckCall(_LIB.MXNDArraySyncCopyToCPU(this.Handle, data.CTypes.DataAs(CTypes.CVoidP), CTypes.CSizeT(data.Size)));
            return data;
        }
        
        public float Asscalar()
        {
            // Expr
            if (IsTrue((this.Shape != ValueTuple.Create(1))))
            {
                throw new ValueError("The current array is not a scalar");
            }
            return this.Asnumpy().Item1;
        }
        
        public NDArray Astype(DType dtype, bool copy = true)
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
        
        public NDArray Copyto(NDArray other)
        {
            // Expr
            if (IsTrue(((other.Handle is this.Handle))))
            {
                Warnings.Warn("You are attempting to copy an array to itself", typeof(RuntimeWarning));
                return false;
            }
            return _internal._copyto(this, @out: other);
        }
        
        public NDArray Copy()
        {
            // Expr
            return this.Copyto(this.Context);
        }
        
        public NDArray AsInContext(Context context)
        {
            // Expr
            if (IsTrue((this.Context == context)))
            {
                return this;
            }
            return this.Copyto(context);
        }
        
        public void AttachGrad(string gradReq = "write", string stype = null)
        {
            NDArray grad;
            // Expr
            // ImportFrom
            if (IsTrue((!IsNone(stype))))
            {
                grad = CoerceIntoNDArray(_zeros(this.Shape, stype: stype));
            }
            else
            {
                grad = CoerceIntoNDArray(Op.ZerosLike(this));
            }
            var gradReqReassigned = _GRAD_REQ_MAP[gradReq];
            CheckCall(_LIB.MXAutogradMarkVariables(1, CTypes.Pointer(this.Handle), CTypes.Pointer(MxUint(gradReqReassigned)), CTypes.Pointer(grad.Handle)));
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
        
        public void Backward(NDArray outGrad = null, bool retainGraph = false, bool trainMode = true)
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
            CheckCall(_LIB.MXAutogradBackwardEx(1, CHandleArray(new [] { this }), ogradHandles.Cast<NDArrayHandle>().ToArray(), 0, CTypes.CVoidP(0), CTypes.CInt(retainGraph), CTypes.CInt(0), CTypes.CInt(trainMode), CTypes.CVoidP(0), CTypes.CVoidP(0)));
        }
        
        public NDArray Tostype(string stype)
        {
            // Expr
            return Op.CastStorage(this, stype: stype);
        }
        
        // Drop: to_dlpack_for_read
        
        // Drop: to_dlpack_for_write
    }
    
    public static partial class Helper
    {
        internal static int _getIndexingDispatchCode(int key)
        {
            // Expr
            return _NDARRAY_BASIC_INDEXING;
        }
    }
    
    public static partial class Helper
    {
        internal static int _getIndexingDispatchCode(PySlice key)
        {
            // Expr
            return _NDARRAY_BASIC_INDEXING;
        }
    }
    
    public static partial class Helper
    {
        internal static int _getIndexingDispatchCode(object key)
        {
            // Expr
            return _NDARRAY_UNSUPPORTED_INDEXING;
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
        internal static Shape _getOshapeOfGatherNdOp(Shape dshape, Shape ishape)
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
        public static NDArray OnehotEncode(NDArray indices, NDArray @out)
        {
            // Expr
            return _internal._onehotEncode(indices, @out, @out: @out);
        }
    }
    
    public static partial class Helper
    {
        public static object Ones(Shape shape, Context ctx = null, DType dtype = default)
        {
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
        public static NDArray Full(Shape shape, float val, Context ctx = null, DType dtype = default, NDArray @out = null)
        {
            // Expr
            @out = (IsTrue((IsNone(@out))) ? Empty(shape, ctx, dtype) : @out);
            InsertToSlice(@out, null, null, null, val);
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
            InsertToSlice(arr, null, null, null, sourceArray);
            return arr;
        }
    }
    
    public static partial class Helper
    {
        public static object Moveaxis(NDArray tensor, Shape source, Shape destination)
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
        public static NDArray Arange(double start, double stop = double.NaN, double step = 1.0, int repeat = 1, bool inferRange = false, Context ctx = null, DType dtype = default)
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
        public static NDArray Linspace(double start, double stop, int num, bool endpoint = true, Context ctx = null, DType dtype = default)
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
            return /* _ufunc_helper expanded */ Op.BroadcastAdd(lhs, rhs);
        }
    }
    
    public static partial class Helper
    {
        public static NDArray Add(NDArray lhs, float rhs)
        {
            // Expr
            return /* _ufunc_helper expanded */ _internal._plusScalar(lhs, rhs);
        }
    }
    
    public static partial class Helper
    {
        public static NDArray Add(float lhs, NDArray rhs)
        {
            // Expr
            return /* _ufunc_helper expanded */ _internal._plusScalar(rhs, lhs);
        }
    }
    
    public static partial class Helper
    {
        public static float Add(float lhs, float rhs)
        {
            // Expr
            return /* _ufunc_helper expanded */ Operator.Add(lhs, rhs);
        }
    }
    
    public static partial class Helper
    {
        public static NDArray Subtract(NDArray lhs, NDArray rhs)
        {
            // Expr
            return /* _ufunc_helper expanded */ Op.BroadcastSub(lhs, rhs);
        }
    }
    
    public static partial class Helper
    {
        public static NDArray Subtract(NDArray lhs, float rhs)
        {
            // Expr
            return /* _ufunc_helper expanded */ _internal._minusScalar(lhs, rhs);
        }
    }
    
    public static partial class Helper
    {
        public static NDArray Subtract(float lhs, NDArray rhs)
        {
            // Expr
            return /* _ufunc_helper expanded */ _internal._rminusScalar(rhs, lhs);
        }
    }
    
    public static partial class Helper
    {
        public static float Subtract(float lhs, float rhs)
        {
            // Expr
            return /* _ufunc_helper expanded */ Operator.Sub(lhs, rhs);
        }
    }
    
    public static partial class Helper
    {
        public static NDArray Multiply(NDArray lhs, NDArray rhs)
        {
            // Expr
            return /* _ufunc_helper expanded */ Op.BroadcastMul(lhs, rhs);
        }
    }
    
    public static partial class Helper
    {
        public static NDArray Multiply(NDArray lhs, float rhs)
        {
            // Expr
            return /* _ufunc_helper expanded */ _internal._mulScalar(lhs, rhs);
        }
    }
    
    public static partial class Helper
    {
        public static NDArray Multiply(float lhs, NDArray rhs)
        {
            // Expr
            return /* _ufunc_helper expanded */ _internal._mulScalar(rhs, lhs);
        }
    }
    
    public static partial class Helper
    {
        public static float Multiply(float lhs, float rhs)
        {
            // Expr
            return /* _ufunc_helper expanded */ Operator.Mul(lhs, rhs);
        }
    }
    
    public static partial class Helper
    {
        public static NDArray Divide(NDArray lhs, NDArray rhs)
        {
            // Expr
            return /* _ufunc_helper expanded */ Op.BroadcastDiv(lhs, rhs);
        }
    }
    
    public static partial class Helper
    {
        public static NDArray Divide(NDArray lhs, float rhs)
        {
            // Expr
            return /* _ufunc_helper expanded */ _internal._divScalar(lhs, rhs);
        }
    }
    
    public static partial class Helper
    {
        public static NDArray Divide(float lhs, NDArray rhs)
        {
            // Expr
            return /* _ufunc_helper expanded */ _internal._rdivScalar(rhs, lhs);
        }
    }
    
    public static partial class Helper
    {
        public static float Divide(float lhs, float rhs)
        {
            // Expr
            return /* _ufunc_helper expanded */ Operator.Truediv(lhs, rhs);
        }
    }
    
    public static partial class Helper
    {
        public static NDArray Modulo(NDArray lhs, NDArray rhs)
        {
            // Expr
            return /* _ufunc_helper expanded */ Op.BroadcastMod(lhs, rhs);
        }
    }
    
    public static partial class Helper
    {
        public static NDArray Modulo(NDArray lhs, float rhs)
        {
            // Expr
            return /* _ufunc_helper expanded */ _internal._modScalar(lhs, rhs);
        }
    }
    
    public static partial class Helper
    {
        public static NDArray Modulo(float lhs, NDArray rhs)
        {
            // Expr
            return /* _ufunc_helper expanded */ _internal._rmodScalar(rhs, lhs);
        }
    }
    
    public static partial class Helper
    {
        public static float Modulo(float lhs, float rhs)
        {
            // Expr
            return /* _ufunc_helper expanded */ Operator.Mod(lhs, rhs);
        }
    }
    
    public static partial class Helper
    {
        public static NDArray Power(NDArray @base, NDArray exp)
        {
            // Expr
            return /* _ufunc_helper expanded */ Op.BroadcastPower(@base, exp);
        }
    }
    
    public static partial class Helper
    {
        public static NDArray Power(NDArray @base, float exp)
        {
            // Expr
            return /* _ufunc_helper expanded */ _internal._powerScalar(@base, exp);
        }
    }
    
    public static partial class Helper
    {
        public static NDArray Power(float @base, NDArray exp)
        {
            // Expr
            return /* _ufunc_helper expanded */ _internal._rpowerScalar(exp, @base);
        }
    }
    
    public static partial class Helper
    {
        public static float Power(float @base, float exp)
        {
            // Expr
            return /* _ufunc_helper expanded */ Operator.Pow(@base, exp);
        }
    }
    
    public static partial class Helper
    {
        public static NDArray Maximum(NDArray lhs, NDArray rhs)
        {
            // Expr
            return /* _ufunc_helper expanded */ Op.BroadcastMaximum(lhs, rhs);
        }
    }
    
    public static partial class Helper
    {
        public static NDArray Maximum(NDArray lhs, float rhs)
        {
            // Expr
            return /* _ufunc_helper expanded */ _internal._maximumScalar(lhs, rhs);
        }
    }
    
    public static partial class Helper
    {
        public static NDArray Maximum(float lhs, NDArray rhs)
        {
            // Expr
            return /* _ufunc_helper expanded */ _internal._maximumScalar(rhs, lhs);
        }
    }
    
    public static partial class Helper
    {
        public static float Maximum(float lhs, float rhs)
        {
            // Expr
            return /* _ufunc_helper expanded */ (IsTrue((lhs > rhs)) ? lhs : rhs);
        }
    }
    
    public static partial class Helper
    {
        public static NDArray Minimum(NDArray lhs, NDArray rhs)
        {
            // Expr
            return /* _ufunc_helper expanded */ Op.BroadcastMinimum(lhs, rhs);
        }
    }
    
    public static partial class Helper
    {
        public static NDArray Minimum(NDArray lhs, float rhs)
        {
            // Expr
            return /* _ufunc_helper expanded */ _internal._minimumScalar(lhs, rhs);
        }
    }
    
    public static partial class Helper
    {
        public static NDArray Minimum(float lhs, NDArray rhs)
        {
            // Expr
            return /* _ufunc_helper expanded */ _internal._minimumScalar(rhs, lhs);
        }
    }
    
    public static partial class Helper
    {
        public static float Minimum(float lhs, float rhs)
        {
            // Expr
            return /* _ufunc_helper expanded */ (IsTrue((lhs < rhs)) ? lhs : rhs);
        }
    }
    
    public static partial class Helper
    {
        public static NDArray Equal(NDArray lhs, NDArray rhs)
        {
            // Expr
            return /* _ufunc_helper expanded */ Op.BroadcastEqual(lhs, rhs);
        }
    }
    
    public static partial class Helper
    {
        public static NDArray Equal(NDArray lhs, float rhs)
        {
            // Expr
            return /* _ufunc_helper expanded */ _internal._equalScalar(lhs, rhs);
        }
    }
    
    public static partial class Helper
    {
        public static NDArray Equal(float lhs, NDArray rhs)
        {
            // Expr
            return /* _ufunc_helper expanded */ _internal._equalScalar(rhs, lhs);
        }
    }
    
    public static partial class Helper
    {
        public static float Equal(float lhs, float rhs)
        {
            // Expr
            return /* _ufunc_helper expanded */ (IsTrue((lhs == rhs)) ? 1 : 0);
        }
    }
    
    public static partial class Helper
    {
        public static NDArray NotEqual(NDArray lhs, NDArray rhs)
        {
            // Expr
            return /* _ufunc_helper expanded */ Op.BroadcastNotEqual(lhs, rhs);
        }
    }
    
    public static partial class Helper
    {
        public static NDArray NotEqual(NDArray lhs, float rhs)
        {
            // Expr
            return /* _ufunc_helper expanded */ _internal._notEqualScalar(lhs, rhs);
        }
    }
    
    public static partial class Helper
    {
        public static NDArray NotEqual(float lhs, NDArray rhs)
        {
            // Expr
            return /* _ufunc_helper expanded */ _internal._notEqualScalar(rhs, lhs);
        }
    }
    
    public static partial class Helper
    {
        public static float NotEqual(float lhs, float rhs)
        {
            // Expr
            return /* _ufunc_helper expanded */ (IsTrue((lhs != rhs)) ? 1 : 0);
        }
    }
    
    public static partial class Helper
    {
        public static NDArray Greater(NDArray lhs, NDArray rhs)
        {
            // Expr
            return /* _ufunc_helper expanded */ Op.BroadcastGreater(lhs, rhs);
        }
    }
    
    public static partial class Helper
    {
        public static NDArray Greater(NDArray lhs, float rhs)
        {
            // Expr
            return /* _ufunc_helper expanded */ _internal._greaterScalar(lhs, rhs);
        }
    }
    
    public static partial class Helper
    {
        public static NDArray Greater(float lhs, NDArray rhs)
        {
            // Expr
            return /* _ufunc_helper expanded */ _internal._lesserScalar(rhs, lhs);
        }
    }
    
    public static partial class Helper
    {
        public static float Greater(float lhs, float rhs)
        {
            // Expr
            return /* _ufunc_helper expanded */ (IsTrue((lhs > rhs)) ? 1 : 0);
        }
    }
    
    public static partial class Helper
    {
        public static NDArray GreaterEqual(NDArray lhs, NDArray rhs)
        {
            // Expr
            return /* _ufunc_helper expanded */ Op.BroadcastGreaterEqual(lhs, rhs);
        }
    }
    
    public static partial class Helper
    {
        public static NDArray GreaterEqual(NDArray lhs, float rhs)
        {
            // Expr
            return /* _ufunc_helper expanded */ _internal._greaterEqualScalar(lhs, rhs);
        }
    }
    
    public static partial class Helper
    {
        public static NDArray GreaterEqual(float lhs, NDArray rhs)
        {
            // Expr
            return /* _ufunc_helper expanded */ _internal._lesserEqualScalar(rhs, lhs);
        }
    }
    
    public static partial class Helper
    {
        public static float GreaterEqual(float lhs, float rhs)
        {
            // Expr
            return /* _ufunc_helper expanded */ (IsTrue((lhs >= rhs)) ? 1 : 0);
        }
    }
    
    public static partial class Helper
    {
        public static NDArray Lesser(NDArray lhs, NDArray rhs)
        {
            // Expr
            return /* _ufunc_helper expanded */ Op.BroadcastLesser(lhs, rhs);
        }
    }
    
    public static partial class Helper
    {
        public static NDArray Lesser(NDArray lhs, float rhs)
        {
            // Expr
            return /* _ufunc_helper expanded */ _internal._lesserScalar(lhs, rhs);
        }
    }
    
    public static partial class Helper
    {
        public static NDArray Lesser(float lhs, NDArray rhs)
        {
            // Expr
            return /* _ufunc_helper expanded */ _internal._greaterScalar(rhs, lhs);
        }
    }
    
    public static partial class Helper
    {
        public static float Lesser(float lhs, float rhs)
        {
            // Expr
            return /* _ufunc_helper expanded */ (IsTrue((lhs < rhs)) ? 1 : 0);
        }
    }
    
    public static partial class Helper
    {
        public static NDArray LesserEqual(NDArray lhs, NDArray rhs)
        {
            // Expr
            return /* _ufunc_helper expanded */ Op.BroadcastLesserEqual(lhs, rhs);
        }
    }
    
    public static partial class Helper
    {
        public static NDArray LesserEqual(NDArray lhs, float rhs)
        {
            // Expr
            return /* _ufunc_helper expanded */ _internal._lesserEqualScalar(lhs, rhs);
        }
    }
    
    public static partial class Helper
    {
        public static NDArray LesserEqual(float lhs, NDArray rhs)
        {
            // Expr
            return /* _ufunc_helper expanded */ _internal._greaterEqualScalar(rhs, lhs);
        }
    }
    
    public static partial class Helper
    {
        public static float LesserEqual(float lhs, float rhs)
        {
            // Expr
            return /* _ufunc_helper expanded */ (IsTrue((lhs <= rhs)) ? 1 : 0);
        }
    }
    
    public static partial class Helper
    {
        public static NDArray LogicalAnd(NDArray lhs, NDArray rhs)
        {
            // Expr
            return /* _ufunc_helper expanded */ Op.BroadcastLogicalAnd(lhs, rhs);
        }
    }
    
    public static partial class Helper
    {
        public static NDArray LogicalAnd(NDArray lhs, float rhs)
        {
            // Expr
            return /* _ufunc_helper expanded */ _internal._logicalAndScalar(lhs, rhs);
        }
    }
    
    public static partial class Helper
    {
        public static NDArray LogicalAnd(float lhs, NDArray rhs)
        {
            // Expr
            return /* _ufunc_helper expanded */ _internal._logicalAndScalar(rhs, lhs);
        }
    }
    
    public static partial class Helper
    {
        public static float LogicalAnd(float lhs, float rhs)
        {
            // Expr
            return /* _ufunc_helper expanded */ (IsTrue((IsTrue(lhs) && IsTrue(rhs))) ? 1 : 0);
        }
    }
    
    public static partial class Helper
    {
        public static NDArray LogicalOr(NDArray lhs, NDArray rhs)
        {
            // Expr
            return /* _ufunc_helper expanded */ Op.BroadcastLogicalOr(lhs, rhs);
        }
    }
    
    public static partial class Helper
    {
        public static NDArray LogicalOr(NDArray lhs, float rhs)
        {
            // Expr
            return /* _ufunc_helper expanded */ _internal._logicalOrScalar(lhs, rhs);
        }
    }
    
    public static partial class Helper
    {
        public static NDArray LogicalOr(float lhs, NDArray rhs)
        {
            // Expr
            return /* _ufunc_helper expanded */ _internal._logicalOrScalar(rhs, lhs);
        }
    }
    
    public static partial class Helper
    {
        public static float LogicalOr(float lhs, float rhs)
        {
            // Expr
            return /* _ufunc_helper expanded */ (IsTrue((IsTrue(lhs) || IsTrue(rhs))) ? 1 : 0);
        }
    }
    
    public static partial class Helper
    {
        public static NDArray LogicalXor(NDArray lhs, NDArray rhs)
        {
            // Expr
            return /* _ufunc_helper expanded */ Op.BroadcastLogicalXor(lhs, rhs);
        }
    }
    
    public static partial class Helper
    {
        public static NDArray LogicalXor(NDArray lhs, float rhs)
        {
            // Expr
            return /* _ufunc_helper expanded */ _internal._logicalXorScalar(lhs, rhs);
        }
    }
    
    public static partial class Helper
    {
        public static NDArray LogicalXor(float lhs, NDArray rhs)
        {
            // Expr
            return /* _ufunc_helper expanded */ _internal._logicalXorScalar(rhs, lhs);
        }
    }
    
    public static partial class Helper
    {
        public static float LogicalXor(float lhs, float rhs)
        {
            // Expr
            return /* _ufunc_helper expanded */ (IsTrue((Bool(lhs) ^ Bool(rhs))) ? 1 : 0);
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
                    InsertToSlice(ret, idx, BinOp.Add(idx, arr.Shape.Item1), null, arr);
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
    
    // Drop: histogram
    
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
            throw new ValueError("indices_or_sections must either int or tuple of ints");
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
