using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab_03
{
    class CommonLogger : ILogger
    {
        private ILogger[] loggers;
        public CommonLogger(ILogger[] loggers)
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
