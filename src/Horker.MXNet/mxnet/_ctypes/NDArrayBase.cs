using System;
using Horker.MXNet.Interop;

using NDArrayHandle = System.IntPtr;

namespace Horker.MXNet
{
    // Defined in mxnet/_ctypes/ndarray.py
    public partial class NDArrayBase : NDArrayOrSymbol
    {
        public NDArrayHandle Handle { get; protected set; }
        public bool Writable { get; protected set; }

        internal NDArrayBase(NDArrayHandle handle, bool writable = true)
        {
            if (handle == NDArrayHandle.Zero)
                throw new ArgumentException("Handle must not be zero");

            Handle = handle;
            Writable = writable;
        }

        internal NDArrayBase()
            : this(IntPtr.Zero, false)
        { }

        protected override void DisposeUnmanaged()
        {
            base.DisposeUnmanaged();
            _LIB.MXNDArrayFree(Handle);
            Handle = NDArrayHandle.Zero;
        }
    }
}