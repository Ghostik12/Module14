using System;
using System.Linq;
using System.Runtime.InteropServices;

namespace Module14
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Student> students = new List<Student>
            {
                 new Student {Name="Андрей", Age=23, Languages = new List<string> {"английский", "немецкий" }},
                 new Student {Name="Сергей", Age=27, Languages = new List<string> {"английский", "французский" }},
                 new Student {Name="Дмитрий", Age=29, Languages = new List<string> {"английский", "испанский" }},
                 new Student {Name="Василий", Age=24, Languages = new List<string> {"испанский", "немецкий" }}
            };
            var coarses = new List<Coarse>
            {
                new Coarse {Name="Язык программирования C#", StartDate = new DateTime(2020, 12, 20)},
                new Coarse {Name="Язык SQL и реляционные базы данных", StartDate = new DateTime(2020, 12, 15)},
            };

            var studentAdd = from student in students
                             where student.Age < 29
                             where student.Languages.Contains("английский")
                             from student2 in coarses
                             where student2.Name.Contains("C#")
                             select new
                             {
                                 Name = student.Name,
                                 YearOfBirth = student.Age,
                                 Coarse = student2.Name
                             };

            foreach (var student in studentAdd)
                Console.WriteLine($"Студент: {student.Name} добален на курс {student.Coarse}");

            var contacts = new List<Contact>()
            {
                new Contact() { Name = "Андрей", Phone = 7999945005 },
                new Contact() { Name = "Сергей", Phone = 799990455 },
                new Contact() { Name = "Иван", Phone = 79999675 },
                new Contact() { Name = "Игорь", Phone = 8884994 },
                new Contact() { Name = "Анна", Phone = 665565656 },
                new Contact() { Name = "Василий", Phone = 3434 }
            };

            while (true)
            {
                var keyChar = Console.ReadKey().KeyChar;
                Console.Clear();

                if (!Char.IsDigit(keyChar))
                {
                    Console.WriteLine("Error, write 1");
                }
                else
                {
                    IEnumerable<Contact> page = null;

                    switch(keyChar)
                    {
                        case ('1'):
                            page = contacts.Take(2);
                            break;
                        case ('2'):
                            page = contacts.Skip(2).Take(2);
                            break;
                        case ('3'):
                            page = contacts.Skip(4).Take(2);
                            break;
                    }

                    if (page == null)
                    {
                        Console.WriteLine("Error write 1 or 2 or 3");
                        continue;
                    }

                    foreach (var contact in page)
                        Console.WriteLine(contact.Name + " " + contact.Phone);
                }
            }
        }



    }

    internal class Contact
    {
        public Contact()
        {
        }

        public string Name { get; set; }
        public long Phone { get; set; }
    }

    class Student()
    {
        public string Name { get; set; }
        public int Age { get; set; }
        public List<string> Languages { get; set; }
    }
}
