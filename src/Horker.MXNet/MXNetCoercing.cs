using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using Horker.MXNet;
using Horker.MXNet.Gluon;

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

        public static DType CoerceIntoDType(object obj)
        {
            return (DType)obj;
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
