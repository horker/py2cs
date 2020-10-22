using System;
using Horker.MXNet.Interop;

using NDArrayHandle = System.IntPtr;

namespace Horker.MXNet
{
    // Defined in mxnet/_ctypes/ndarray.py
    public partial class NDArrayBase : DisposableObject
    {
        public NDArrayHandle Handle { get; private set; }
        public bool Writable { get; private set; }

        internal NDArrayBase(NDArrayHandle handle, bool writable = true)
        {
            if (handle == NDArrayHandle.Zero)
                throw new ArgumentException("Handle must not be zero");

            Handle = handle;
            Writable = writable;
        }

        protected override void DisposeUnmanaged()
        {
            base.DisposeUnmanaged();
            LIB.MXNDArrayFree(Handle);
            Handle = NDArrayHandle.Zero;
        }
    }
}