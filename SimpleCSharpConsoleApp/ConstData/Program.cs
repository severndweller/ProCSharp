using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConstData
{

    class MyMathClass
    {
        public const double PI = 3.14;
        public static readonly double PI2;

        static MyMathClass()
        {
            PI2 = 3.14;
        }

        public void TryMe()
        {
            // This would fail - a static readonly value can only be assigned within a static constructor
            // PI2 = 4;
        }

    }
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Accessing the const value as a static clas member: {0}", MyMathClass.PI);
            Console.WriteLine("Accessing the readonly value as a static clas member: {0}", MyMathClass.PI2);
            Console.ReadLine();
        }
    }
}
