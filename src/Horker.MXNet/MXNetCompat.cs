﻿using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Runtime.InteropServices;
using System.Runtime.InteropServices.ComTypes;
using System.Text;
using System.Threading;

namespace Horker.MXNet
{
    public static class MXNetCompat
    {
        public static string Format(this string format, object arg0 = null, object arg1 = null, object arg2 = null, object arg3 = null, object arg4 = null, object arg5 = null, object arg6 = null, object arg7 = null, object arg8 = null, object arg9 = null, object name = null, object shape = null, object dtype = null)
        {
            // TODO
            return format;
        }

        public static IntPtr GetHandle(this NDArray self) => self.Handle;

        public static ThreadLocal<T> GetValue<T>(this ThreadLocal<T> self) => self;

        public static void InsertToSlice(NDArray lhs, int? lower, int? upper, int? step, NDArray rhs)
        {
            throw new NotImplementedException();
        }

        public static void InsertToSlice(NDArray lhs, int? lower, int? upper, int? step, float rhs)
        {
            throw new NotImplementedException();
        }

        public static bool IsNone(DType dtype)
        {
            // In our implementation DType is struct and never becomes null.
            return false;
        }

        public static int Len(NDArrayList list) => list.Count;
        public static int Len(SymbolList list) => list.Count;

        public static List<int> List(Shape shape)
        {
            return new List<int>(shape.Dimensions);
        }

        public static int MxInt() => default;
        public static int MxInt(int value) => value;
        public static int MxInt(uint value) => (int)value;

        // uint is not useful; We will use int instead.
        public static int MxUint() => default;
        public static int MxUint(uint value) => (int)value;
        public static int MxUint(int value) => (int)value;
    }
}
