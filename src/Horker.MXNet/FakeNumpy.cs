using System;
using System.Collections.Generic;
using System.Text;

namespace Horker.MXNet
{
    public class Np
    {
        public static readonly DType Float32 = MXNet.DType.Float32;
        public static readonly DType Float64 = MXNet.DType.Float64;
        public static readonly DType Float16 = MXNet.DType.Float16;
        public static readonly DType UInt8 = MXNet.DType.UInt8;
        public static readonly DType Int32 = MXNet.DType.Int32;
        public static readonly DType Int8 = MXNet.DType.Int8;
        public static readonly DType Int64 = MXNet.DType.Int64;

        public static DType DType(string name)
        {
            return MXNet.DType.Get(name);
        }

        public static DType DType(DType type)
        {
            return type;
        }

        public class NDArray
        { }
    }
}
