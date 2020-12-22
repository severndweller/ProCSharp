using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleClassExample
{
    class Program
    {
        static void Main(string[] args)
        {
            Car myCar = new Car();
            myCar.currSpeed = 10;
            myCar.petName = "Henry";

            Car chuck = new Car();
            chuck.PrintState();

            Car mary = new Car("Mary");
            mary.PrintState();

            Car daisy = new Car("Daisy", 75);
            daisy.PrintState();

            // Speed up the car a few times and print out
            for (int i = 0; i < 10; i++)
            {
                myCar.AlternateSpeedUp(5);
                myCar.PrintState();
            }

            //MotoCycle mc = new MotoCycle(5);
            //mc.SetDriverName("Tiny");
            //mc.PopAWheely();
            //Console.WriteLine("Rider name is {0}", mc.driverName);

            MotoCycle m1 = new MotoCycle();
            Console.WriteLine("Name = {0}, Intensity = {1}", m1.driverName, m1.driverIntensity);

            MotoCycle m2 = new MotoCycle(name: "Stevey");
            Console.WriteLine("Name = {0}, Intensity = {1}", m2.driverName, m2.driverIntensity);

            MotoCycle m3 = new MotoCycle(7);
            Console.WriteLine("Name = {0}, Intensity = {1}", m3.driverName, m3.driverIntensity);

            Console.ReadLine();

        }
    }
}
