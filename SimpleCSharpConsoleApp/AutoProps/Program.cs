using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoProps
{
    class Program
    {
        static void Main(string[] args)
        {
            Car c = new Car();
            c.PetName = "Frank";
            c.Speed = 55;
            c.Colour = "Red";
            c.DisplayStats();

            // Put car in garage
            Garage g = new Garage();
            g.myAuto = c;
            Console.WriteLine("Number of cars in garage: {0}", g.NumberOfCars);
            Console.WriteLine("Your car is named: {0}", g.myAuto.PetName);
            Console.ReadLine ();
        }
    }
}
