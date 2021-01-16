using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarEvents
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Fun With Events");
            Car c1 = new Car("Slugbug", 100, 10);

            // Register event handlers
            c1.AboutToBlow += new Car.CarEngineHandler(CarIsAlmostDoomed);
            c1.AboutToBlow += new Car.CarEngineHandler(CarAboutToBlow);
            c1.AboutToBlow += C1_AboutToBlow1;

            // Another way of doing this and useful if you might be removing the event at some point
            // Declare a new delegate and assign to a local variable
            Car.CarEngineHandler d = new Car.CarEngineHandler(CarExploded);
            // And register the event to the c1 Car class instance
            c1.Exploded += d;

            Console.WriteLine("***** Speeding up **********");
            for (int i = 0; i < 6; i++)
            {
                c1.Accelerate(20);
            }

            // Remove CarExploded method
            c1.Exploded -= d;

            Console.WriteLine("***** Speeding up **********");
            for (int i = 0; i < 6; i++)
            {
                c1.Accelerate(20);
            }
            Console.ReadLine();
        }

        private static void C1_AboutToBlow1(string msg)
        {
            throw new NotImplementedException();
        }

        private static void C1_AboutToBlow(string msg)
        {
            throw new NotImplementedException();
        }

        public static void CarIsAlmostDoomed (string Msg)
        {
            Console.WriteLine("CarIsAlmostDoomed fired {0}", Msg);
        }

        public static void CarAboutToBlow (string Msg)
        {
            Console.WriteLine("Car About TO Blow fired {0}", Msg);
        }

        public static void CarExploded (string Msg)
        {
            Console.WriteLine("Exploded Event Fired {0}", Msg);
        }
    }
}
