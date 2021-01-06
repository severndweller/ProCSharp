using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomEnumerator
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Fun with IEnumerable / IEnumerator");
            Garage carlot = new Garage();

            // Hand over each car in the collection
            foreach (Car thisCar in carlot)
            {
                Console.WriteLine("{0} is going at {1} mph", thisCar.PetName, thisCar.CurrentSpeed);
            }

            //Manually working with IENumerator
            IEnumerator i = carlot.GetEnumerator();
            i.MoveNext();
            Car myCar = (Car)i.Current;
            Console.WriteLine("This is {0} and the speed is {1}", myCar.PetName, myCar.CurrentSpeed);
            Console.ReadLine();
        }
    }
}
