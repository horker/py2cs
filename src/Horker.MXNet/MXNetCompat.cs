﻿using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Runtime.InteropServices.ComTypes;
using System.Text;

namespace Horker.MXNet
{
    public static class MXNetCompat
    {
        // Defined in mxnet/base.py
        public static void CheckCall(int ret)
        {
            if (ret != 0)
                throw new ApplicationException(Marshal.PtrToStringAnsi(LIB.MXGetLastError()));
        }

        public static string Format(this string format, object arg0 = null, object arg1 = null, object arg2 = null, object arg3 = null, object arg4 = null, object arg5 = null, object arg6 = null, object arg7 = null, object arg8 = null, object arg9 = null, object name = null, object shape = null, object dtype = null)
        {
            // TODO
            return format;
        }

        public static int Len(Shape shape)
        {
            return shape.Length;
        }
    }
}
