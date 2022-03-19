using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab_02
{
    public class Classroom
    {
        private string name;
        private Person[] pearsons;
        public string Name { get => name;}
        public Classroom(string name, Person[] pearsons)
        {
            this.pearsons = pearsons;
            this.name = name;
        }
        public void Test()
        {
            foreach (var item in pearsons)
            {
                Console.WriteLine("dupa");
            }
        }
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"Classroom: {name}\n");
            foreach (var item in pearsons)
            {
                sb.AppendLine(item.ToString());
                if (item is Student)               
                    sb.AppendLine(((Student)item).RenderTasks());
                
            }
            return sb.ToString();
        }

    }
}
