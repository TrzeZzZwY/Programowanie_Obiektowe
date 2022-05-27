using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Threading;
using System.Threading.Tasks;

namespace lab_8
{


    public class Program
    {
        static volatile bool looped = true;
        public static void Main(string[] args)
        {
            /*
            SortedSet<int> set = new SortedSet<int>();
            Thread prime1 = new Thread(() =>
            {
                for (int i = 0; looped; i += 4)
                    if (isPrime(i))
                        lock (set)
                            set.Add(i);
            });
            Thread prime2 = new Thread(() =>
            {
                for (int i = 1; looped; i += 4)
                    if (isPrime(i))
                        lock (set)
                            set.Add(i);
            });
            Thread prime3 = new Thread(() =>
            {
                for (int i = 2; looped; i += 4)
                    if (isPrime(i))
                        lock (set)
                            set.Add(i);
            });
            Thread prime4 = new Thread(() =>
            {
                for (int i = 3; looped; i += 4)
                    if (isPrime(i))
                        lock (set)
                            set.Add(i);
            });
            prime1.Start();
            prime2.Start();
            prime3.Start();
            prime4.Start();
            Thread.Sleep(10000);
            looped = false;
            prime1.Join();
            prime2.Join();
            prime3.Join();
            prime4.Join();
            Console.WriteLine(set.Count);
            */
            Task tast = DoTasks();
            tast.Wait();

            /*
            Thread thread = new Thread(() =>
            {
                for (int i = 1; i <= 5; ++i)
                {
                    Console.WriteLine("Iteration: " + i);
                    Thread.Sleep(1000); // sleeps created thread for 1 second
                }
            });
            thread.Name = "pierwszy";
            Thread thread2 = new Thread(() =>
            {
                for (int i = 1; looped; ++i)
                {
                    Console.WriteLine("Iteration: " + i);
                    Thread.Sleep(1000); // sleeps created thread for 1 second
                }

            });
            thread2.Name = "drugi";
            thread.Start();
            thread2.Start();
            Thread.Sleep(2000);
            looped = false;

            thread.Join();
            Console.WriteLine("test");
            */
        }
        static bool isPrime(int number)
        {
            if (number < 2) return false;
            if (number == 2 || number == 3) return true;
            if (number % 2 == 0) return false;
            if (number % 3 == 0) return false;
            var limit = Math.Floor(Math.Sqrt(number));
            for (int i = 5, d = 4; i < limit; i += d)
            {
                if (number % i == 0)
                    return false;
                d = 6 - d;
            }
            return true;
        }
        private static async Task DoTasks()
        {
            Stopwatch s = Stopwatch.StartNew();
            int couter = 0; ;
            SortedSet<int> set = new SortedSet<int>();

            for (int i = 0; s.ElapsedMilliseconds < 10000; i += 4)
            {
                Task<bool> task1 = DoTask(i + 0);
                Task<bool> task2 = DoTask(i + 1);
                Task<bool> task3 = DoTask(i + 2);
                Task<bool> task4 = DoTask(i + 3);
                if (await task1) set.Add(i + 0);
                if (await task2) set.Add(i + 1);
                if (await task3) set.Add(i + 2);
                if (await task4) set.Add(i + 3);
            }
            Console.WriteLine(set.Count);

        }
        private static async Task<bool> DoTask(int numb)
        {
            return await Task<bool>.Run(() =>
            {
                return isPrime(numb);
            });
        }
    }
}
