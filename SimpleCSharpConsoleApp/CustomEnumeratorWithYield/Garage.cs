using System;
using System.Collections.Generic;
using System.Collections;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomEnumerator
{
    public class Garage : IEnumerable
    {
        private Car[] carArray = new Car[4];
        // Fill t' garage wit' caaaars

        public Garage()
        {
            carArray[0] = new Car("Rusty", 30);
            carArray[1] = new Car("Clunker", 55);
            carArray[2] = new Car("Zippy", 30);
            carArray[3] = new Car("Fred", 30);
        }

//        IEnumerator IEnumerable.GetEnumerator()
        public IEnumerator GetEnumerator()
        {
            // This will not get thrown until MoveNext is called
            throw new Exception("This will get called");
            return actualImplementation();
            //foreach (Car car in carArray)
            //{
            //    yield return car;
            //}

            // Page 309 - this is the private function
            IEnumerator actualImplementation()
            {
                foreach (Car c in carArray)
                {
                    yield return c;
                }
            }
        }

    }
}
