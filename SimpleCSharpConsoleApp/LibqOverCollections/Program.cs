using System;
using System.Collections.Generic;
using System.Collections;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinqOverCollections
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Car> garage = new List<Car>()
            {
                new Car { Petname = "Henry", Color = "Silver", Speed = 100, Make = "BMW" },
                new Car { Petname = "Daisy", Color = "Tan", Speed = 90, Make = "BMW" },
                new Car { Petname = "Mary", Color = "Black", Speed = 55, Make = "VW" },
                new Car { Petname = "Clunker", Color = "Rust", Speed = 5, Make = "Yugo" },
                new Car { Petname = "Melvin", Color = "White", Speed = 43, Make = "Ford" }
            };

//            IEnumerable<Car> fastCars = from c in garage where c.Speed > 55 select garage;
            var fastCars = from c in garage where c.Speed > 55 || c.Make == "Yugo" select c;

            GetFastCars(garage);

            foreach (Car item in fastCars)
            {
                Console.WriteLine("{0} is going at {1} mph", item.Petname, item.Speed);
            }

            LINQOverArrayList();
            Console.ReadLine();
        }

        static void GetFastCars (List<Car> myCars)
        {
            var fastCars = from c in myCars where c.Speed > 55 select c;

            foreach (Car item in fastCars)
            {
                Console.WriteLine("{0} is going at {1} mph", item.Petname, item.Speed);
            }
        }

        static void LINQOverArrayList()
        {
            Console.WriteLine("LINQ Over Array List");
            ArrayList myStuff = new ArrayList();
            myStuff.AddRange(new object[] { 10, 400, 8, new Car(), "string data"});
            var myInts = myStuff.OfType<int>();

            foreach (int i in myInts)
            {
                Console.WriteLine("We found {0}", i.ToString());
            }
        }


    }
}
