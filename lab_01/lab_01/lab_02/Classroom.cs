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
        private Person[] presons;
        public string Name { get => name;}
        public Classroom(string name, Person[] pearsons)
        {
            this.presons = pearsons;
            this.name = name;
        }
        public override string ToString()
        {
            foreach (var item in presons)
            {
                return item.ToString();
            }
            return "\n";
        }

    }
}
