using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnonymousTypes
{
    class Program
    {

        // Build anon type using incoming args
        static void BuildAnonType (string make, string colour, int currSp)
        {
            var car = new { Make = make, Colour = colour, CurrSp = currSp };

            // Note that can use this type to get the property data
            Console.WriteLine("You have a {0} {1} going at {2} MPH", car.Colour, car.Make, car.CurrSp);

            // Anon types have custom implementations of each virtual
            // method of System.Object. For example..
            Console.WriteLine("ToString() == {0}", car.ToString());
        }

        static void Main(string[] args)
        {
            Console.WriteLine("Fun with anonymous types");

            // Make an anonymous type representing a car

            var myCar = new { Colour = "Bright Pink", Make = "Saab", CurrentSpeed = 55 };

            // Now show the colour and make
            Console.WriteLine("y car is a {0} {1}", myCar.Colour, myCar.Make);

            //Now call our helper method to build an anonymous type via args
            BuildAnonType("BMW", "Black", 90);

            Console.ReadLine();
        }
    }
}
