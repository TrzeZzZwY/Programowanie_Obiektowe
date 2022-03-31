using System;
using System.IO;
using System.Runtime.InteropServices;
using Microsoft.Win32.SafeHandles;
using System.Text;

namespace lab_03
{
    class FileLogger : WriterLogger
    {
        private bool disposed = false;
        protected FileStream stream;
        private SafeHandle _safeHandle = new SafeFileHandle(IntPtr.Zero, true);
        private string path;
        public FileLogger(string path)
        {
            this.path = path;
            stream = new FileStream(path, FileMode.Append);
            writer = new StreamWriter(stream, Encoding.UTF8);
        }

        ~FileLogger()
        {
            Dispose(false);
        }
        public  void Dispose(bool disposing)
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
        public override void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
