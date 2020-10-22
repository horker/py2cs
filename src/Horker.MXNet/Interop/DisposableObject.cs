/*****************************************************************************
   Copyright 2018 The MxNet.Sharp Authors. All Rights Reserved.

   Licensed under the Apache License, Version 2.0 (the "License");
   you may not use this file except in compliance with the License.
   You may obtain a copy of the License at

       http://www.apache.org/licenses/LICENSE-2.0

   Unless required by applicable law or agreed to in writing, software
   distributed under the License is distributed on an "AS IS" BASIS,
   WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
   See the License for the specific language governing permissions and
   limitations under the License.
******************************************************************************/
using System;

namespace Horker.MXNet.Interop
{
    public abstract class DisposableObject : IDisposable
    {
        protected DisposableObject()
        {
            IsDisposed = false;
        }

        public bool IsDisposed { get; private set; }

        public void ThrowIfDisposed()
        {
            if (IsDisposed)
                throw new ObjectDisposedException(GetType().FullName);
        }

        protected virtual void DisposeManaged()
        { }

        protected virtual void DisposeUnmanaged()
        { }

        public void Dispose()
        {
            GC.SuppressFinalize(this);
            Dispose(true);
        }

        private void Dispose(bool disposing)
        {
            if (IsDisposed) return;

            IsDisposed = true;

            if (disposing)
                DisposeManaged();

            DisposeUnmanaged();
        }
    }
}