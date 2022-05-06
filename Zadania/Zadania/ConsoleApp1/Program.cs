using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.Linq;


namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            // Uwaga: zmień `DESKTOP-123ABC\SQLEXPRESS` na nazwę swojego serwera.

            string connectionString = @"Data Source=PK1-18;Initial Catalog=gr8;Integrated Security=True";



            while (true)
            {
                Console.Clear();
                Console.WriteLine("1-wypisz użytkowników z bazy");
                Console.WriteLine("2-dodawanie nowych użytkowników");
                Console.WriteLine("3-edytowanie istniejących użytkowników po id");
                Console.WriteLine("4-usuwanie istniejących użytkowników po id");
                Console.WriteLine("\n\n");
                var number = int.Parse(Console.ReadLine());
                switch (number)
                {
                    case 1:
                        ReadAll(connectionString);
                        Console.ReadKey();
                        break;
                    case 2:
                        Console.WriteLine("podaj {imie},{rola},{data utworzenia},{data usunięcia}");
                        var text = Console.ReadLine().Split(',');
                        UserEntity user = new UserEntity() {Name = text[0], Role = text[1], CreatedAt = null, RemovedAt = null };
                        AddNew(connectionString, user);
                        Console.ReadKey();
                        break;
                    case 3:
                        Console.WriteLine("podaj {imie},{rola},{data utworzenia},{data usunięcia}");
                        var text2 = Console.ReadLine().Split(',');
                        Console.WriteLine("podaj id");
                        var id2 = int.Parse(Console.ReadLine());
                        UserEntity user2 = new UserEntity() { Name = text2[0], Role = text2[1], CreatedAt = null, RemovedAt = null };
                        EditWhere(connectionString,id2,user2);
                        Console.ReadKey();
                        break;
                    case 4:
                        Console.WriteLine("podaj id");
                        var id = int.Parse(Console.ReadLine());
                        DeleteWhere(connectionString,id);
                        break;
                    default:
                        Console.WriteLine("podano złą warość");
                        Console.ReadKey();
                        break;
                }
            }



        }
        static void ReadAll(string connectionString)
        {
            using (DataContext dataContext = new DataContext(connectionString))
            {
                Table<UserEntity> users = dataContext.GetTable<UserEntity>();

                IQueryable<UserEntity> query = from user in users
                                               where user.RemovedAt.HasValue == false // user.RemovedAt == null
                                               select user;

                foreach (UserEntity user in query)
                    Console.WriteLine("{0} {1}", user.Id, user.Name);
            }
        }
        static void AddNew(string connectionString, UserEntity o)
        {
            using (DataContext dataContext = new DataContext(connectionString))
            {
                Table<UserEntity> users = dataContext.GetTable<UserEntity>();
                users.InsertOnSubmit(o);
                dataContext.SubmitChanges();
            }
        }
        static void DeleteWhere(string connectionString, int id)
        {
            using (DataContext dataContext = new DataContext(connectionString))
            {
                Table<UserEntity> users = dataContext.GetTable<UserEntity>();
                var d = from user in users
                        where user.Id == id
                        select user;
                if (d.Count() > 0)
                {
                    users.DeleteOnSubmit(d.First());
                    dataContext.SubmitChanges();
                }
            }
        }
        static void EditWhere(string connectionString, int id, UserEntity o)
        {
            using (DataContext dataContext = new DataContext(connectionString))
            {
                Table<UserEntity> users = dataContext.GetTable<UserEntity>();
                var d = from user in users
                        where user.Id == id
                        select user;
                foreach (var item in d)
                {
                    if(item.Id == id)
                    {
                        item.Name = o.Name;
                        item.Role = o.Role;
                        item.CreatedAt = o.CreatedAt;
                        item.RemovedAt = o.RemovedAt;
                    }
                }
                dataContext.SubmitChanges();
            }
        }
    }
}
