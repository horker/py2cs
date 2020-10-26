using Horker.MXNet.Interop;
using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Text;
using Horker.MXNet.Compat;
using static Horker.MXNet.Compat.Array;
using System.Data.Common;
using System.Net;
using System.Linq;

namespace Horker.MXNet
{
    public static class Base
    {
        public static ValueTuple<Type, Type> IntegerTypes = (typeof(int), typeof(long));

        public static ValueTuple<Type, Type, Type, Type> NumericTypes = (typeof(float), typeof(int), typeof(long), typeof(double));

        // Defined in mxnet/base.py
        public static void CheckCall(int ret)
        {
            if (ret != 0)
                throw new ApplicationException(Marshal.PtrToStringAnsi(_LIB.MXGetLastError()));
        }

        public struct CArrayBufIntermediate
        {
            public Type Type { get; set; }
            public string TypeCode { get; set; }
            public int Size { get; set; }

            public CArrayBufIntermediate(Type type, string typeCode, int size)
            {
                Type = type;
                TypeCode = typeCode;
                Size = size;
            }

            public static implicit operator int[](CArrayBufIntermediate buf)
            {
                if (buf.Type != typeof(int) || buf.TypeCode != "I")
                    throw new ArgumentException("Attempt to produce an int array from non-int array");

                return new int[buf.Size];
            }

            public static implicit operator long[](CArrayBufIntermediate buf)
            {
                if (buf.Type != typeof(long) || buf.TypeCode != "Q")
                    throw new ArgumentException("Attempt to produce a long array from non-int array");

                return new long[buf.Size];
            }
        }

        public static CArrayBufIntermediate CArrayBuf(Type type, (string, int) nativeArrayResult)
        {
            return new CArrayBufIntermediate(type, nativeArrayResult.Item1, nativeArrayResult.Item2);
        }

        public static int[] CArray(Type type, int[] values) => values;

        public static IntPtr[] CHandleArray(IntPtr[] values) => values;
        public static IntPtr[] CHandleArray(IEnumerable<IntPtr> values) => values.ToArray();

        public static string CStr(string s) => s;

        public static string[] CStrArray(string[] s) => s;
        public static string[] CStrArray(IEnumerable<string> s) => s.ToArray();

        public static string PyStr(string s) => s;
    }
}
