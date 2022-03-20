using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab_2_zadanie
{
    internal class Product:IThing
    {
        private string name;
        public string Name { get =>name;}
        public Product(string name)
        {
            this.name = name;
        }
        public void Print(string prefix) => Console.WriteLine($"{prefix}{name}");
    }
}
