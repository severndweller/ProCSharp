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
            IEnumerable<string> subset = currentFilms.Where(g => g.Contains(" ")).OrderBy(g => g).Select(g => g);
            // print out the schedule
            foreach (var item in subset)
            {
                Console.WriteLine("=> {0}", item);
            }
        }



        static void Main(string[] args)
        {
            Console.WriteLine("Fun with Linq To Objects");
            QueryOverStrings();
            Console.ReadLine();
            QueryOverStringsWIthExtensionMethods();
            Console.ReadLine();
        }

    }
}
