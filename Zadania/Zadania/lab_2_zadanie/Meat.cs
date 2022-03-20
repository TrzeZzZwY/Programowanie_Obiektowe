using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab_2_zadanie
{
    internal class Meat:Product
    {
        private double weight;
        public double Weight { get => weight; }
        public Meat(string name, double weight) : base(name)
        {
            this.weight = weight;
        }
        public void Print(string prefix) => Console.WriteLine($"{prefix}{Name} {Weight}");
    }
}
