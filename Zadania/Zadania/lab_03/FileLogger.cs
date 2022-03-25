using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab_03
{
    class FileLogger : WriterLogger
    {
        private bool disposed = false;
        protected FileStream stream;
        public FileLogger(string path)
        {        
        }
        ~FileLogger()
        {
            Dispose(false);
        }
        public override void Dispose(bool disposing)
        {
            if (disposed)
                return;

            if (disposing)
            {
                // Free any other managed objects here.
                //
            }

            // Free any unmanaged objects here.
            //
            disposed = true;
        }
    }
}
