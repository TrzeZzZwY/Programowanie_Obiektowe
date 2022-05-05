using System;
using System.Collections.Generic;
using System.Linq;

namespace lab_6
{
    class Program
    {
        static void Main(string[] args)
        {
            List<User> users = new List<User>()
            {
                new User(){Name = "A", Role ="Admin", Marks = null,CreatedAt = new DateTime(year:2022,month:2,day:3) },
                new User(){Name = "E", Role ="Moderator", Marks = null,CreatedAt = new DateTime(year:2022,month:1,day:3),RemovedAt = new DateTime(year:2022,month:9,day:3)},
                new User(){Name = "F", Role ="Teacher", Marks = null,CreatedAt = new DateTime(year:2022,month:1,day:3),RemovedAt = new DateTime(year:2022,month:9,day:3)},
                new User(){Name = "G", Role ="Teacher", Marks = null,CreatedAt = new DateTime(year:2022,month:5,day:3)},
                new User(){Name = "M", Role ="Student", Marks = new int[]{4,3,4,5} ,CreatedAt = new DateTime(year:2022,month:4,day:3)},
                new User(){Name = "D", Role ="Moderator", Marks = null,CreatedAt = new DateTime(year:2022,month:2,day:3)},
                new User(){Name = "I", Role ="Teacher", Marks = null,CreatedAt = new DateTime(year:2022,month:6,day:3),RemovedAt = new DateTime(year:2022,month:9,day:3)},
                new User(){Name = "J", Role ="Student", Marks = new int[]{4,5,4,5},CreatedAt = new DateTime(year:2022,month:5,day:3)},
                new User(){Name = "L", Role ="Student", Marks = new int[]{2,3,3,2,3},CreatedAt = new DateTime(year:2022,month:4,day:3)},
                new User(){Name = "R", Role ="Student", Marks = new int[]{4,5,5,6,6},CreatedAt = new DateTime(year:2022,month:3,day:3),RemovedAt = new DateTime(year:2022,month:9,day:3)},
                new User(){Name = "N", Role ="Student", Marks = new int[]{5,3,2,5},CreatedAt = new DateTime(year:2022,month:4,day:3)},
                new User(){Name = "O", Role ="Student", Marks = new int[]{4,3,},CreatedAt = new DateTime(year:2022,month:3,day:3),RemovedAt = new DateTime(year:2022,month:9,day:3)},
                new User(){Name = "P", Role ="Student", Marks = new int[]{3,3,3,3},CreatedAt = new DateTime(year:2022,month:2,day:3)},
                new User(){Name = "Q", Role ="Student", Marks = new int[]{3,5},CreatedAt = new DateTime(year:2022,month:7,day:3)},
                new User(){Name = "H", Role ="Teacher", Marks = null,CreatedAt = new DateTime(year:2022,month:6,day:3)},
                new User(){Name = "B", Role ="Admin", Marks = null,CreatedAt = new DateTime(year:2022,month:6,day:3)},
                new User(){Name = "C", Role ="Moderator", Marks = null,CreatedAt = new DateTime(year:2022,month:4,day:3),RemovedAt = new DateTime(year:2022,month:9,day:3)},
                new User(){Name = "S", Role ="Student", Marks = new int[]{4,3,4,5},CreatedAt = new DateTime(year:2022,month:1,day:3)}
            };

            Console.WriteLine(users.Count());

            var names = users.Select(e => e.Name).ToList();
            Console.WriteLine("\n\n Zad 2");
            foreach (var item in names)
            {
                Console.WriteLine($"imie: {item}");
            }

            Console.WriteLine("\n\n Zad 3");
            var orderByName = users.OrderByDescending(e => e.Name).ToList();
            foreach (var item in orderByName)
            {
                Console.WriteLine($"imie: {item.Name}");
            }


            Console.WriteLine("\n\n Zad 4");
            var AllRoles = users.Select(e => e.Role).Distinct().ToList();
            foreach (var item in AllRoles)
            {
                Console.WriteLine($"Rola: {item}");
            }

            Console.WriteLine("\n\n Zad 5");
            var groupByRole = users.GroupBy(e => e.Role).ToList();
            foreach (var group in groupByRole)
            {
                foreach (var item in group.ToList())
                {
                    Console.WriteLine($"name: {item.Name}\t role: {item.Role}");
                }
            }

            Console.WriteLine("\n\n Zad 6");
            var recordsWithMarks = users.Count(e => e.Marks?.Length > 0);
            Console.WriteLine(recordsWithMarks);

            Console.WriteLine("\n\n Zad 7");
            var marsSum = users.Sum(e => e.Marks?.Sum());
            var marsCount = users.Sum(e => e.Marks?.Count());
            Console.WriteLine($"Suma: {marsSum}, Ilość ocen: {marsCount}, Średnia {(double)marsSum/marsCount:f3}");


            Console.WriteLine("\n\n Zad 8");

            var max = users.Max(e => e.Marks?.Max());
            Console.WriteLine($"max: {max}");

            Console.WriteLine("\n\n Zad 9");
            var min = users.Min(e => e.Marks?.Min());
            Console.WriteLine($"min: {min}");

            Console.WriteLine("\n\n Zad 10");
            var bestStudent = users.Where(e => e.Marks != null).OrderBy(e => (decimal)e.Marks?.Sum()/e.Marks?.Count()).Last();
            Console.WriteLine($"bestStudent: {bestStudent.Name}");

            Console.WriteLine("\n\n Zad 11");
            var minMarksCountStudents = users.Where(e => e.Marks != null).GroupBy(e => e.Marks.Count()).OrderBy(e => e.Key).First();
            foreach (var item in minMarksCountStudents)
            {

                Console.WriteLine($"imie: {item.Name} liczba ocen: {item.Marks.Length}");

            }
            Console.WriteLine("\n\n Zad 12");
            var maxMarksCountStudents = users.Where(e => e.Marks != null).GroupBy(e => e.Marks.Count()).OrderBy(e => e.Key).Last();
            foreach (var item in maxMarksCountStudents)
            {

                Console.WriteLine($"imie: {item.Name} liczba ocen: {item.Marks.Length}");

            }

            Console.WriteLine("\n\n Zad 13");
            var namesAndAvg = users.Where(e => e.Marks != null).Select(e => new { e.Name,avg = e.Marks.Average() }).ToList() ;

            foreach (var item in namesAndAvg)
            {
                Console.WriteLine($"nazwa: {item.Name}, średnia: {item.avg}");
            }
            Console.WriteLine("\n\n Zad 14");
            var bestStudentSort = users.Where(e => e.Marks != null).OrderByDescending(e => (decimal)e.Marks?.Average());
            foreach (var item in bestStudentSort)
            {
                Console.WriteLine($"Student: {item.Name}\t średnia: {item.Marks?.Average()}");
            }

            Console.WriteLine("\n\n Zad 15");
            var avarageOfAvarage = bestStudentSort.Average(e => e.Marks.Average());
            Console.WriteLine($"średnia średnich:{avarageOfAvarage:f3}");

            Console.WriteLine("\n\n Zad 16");
            var sortedByCreatedDate = users.GroupBy(e => e.CreatedAt.Value);
            foreach (var item in sortedByCreatedDate)
            {
                Console.WriteLine($"\n{item.Key.ToString("M")}");
                foreach (var item2 in item)
                {
                    Console.Write($"{item2.Name}, ");
                }
                
            }
            Console.WriteLine("\n\n Zad 17");
            var notRemoved = users.Where(e => e.RemovedAt is not null);
            foreach (var item in notRemoved)
            {
                Console.WriteLine(item.Name);
            }

            Console.WriteLine("\n\n Zad 18");
            var newest = users.Select(e => e).Where(e => e.CreatedAt == users.Max(e => e.CreatedAt));
            foreach (var item in newest)
            {
                Console.WriteLine($"{item.Name} {item.CreatedAt.Value.ToString("D")}");
            }

        }
    }
}
