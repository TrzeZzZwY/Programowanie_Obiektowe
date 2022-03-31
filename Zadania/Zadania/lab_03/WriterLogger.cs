using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab_03
{
    public abstract class WriterLogger : ILogger
    {
        protected TextWriter writer;

        public virtual void Log(params string[] messages)
        {
            string output = "";
            output += $"{DateTime.Now.ToString("yyyy-MM-ddTHH:mm:sszzz")} ";
            foreach (var item in messages)
            {
                output += $"{item} ";
            }
            writer.Write(output);
            writer.WriteLine();
            writer.Flush();
        }

        public abstract void Dispose();

    }
}
