using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;

namespace IssuesWithNonGenericCollections
{
    class Program
    {
        static void Main(string[] args)
        {
            object myBoxedInt;
            int myInt;
            myBoxedInt = SimpleBoxUnboxOperation();
            Console.WriteLine("Boxed Int {0}", myBoxedInt);

            myInt = (int)myBoxedInt;
            Console.WriteLine("Boxed Int {0}", myInt);

            int[] myInts = { 6, 2, 1, 4, 9, 8, 3, 20, 15 };
            Array.Sort(myInts);
//            Array.Sort<int>(myInts);
            foreach (int item in myInts)
            {
                Console.WriteLine("Next is {0}", item);
            }
            Console.ReadLine();
        }


        static object SimpleBoxUnboxOperation()
        {
            //Make Value type (int) variable
            int myInt = 25;

            // Box the int into a refernce object
            object boxedInt = myInt;
            return boxedInt;
        }
    }

}
