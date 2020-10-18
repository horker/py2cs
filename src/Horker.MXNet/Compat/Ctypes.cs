using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Runtime.CompilerServices;
using System.Text;

namespace Horker.MXNet.Compat
{
    public struct Ctype<T>
    {
        public T Value { get; set; }

        public Ctype(T value)
        {
            Value = value;
        }

        public Ctype(object value)
        {
            Value = (T)value;
        }

        public static implicit operator T(Ctype<T> ctype)
        {
            return ctype.Value;
        }

        public static implicit operator Ctype<T>(T value)
        {
            return new Ctype<T>(value);
        }
    }

    public static class Ctypes
    {
        public static int CInt() => default;
        public static int CInt(object obj) => (int)obj;

        public static long CInt64() => default;
        public static long CInt64(object obj) => (long)obj;

        public static long CUint64() => default;
        public static long CUint64(object obj) => (long)obj;
    }
}
