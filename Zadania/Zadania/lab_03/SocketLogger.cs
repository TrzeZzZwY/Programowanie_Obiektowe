using System;
using System.Text;
using System.Runtime.InteropServices;
using Microsoft.Win32.SafeHandles;

namespace lab_03
{
    class SocketLogger : ILogger
    {
        private bool disposed = false;
        private ClientSocket ClientSocket;
        private SafeHandle _safeHandle = new SafeFileHandle(IntPtr.Zero, true);
        public SocketLogger(string host, int port)
        {
            ClientSocket = new ClientSocket(host, port);
        }
        ~SocketLogger()
        {
            Dispose(false);
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
        public  void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
        public void Log(params string[] messages)
        {
            foreach (var item in messages)
            {
                ClientSocket.Send(Encoding.UTF8.GetBytes(item));
                byte[] responseBuffer = new byte[1024];
            }
        }
    }
}
