using System;
using System.Collections.Generic;
using System.Text;
using NDArrayHandle = System.IntPtr;

namespace Horker.MXNet
{
    public partial class NDArray : NDArrayBase
    {
        public NDArray(NDArrayHandle handle, bool writable = true)
            : base(handle, writable)
        { }
    }
}
