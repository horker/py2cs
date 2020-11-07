using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using Horker.MXNet;
using Horker.MXNet.Compat;
using Horker.MXNet.Gluon;
using NDArrayHandle = System.IntPtr;

namespace Horker.MXNet
{
    public static class MXNetCoercing
    {
        public static Block CoerceIntoBlock(object obj)
        {
            return (Block)obj;
        }

        public static BlockScope CoerceIntoBlockScope(object obj)
        {
            return (BlockScope)obj;
        }

        public static MXNet.Context CoerceIntoContext(object obj)
        {
            return (MXNet.Context)obj;
        }

        public static DType CoerceIntoDType(object obj)
        {
            return (DType)obj;
        }

        public static NDArray CoerceIntoNDArray(NDArray ndarray)
        {
            return ndarray;
        }

        public static NDArrayHandle CoerceIntoNDArrayHandle(NDArrayHandle handle)
        {
            return handle;
        }

        public static NDArrayHandle[] CoerceIntoNDArrayHandleArray(NDArrayHandle[] handles)
        {
            return handles;
        }

        public static Np.NDArray CoerceIntoNpNDArray(Np.NDArray array)
        {
            return array;
        }

        public static Slice CoerceIntoPySlice(Slice value)
        {
            return value;
        }

        public static Slice CoerceIntoPySlice(ValueTuple<Slice> value)
        {
            return value.Item1;
        }

        public static ParameterDict CoerceIntoParameterDict(object obj)
        {
            return (ParameterDict)obj;
        }

        public static Shape CoerceIntoShape(params int[] d)
        {
            return new Shape(d);
        }

        public static Shape CoerceIntoShape(object value)
        {
            if (value != null)
                throw new ArgumentException("non-null value can not be accepted");
            return new Shape();
        }
    }
}
