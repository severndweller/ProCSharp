using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Numerics;

namespace BasicDataTypes
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("=> Data Declarations");
            //local variables are declared as so
            // datatype varName
            int myInt = 0;
            string myString = "This is my character data";
            bool b1 = true, b2 = false, b3 = true;
            System.Boolean b4 = true;
            Console.WriteLine();
            //DefaultDeclarations();
            //ObjectFunctionality();
            StringInterpolation();
            //UseDatesAndTimes();
            //StringEqualitySpecifyingCompareRules();
            Console.ReadLine();
        }

        private static void DefaultDeclarations()
        {
            Console.WriteLine("=> Default Declarations");
            int myInt = default;
            Console.WriteLine("The default for type int is {0}", myInt);
            //Console.ReadLine();

            int myInt2 = new int();
            bool b5 = new bool();
            double db = new double();
            DateTime dt = new DateTime();
            DateTime dt2 = default;
            Console.WriteLine("DateTime value is {0}", dt);
            Console.WriteLine("DateTime2 value is {0}", dt2);
        }

        private static void ObjectFunctionality()
        {
            Console.WriteLine("12.GetHashCode() = {0}", 12.GetHashCode());
            Console.WriteLine("12.ToString() = {0}", 12.ToString());
            Console.WriteLine("12.Equals(0) = {0}", 12.Equals(0));
            Console.WriteLine("12.GetType() = {0}", 12.GetType());
            Console.WriteLine("12.GetTypeCode() = {0}", 12.GetTypeCode());
            Console.WriteLine("Other interesting methods");
            Console.WriteLine("Int Min / Max {0} / {1}", int.MinValue, int.MaxValue);
            Console.WriteLine("Double Min / Max / Epsilon / PosINf / NegInf {0} / {1} / {2} / {3} / {4}",
                double.MinValue, double.MaxValue, double.Epsilon, double.PositiveInfinity, double.NegativeInfinity);

            Console.WriteLine("Char a is letter {0}", char.IsLetter('a'));
            Console.WriteLine("Char 2 is letter {0}", char.IsLetter('2'));
            Console.WriteLine("This 'a' is whitespace {0}", char.IsWhiteSpace('a'));
            Console.WriteLine("This ' ' is whitespace {0}", char.IsWhiteSpace(' '));
            Console.WriteLine("This '£' is punc {0}", char.IsPunctuation('£'));
            Console.WriteLine("This '!' is punc {0}", char.IsPunctuation('!'));

            char a = Char.Parse("p");
            char b = Char.Parse("q");
            Console.WriteLine("char p parsed is {0}", a);
            Console.WriteLine("char b parsed is {0}", b);

            if (bool.TryParse("True", out bool boolSteve))
            {
                Console.WriteLine("BoolSteve is {0}", boolSteve);
            }
            else
            {
                Console.WriteLine("BoolSteve alternate is {0}", boolSteve);
            }
        }

        private static void UseDatesAndTimes()
        {
            DateTime dt = new DateTime(2020, 12, 10);
            Console.WriteLine(dt.ToString());
            Console.WriteLine(dt);
            Console.WriteLine("123_456 value is {0} \r", 123_456);
            Console.WriteLine("1_23_456 value is {0} \n\n ", 123_456);
            Console.WriteLine("b100 value is {0} \a", 0b100);

        }

        private static void StringEqualitySpecifyingCompareRules()
        {
            string s1 = "HELLO!";
            string s2 = "Hello!";
            Console.WriteLine("s1 is {0}", s1);
            Console.WriteLine("s2 is {0}", s2);
            Console.WriteLine("are they equal normal {0}", s1.Equals(s2));
            Console.WriteLine("are they equal InvariantCulture {0}", s1.Equals(s2, StringComparison.InvariantCulture));
            Console.WriteLine("are they equal invcultigcase {0}", s1.Equals(s2, StringComparison.InvariantCultureIgnoreCase));
            Console.WriteLine("are they equal ordinalignorcase {0}", s1.Equals(s2, StringComparison.OrdinalIgnoreCase));
            Console.WriteLine("are they equal ordinal {0}", s1.Equals(s2, StringComparison.Ordinal));

            string b = "Howdy";
            b = "Again";
        }

        private static void StringInterpolation()
        {
            StringBuilder sb = new StringBuilder("Soren");
            sb.Replace("or", "tr").Replace("n", "ngth");
            Console.WriteLine("it is now {0}", sb.ToString());
            int age = 55;
            string name = "Simon";
            string slit = string.Format("Hello {0}, you are {1} years old", name, age);
            string slit2 = String.Format("Hello {0}, you are {1} years old", name, age);
            Console.WriteLine("slit is {0}", slit);
            Console.WriteLine("slit2 is {0}", slit2);
            Console.WriteLine($"Hello {name}, you are {age} years old, honest");

            byte b1 = 100;
            byte b2 = 1;
            byte b3 = checked((byte)(b1 + b2));
            Console.WriteLine("The result is {0}", b3);


            byte bb1 = 100;
            byte bb2 = 201;
            byte bb3 = (byte)(bb1 + bb2);
            Console.WriteLine("The result is {0}", bb3);
        }
    }
}
