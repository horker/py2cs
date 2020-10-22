﻿using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Runtime.CompilerServices;
using System.Text;

namespace Horker.MXNet.Compat
{
    public static class CTypes
    {
        public static int CInt() => default;
        public static int CInt(int obj) => obj;
        public static int CInt(object obj) => (int)obj;

        public static long CInt64() => default;
        public static long CInt64(long obj) => obj;
        public static long CInt64(object obj) => (long)obj;

        public static long CUint64() => default;
        public static long CUint64(long obj) => obj;
        public static long CUint64(object obj) => (long)obj;

        public static bool CBool() => default;
        public static bool CBool(bool obj) => obj;
        public static bool CBool(int obj) => obj != 0;
        public static bool CBool(object obj) => (bool)obj;
    }
}
