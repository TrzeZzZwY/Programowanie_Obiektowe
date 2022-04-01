using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab_03
{
    class ConsoleLogger : WriterLogger
    {
        public ConsoleLogger()
        {
            writer = Console.Out;
        }

        public override void Dispose()
        {
            //tutaj nie powinno być nic 
        }
    }
}
