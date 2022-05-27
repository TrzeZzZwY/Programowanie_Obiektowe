using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace lab_8
{


    public class Program
    {
        static volatile bool looped = true;
        public static void Main(string[] args)
        {
            SortedSet<int> set = new SortedSet<int>();
            Thread prime1 = new Thread(() =>
            {
                for (int i = 0; looped; i += 5)
                    if (isPrime(i))
                        lock (set)
                            set.Add(i);
            });
            Thread prime2 = new Thread(() =>
            {
                for (int i = 1; looped; i += 5)
                    if (isPrime(i))
                        lock (set)
                            set.Add(i);
            });
            Thread prime3 = new Thread(() =>
            {
                for (int i = 2; looped; i += 5)
                    if (isPrime(i))
                        lock (set)
                            set.Add(i);
            });
            Thread prime4 = new Thread(() =>
            {
                for (int i = 3; looped; i += 5)
                    if (isPrime(i))
                        lock (set)
                            set.Add(i);
            });
            Thread prime5 = new Thread(() =>
            {
                for (int i = 4; looped; i += 5)
                    if (isPrime(i))
                        lock (set)
                            set.Add(i);
            });
            prime1.Start();
            prime2.Start();
            prime3.Start();
            prime4.Start();
            prime5.Start();
            Thread.Sleep(10000);
            looped = false;
            prime1.Join();
            prime2.Join();
            prime3.Join();
            prime4.Join();
            prime5.Join();
            Console.WriteLine(set.Count);

            //Task tast = DoTasks();
            //tast.Wait();

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
            int couter = 0; ;
            SortedSet<int> set = new SortedSet<int>();
            Task<bool> task1 = DoTask(0, set);
            Task<bool> task2 = DoTask(1, set);
            Task<bool> task3 = DoTask(2, set);
            Task<bool> task4 = DoTask(3, set);
            if (await task1) couter += 1;
            if (await task2) couter += 1;
            if (await task3) couter += 1;
            if (await task4) couter += 1;
            Thread.Sleep(10000);
            looped = false;
            Console.WriteLine("Tasks done: " + couter);
            Console.WriteLine(set.Count);

        }
        private static async Task<bool> DoTask(int taskId, SortedSet<int> set)
        {
            return await Task<bool>.Run(() =>
            {
                for (int i = taskId; looped; i += 4)
                    if (isPrime(i))
                        lock (set)
                            set.Add(i);

                return true;
            });
        }
    }
}
