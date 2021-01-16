using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleLambdaExpressions
{
    class Program
    {
        static void Main(string[] args)
        {
            TraditionalDelegateSyntax();
        }

        static void TraditionalDelegateSyntax()
        {
            // Make a list of integers 
            List<int> myInts = new List<int> {1, 2, 3, 4, 5};

            List<int> myInts2 = new List<int>();
            myInts2.AddRange(new int[] { 65, 1, 123, 5, 34, 547, 43 });

            Console.WriteLine(myInts);
            foreach (var item in myInts)
            {
                Console.WriteLine(item.ToString());
            }
            Console.ReadLine();


            Console.WriteLine(myInts);
            foreach (var item in myInts2)
            {
                Console.WriteLine(item.ToString());
            }
            Console.ReadLine();

            Predicate<int> myPredicate = FindBiguns;

            // Traditional Predicate from a delegate definition
            List<int> myBigInts = myInts2.FindAll(myPredicate);

            // Anonymous function
            List<int> myBigInts3 = myInts2.FindAll(delegate(int i) { return i > 30; });

            // Lambda expression
            List<int> myBigInts2 = myInts2.FindAll(i => i > 30);


            foreach (var item in myBigInts3)
            {
                Console.WriteLine("One of my biggest ints is {0}", item.ToString());
            }
            Console.ReadLine();
        }

        static bool FindBiguns(int i)
        {
            return (i > 30);
        }
    }
}
