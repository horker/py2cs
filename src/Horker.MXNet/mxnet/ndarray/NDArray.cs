using System;
using System.Collections.Generic;
using System.Text;
using Horker.MXNet.Interop;
using static Horker.MXNet.Base;
using NDArrayHandle = System.IntPtr;

namespace Horker.MXNet
{
    public partial class NDArray : NDArrayBase
    {
        public NDArray()
        {
            CheckCall(_LIB.MXNDArrayCreateNone(out var @out));
            Handle = @out;
        }

        public NDArray(NDArrayHandle handle, bool writable = true)
            : base(handle, writable)
        { }

        public static implicit operator NDArray(float value)
        {
            throw new NotImplementedException();
        }
    }
}
