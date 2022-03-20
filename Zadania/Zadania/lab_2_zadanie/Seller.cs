using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab_2_zadanie
{
    internal class Seller : Person
    {
        public Seller(string name, int age) : base(name, age)
        {

        }
        public void Print(string prefix) => Console.WriteLine($"{prefix}Seller: {Name} {Age}");
    }
}
