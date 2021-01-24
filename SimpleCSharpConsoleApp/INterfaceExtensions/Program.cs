using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InterfaceExtensions
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Extending Interface Compatible Types ******");
            // System.Array implements IEnumerable
            string[] data = { "Wow", "this", "is", "sort", "of", "annoying", "but", "fun" };
            data.PrintDataAndBeep();

            Console.WriteLine();
            // List<T> implement IEnumerable
            List<int> myInts = new List<int>()  { 1, 2, 3, 4};
            foreach (var item in myInts)
            {
                Console.WriteLine("Another is {0}", item);
            }
            myInts.PrintDataAndBeep();

            Queue<string> mine = new Queue<string>(new[] {"Hello", "You" });
            mine.PrintDataAndBeep();

            // This correctly doesn't work as int does not have this service extension
            //int theCounter = 6;
            //theCounter.PrintAndBeep;
        }
    }
}
