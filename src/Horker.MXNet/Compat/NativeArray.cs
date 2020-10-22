using System;
using System.Collections.Generic;
using System.Text;

namespace Horker.MXNet.Compat
{
    // compatibility code for Python array module

    public static class Array
    {
        public static (string, int) NativeArray(string typeCode, int size)
        {
            return (typeCode, size);
        }
    }
}
