using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PassRefsByValue
{
    class Program
    {
        class Person
        {
            private readonly northerner _northerner;

            // constructors
            public Person(string name, int age)
            {
                _northerner = new northerner(name, age);
            }

            public Person()
            {
                _northerner = new northerner();
            }

            public northerner Northerner
            {
                get { return _northerner; }
            }
        }

        static void SendAPersonByValue(Person p)
        {
            p.Northerner.personAge = 99;
            p.Northerner.personName = "Stevey";
            //p = new Person("Nikki", 99);
        }

        static void SendAPersonByReference(ref Person p)
        {
            p.Northerner.personAge = 66;
            p.Northerner.personName = "Mickey";
            //p = new Person("Mel", 75);
        }

        static void Main(string[] args)
        {
            Console.WriteLine("Passing person object by value");
            Person fred = new Person("Fred", 12);
            Console.WriteLine("Before by value call, person is...");
            fred.Northerner.Display();

            SendAPersonByValue(fred);
            Console.WriteLine("After by value call, person is...");
            fred.Northerner.Display();


            SendAPersonByReference(ref fred);
            Console.WriteLine("After by reference call, person is...");
            fred.Northerner.Display();

            Console.ReadLine();

        }
    }
}
