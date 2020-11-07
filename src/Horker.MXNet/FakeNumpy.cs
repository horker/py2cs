using Horker.MXNet.Compat;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
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
            public float[] Data { get; private set; }

            public float Item1 => (float)Data.GetValue(0);
            public float Item2 => (float)Data.GetValue(1);
            public float Item3 => (float)Data.GetValue(2);
            public float Item4 => (float)Data.GetValue(3);
            public float Item5 => (float)Data.GetValue(4);
            public float Item6 => (float)Data.GetValue(5);

            public NDArray(float[] data)
            {
                Data = data;

                var shape = new int[data.Rank];
                for (var i = 0; i < data.Rank; ++i)
                    shape[i] = data.GetLength(i);

                Shape = shape;
            }

            public int Size => Shape.Size;
            public NDArrayCTypesUtils CTypes => new NDArrayCTypesUtils(this);

            public static implicit operator float[](NDArray array)
            {
                var result = new float[array.Size];
                array.Data.CopyTo(result, 0);
                return result;
            }
        }

        public static NDArray Empty(Shape shape, DType dtype)
        {
            return new NDArray((float[])System.Array.CreateInstance(dtype, (int[])shape));
        }

        public static int Prod(IEnumerable<int> ndarray)
        {
            return ndarray.Aggregate(1, (x, sum) => x * sum);
        }

        public static NDArray Asarray(float[] array, DType dtype, string order = "C")
        {
            if (dtype.Type != MXNet.DType.Float32)
                throw new ArgumentException("dtype mismatch");

            if (order != "C")
                throw new NotImplementedException("Orders other than C are not implemented");

            return new NDArray(array);
        }

        public class NDArrayCTypesUtils
        {
            private NDArray _instance;
            public NDArrayCTypesUtils(NDArray instance)
            {
                _instance = instance;
            }

            public float[] DataAs(Func<IntPtr> f)
            {
                return _instance.Data;
            }
        }
    }
}
