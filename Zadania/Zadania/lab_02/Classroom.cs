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
        private Person[] persons;

        public string Name { get => name;}
        public Classroom(string name, Person[] persons)
        {
            this.persons = persons;
            this.name = name;
        }
        public void Test()
        {
            foreach (var item in persons)
            {
                Console.WriteLine("dupa");
            }
        }
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"Classroom: {name}\n");
            foreach (var item in persons)
            {
                sb.AppendLine(item.ToString());
                if (item is Student)               
                    sb.AppendLine(((Student)item).RenderTasks());
                
            }
            return sb.ToString();
        }

    }
}
