using System;

namespace lab_5_zad
{
    internal class Program
    {
        static void Main(string[] args)
        {
            ObservableList1<string> ol1 = new ObservableList1<string>();


            EventHandler<ChangedEventArgs<string>> tt = (object sender, ChangedEventArgs<string> e) =>
            {
                Console.WriteLine("dodano wartość do listy: " + e.value);
            };



            ol1.Added += (object sender, ChangedEventArgs<string> e) =>
            {
                Console.WriteLine("dodano wartość do listy: " + e.value);
            };
            ol1.Updated += (object sender, ChangedEventArgs<string> e) =>
            {
                Console.WriteLine("zmieniono wartość w liście: " + e.value);
            };
            ol1.Removed += (object sender, ChangedEventArgs<string> e) =>
            {
                Console.WriteLine("usunięto wartość do listy: " + e.value);
            };

            ol1.Added += test;


            ol1.Add("Paulina");
            ol1.Add("Jasiek");

            ol1.Added -= test;
            ol1.Add("Ania");
            ol1.Add("Daniel");
            Console.WriteLine(ol1[1]);
            ol1.RemoveAt(3);
            ol1[2] = "Zuza";
            Console.WriteLine();




            Console.WriteLine("\n\n----------\n\n\n");


            ObservableList2<string> ol2 = new ObservableList2<string>(
                (string value) =>
                {
                    Console.WriteLine($"dodano do listy: {value}");
                },
                (string value, int index) =>
                {
                    Console.WriteLine($"zmieniono wartość w list[{index}] na : {value}");
                },
                (int index) =>
                {
                    Console.WriteLine($"usunięto wartość w list[{index}]");
                });

            ol2.Add("Paulina");
            ol2.Add("Jasiek");
            ol2.Add("Ania");
            ol2.Add("Daniel");
            Console.WriteLine(ol2[1]);
            ol2.RemoveAt(3);
            ol2[2] = "Zuza";
            Console.WriteLine();

            Console.WriteLine("\n\n----------\n\n\n");


            ObservableList3<string> ol3 = new ObservableList3<string>();
            ol3.callback1 = (string value) =>
            {
                Console.WriteLine($"TEST dodano do listy: {value}");
            };
            ol3.callback2 = (string value, int index) =>
            {
                Console.WriteLine($"TEST zmieniono wartość w list[{index}] na : {value}");
            };

            ol3.callback3 = (int index) =>
            {
                Console.WriteLine($"TEST usunięto wartość w list[{index}]");
            };
            ol3.Add("Paulina");
            ol3.Add("Jasiek");
            ol3.Add("Ania");
            ol3.Add("Daniel");
            Console.WriteLine(ol3[1]);
            ol3.RemoveAt(3);
            ol3[2] = "Zuza";
            Console.WriteLine();
        }

        static void test(object sender, ChangedEventArgs<string> e)
        {
            Console.WriteLine("test");
        }


    }
}
