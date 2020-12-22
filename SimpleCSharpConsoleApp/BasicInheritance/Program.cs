using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BasicInheritance
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("***** Basic Inheritance ********");
            Car myCar = new Car(80);
            // Set the current speed and print it
            myCar.Speed = 60;
            Console.WriteLine("My car is going at {0} MPH", myCar.Speed);
            myCar.Speed = 85;
            Console.WriteLine("My car is going at {0} MPH", myCar.Speed);

            Minivan myMinivan = new Minivan();
            myMinivan.Speed = 10;
            Console.WriteLine("My minivan is going at {0} MPH", myMinivan.Speed);
            Console.ReadLine();
        }
    }
}
