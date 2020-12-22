using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NullableTypes
{

    class DBReader
    {
        public int? numericvalue = null;
        public bool? boolValue = true;

        public int? GetIntFromDatabase()
        {
            return numericvalue;
        }

        public bool? GetBoolFromDatabase()
        {
            return boolValue;
        }
    }


    class Program
    {
        static void Main(string[] args)
        {
            DBReader dbr = new DBReader();
            int? i = dbr.GetIntFromDatabase();
            if (i.HasValue)
            {
                Console.WriteLine("i has value of {0}", i.ToString());
            }
            else
            {
                Console.WriteLine("Int it undefined");
            }

            bool? b = dbr.GetBoolFromDatabase();
            if (b.HasValue)
            {
                Console.WriteLine("b has value of {0}", b.ToString());
            }
            else
            {
                Console.WriteLine("Bool it undefined");
            }

            Console.ReadLine();

        }
    }
}
