using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinqOverArray
{
    class Program
    {

        static void QueryOverStrings()
        {
            // Assume we have an array of string
            string[] currentFilms = { "Where Eagles Dare", "Thunderbirds", "Jaws 2", "Shrek the 3rd", "Home Alone 2" };
            // Build a query expression to find the items in the array that hace an embedded space
            IEnumerable<string> subset = from g in currentFilms where g.Contains(" ") orderby g select g;

            ReflectOverQueryResults(subset);

            // print out the schedule
            foreach (var item in subset)
            {
                Console.WriteLine("=> {0}", item);
            }
        }

        static void QueryOverStringsWIthExtensionMethods()
        {
            // Assume we have an array of string
            string[] currentFilms = { "Where Eagles Dare", "Thunderbirds", "Jaws 2", "Shrek the 3rd", "Home Alone 2" };
            // Build a query expression to find the items in the array that hace an embedded space
            IEnumerable<string> subset = currentFilms.Where(g => g.Contains(" ")).OrderBy(g => g);
            // print out the schedule

            ReflectOverQueryResults(subset, "Extension Methods");

            foreach (var item in subset)
            {
                Console.WriteLine("=> {0}", item);
            }
        }

        static void QueryOverInts()
        {
            int[] numbers = { 10,20,30,40,10,20,30,8 };

            var subset = from i in numbers where i < 10 select i;

            ReflectOverQueryResults(subset);

            foreach (var item in numbers)
            {
                Console.WriteLine("Item: {0}", item);
            }
        }

        static void ReflectOverQueryResults(object resultSet, string queryType = "Query Expressions")
        {
            Console.WriteLine($"Info about your query using {queryType}");
            Console.WriteLine("ResultSet is of type {0}", resultSet.GetType().Name);
            Console.WriteLine("ResultSet Location {0}", resultSet.GetType().Assembly.GetName().Name);
        }


        static void Main(string[] args)
        {
            Console.WriteLine("Fun with Linq To Objects");
            QueryOverStrings();
            Console.ReadLine();
            QueryOverStringsWIthExtensionMethods();
            Console.ReadLine();
            QueryOverInts();
            Console.ReadLine();
        }

    }
}
