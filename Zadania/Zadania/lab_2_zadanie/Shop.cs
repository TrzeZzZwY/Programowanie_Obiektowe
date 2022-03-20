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

        public void Print()
        {
            Console.WriteLine($"Shop: {name}");
            Console.WriteLine("-- People: --");
            foreach (var item in people)
            {
                if(item is Buyer)
                    ((Buyer)item).Print("\t");
                if (item is Seller)
                    ((Seller)item).Print("\t");
            }
            Console.WriteLine("-- Products: --");
            foreach (var item in products)
            {
                if (item is Fruit)
                    ((Fruit)item).Print("\t");
                if (item is Meat)
                    ((Meat)item).Print("\t");
            }
        }
    }
}
