using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FunWithGenericCollections
{
    class Program
    {
        static void Main(string[] args)
        {
            UseGenericList();
        }

        static void UseGenericList()
        {
            List<Person> people = new List<Person>()
            {
                new Person{ FirstName = "Homer", LastName = "Simpson", Age = 47 },
                new Person{ FirstName = "Marge", LastName = "Simpson", Age = 45 },
                new Person{ FirstName = "Lisa", LastName = "Simpson", Age = 9 },
                new Person{ FirstName = "Bart", LastName = "Simpson", Age = 8 }
            };

            Console.WriteLine("NUmber of peopl in the list {0}", people.Count);
            // Print out the items in the list
            foreach (var item in people)
            {
                Console.WriteLine(item);
            }

            Console.WriteLine("============");
            //Insert a new person
            people.Insert(2, new Person { FirstName = "Simon", LastName = "Davies", Age = 55 });

            Person[] peoplArr = people.ToArray();
            foreach (var item in people)
            {
                Console.WriteLine(item);
            }

            Console.ReadLine();
        }
    }
}
