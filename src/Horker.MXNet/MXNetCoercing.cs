using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using Horker.MXNet;
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

        public static NDArrayHandle CoerceIntoNDArrayHandle(NDArrayHandle handle)
        {
            return handle;
        }

        public static NDArrayHandle[] CoerceIntoNDArrayHandleArray(NDArrayHandle[] handles)
        {
            return handles;
        }

        public static ParameterDict CoerceIntoParameterDict(object obj)
        {
            return (ParameterDict)obj;
        }

        public static Shape CoerceIntoShape(Shape s)
        {
            return s;
        }

        public static Shape CoerceIntoShape(params int[] d)
        {
            return new Shape(d);
        }
    }
}
