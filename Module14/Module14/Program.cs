using System;
using System.Linq;
using System.Runtime.InteropServices;

namespace Module14
{
    class Program
    {
        static void Main(string[] args)
        {
            var phoneBook = new List<Contact>();

            // добавляем контакты
            phoneBook.Add(new Contact("Инорь", "Николаев", 79990000001, "igor@example.com"));
            phoneBook.Add(new Contact("Сергей", "Довлатов", 79990000010, "serge@example.com"));
            phoneBook.Add(new Contact("Анатолий", "Карпов", 79990000011, "anatoly@example.com"));
            phoneBook.Add(new Contact("Валерий", "Леонтьев", 79990000012, "valera@example.com"));
            phoneBook.Add(new Contact("Сергей", "Брин", 799900000013, "serg@example.com"));
            phoneBook.Add(new Contact("Иннокентий", "Смоктуновский", 799900000013, "innokentii@example.com"));

            var sotrPhoneBook = phoneBook.OrderBy(x => x.Name).ThenBy(x => x.LastName);

            while (true)
            {
                var input = Console.ReadKey().KeyChar;
                var parsed = Int32.TryParse(input.ToString(), out int pageNum);

                if (!parsed || pageNum < 1 || pageNum > 3)
                {
                    Console.WriteLine();
                    Console.WriteLine("Неверное число");
                }
                else
                {
                    Console.WriteLine();
                    var pageContent = sotrPhoneBook.Skip((pageNum - 1) * 2).Take(2);
                    foreach (var contact in pageContent)
                    {
                        Console.WriteLine(contact.Name + " " + contact.LastName + " " + contact.PhoneNumber);
                    }
                }
            }
        }
    }

    public class Contact
    {
        public Contact(string name, string lastName, long phoneNumber, String email)
        {
            Name = name;
            LastName = lastName;
            PhoneNumber = phoneNumber;
            Email = email;
        }

        public String Name { get; }
        public String LastName { get; }
        public long PhoneNumber { get; }
        public String Email { get; }
    }
}
