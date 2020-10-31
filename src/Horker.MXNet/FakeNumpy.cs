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
        {
            public Shape Shape { get; private set; }
            public Array Data { get; private set; }

            public float Item1 => (float)Data.GetValue(0);
            public float Item2 => (float)Data.GetValue(1);
            public float Item3 => (float)Data.GetValue(2);
            public float Item4 => (float)Data.GetValue(3);
            public float Item5 => (float)Data.GetValue(4);
            public float Item6 => (float)Data.GetValue(5);

            public NDArray(Array data)
            {
                Data = data;

                var shape = new int[data.Rank];
                for (var i = 0; i < data.Rank; ++i)
                    shape[i] = data.GetLength(i);

                Shape = shape;
            }
        }

        public static NDArray Empty(Shape shape, DType dtype)
        {
            return new NDArray(Array.CreateInstance(dtype, (int[])shape));
        }
    }
}
