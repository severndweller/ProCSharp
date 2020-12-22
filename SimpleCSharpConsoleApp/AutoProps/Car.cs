using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoProps
{
    class Car
    {
        public string PetName { get; set;}
        public int Speed { get; set; }
        public string Colour { get; set; }

        public void DisplayStats()
        {
            Console.WriteLine("Car Name: {0}", PetName);
            Console.WriteLine("Speed: {0}", Speed);
            Console.WriteLine("Colour: {0}", Colour);
        }
    }

    class Garage
    {
        public int NumberOfCars { get; set; }
        public Car myAuto { get; set; } = new Car();
        public int NumberOfDoors { get; set; } = 1;

        //public Garage()
        //{
        //    myAuto = new Car();
        //    NumberOfCars = 1;
        //}

        public Garage()
        {
            // Default assignment now exist through use of automatic property initialisation
        }

        public Garage (Car car, int number)
        {
            myAuto = car;
            NumberOfCars = number;
        }
    }
}
