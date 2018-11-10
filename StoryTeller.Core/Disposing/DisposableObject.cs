using Microsoft.Win32.SafeHandles;
using System;
using System.Runtime.InteropServices;

namespace StoryTeller.Core.Disposing
{
    public abstract class DisposableObject : IDisposableObject
    {
        protected bool isDisposed { get; private set; }
        protected SafeHandle safeHandle = new SafeFileHandle(IntPtr.Zero, true);

        protected abstract void ReleaseResources();

        protected void Dispose(bool disposing)
        {
            if (isDisposed)
                return;

            if (disposing)
            {
                ReleaseResources();
            }
            safeHandle.Close();
            safeHandle.Dispose();

            isDisposed = true;
        }

        ~DisposableObject()
        {
            Dispose(false);
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
