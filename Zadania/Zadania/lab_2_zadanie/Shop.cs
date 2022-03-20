using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab_2_zadanie
{
    internal class Shop : IThing
    {
        private string name;
        public string Name { get => name; }
        private Person[] people;
        private Product[] products;
        public Shop(string name, Person[] people, Product[] products)
        {
            this.name = name;
            this.people = people;
            this.products = products;
        }

        public void Print() => Console.WriteLine("shop");
    }
}
