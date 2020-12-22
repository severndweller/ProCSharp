using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FunWIthTuples
{
    class Program
    {
        struct Point
        {
            // fields of the structure
            public int X;
            public int Y;

            public Point(int x, int y)
            {
                X = x; Y = y;
            }

            public (int XPos, int YPos) Deconstruct() => (X, Y);
        }


        static (int a, string b, int c) FillTheseValues()
        {
            int aa = 5;
            string bb = "Ted";
            int cc = 15;

            return (aa, bb, cc);
        }

        static (string a, string b, int size) DisectThisString (string fullString)
        {
            // This would obviously fail for certain length strings being passed
            return (fullString.Substring(0, 1), fullString.Substring(1), fullString.Length);
        }

        static void Main(string[] args)
        {

            (string, int, string) values = ("a", 5, "c");
            var moreValues = ("b", 6, "u");
            Console.WriteLine($"Values 1 is {values.Item1}");
            Console.WriteLine($"Values 2 is {values.Item2}");
            Console.WriteLine($"Values 3 is {values.Item3}");
            Console.WriteLine($"More 1 {moreValues.Item1}");
            Console.WriteLine($"More 2 {moreValues.Item2}");
            Console.WriteLine($"More 3 {moreValues.Item3}");

            (string FirstName, string LastName, int Age) me = ("Simon", "Davies", 55);
            Console.WriteLine(me.FirstName);
            Console.WriteLine(me.LastName);
            Console.WriteLine(me.Age);

            var myValues = FillTheseValues();
            Console.WriteLine(myValues.a);
            Console.WriteLine(myValues.b);
            Console.WriteLine(myValues.c);

            var splitString = DisectThisString("SDavies");
            Console.WriteLine(splitString.a);
            Console.WriteLine(splitString.b);
            Console.WriteLine(splitString.size.ToString());

            var (_, last, size) = DisectThisString("TDavies");
            Console.WriteLine(last);
            Console.WriteLine(size.ToString());

            // Deconstruct 
            Point p = new Point(10, 15);
            var pointValues = p.Deconstruct();

            Console.WriteLine(pointValues.XPos);
            Console.WriteLine(pointValues.YPos);


            Console.ReadLine();
        }
    }
}
