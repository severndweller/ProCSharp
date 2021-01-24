using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PassRefsByValue
{
    class Program
    {


        static void SendAPersonByValue(Person p)
        {
            p.personAge = 99;
            p.personName = "Stevey";
            //p = new Person("Nikki", 99);
        }

        static void SendAPersonByReference(ref Person p)
        {
            p.personAge = 66;
            p.personName = "Mickey";
            //p = new Person("Mel", 75);
        }

        static void Main(string[] args)
        {
            Console.WriteLine("Passing person object by value");
            Person fred = new Person("Fred", 12);
            Console.WriteLine("Before by value call, person is...");
            fred.Display();

            SendAPersonByValue(fred);
            Console.WriteLine("After by value call, person is...");
            fred.Display();


            SendAPersonByReference(ref fred);
            Console.WriteLine("After by reference call, person is...");
            fred.Display();

            Console.ReadLine();

        }
    }
}
