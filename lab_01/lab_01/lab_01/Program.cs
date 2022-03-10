using System;
using System.Collections.Generic;
namespace lab_01
{
    class Program
    {
        //https://dirask.com/posts/WSEI-2021-2022-lato-labN-1-ISN-Programowanie-obiektowe-lab-1-pa3ek1
        static void Main(string[] args)
        {
            Ułamek a = new Ułamek(1, 2);
            Ułamek b = new Ułamek(3, 2);

            //Console.WriteLine(a + b);
            //Console.WriteLine(a - b);
            //Console.WriteLine(a * b);
            //Console.WriteLine(a / b);

            Ułamek c = new Ułamek(5, 2);
            Ułamek d = new Ułamek(6, 2);
            Ułamek e = new Ułamek(6, 2);
            Ułamek f = new Ułamek(2, 2);
            Ułamek g = new Ułamek(-1, 2);


            Console.WriteLine(a.CompareTo(g));



            List<Ułamek> lista = new List<Ułamek>() {a,b,c,d,e,f,g};
            Console.WriteLine("przed sortem");
            foreach (var item in lista)
            {
                Console.WriteLine(item);
            }
            lista.Sort();
            Console.WriteLine("\npo sorcie");
            foreach (var item in lista)
            {
                Console.WriteLine(item);
            }

            Console.WriteLine("\nZaokrągl w dół");
            Console.WriteLine(c.RoundDown());
            Console.WriteLine("\nZaokrągl w górę");
            Console.WriteLine(c.RoundUp());
        }
    }
}
