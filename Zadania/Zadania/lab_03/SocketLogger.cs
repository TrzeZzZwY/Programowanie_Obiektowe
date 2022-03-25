using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab_03
{
    class SocketLogger : ILogger
    {
        private ClientSocket ClientSocket;

        public SocketLogger(string host, int port)
        {

        }
        ~SocketLogger()
        {
           
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }

        public void Log(params string[] messages)
        {
            throw new NotImplementedException();
        }
    }
}
