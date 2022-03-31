using System;
using System.Runtime.InteropServices;
using Microsoft.Win32.SafeHandles;

namespace lab_03
{
    class CommonLogger : ILogger
    {
        private ILogger[] loggers;
        private SafeHandle _safeHandle = new SafeFileHandle(IntPtr.Zero, true);
        private bool disposed = false;
        public CommonLogger(ILogger[] loggers)
        {
            this.loggers = loggers;
        }

        public void Dispose(bool disposing)
        {
            if (!disposed)
            {
                if (disposing)
                {
                    _safeHandle.Dispose();
                }

                disposed = true;
            }
        }
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        public void Log(params string[] messages)
        {
            foreach (var log in loggers)            
                    log.Log(messages);


        }
    }
}
