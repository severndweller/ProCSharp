using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using System.Data.Odbc;
using System.Data.OleDb;

namespace StringReaderWriterApp
{
    class Program
    {
        static void Main(string[] args)
        {

            Console.WriteLine("Fun with StringReader / StringWriter ******\n");

            // Create a StringWriter and emit data to memory
            using (StringWriter s = new StringWriter())
            {
                s.WriteLine("Don't forget Mother's Day this year...");
                // Get a copy of the contents (stored in a string) and dump to console
                Console.WriteLine("Contens of StringWriter is \n{0}\n", s);
            }
            Console.ReadLine();

            using (StringWriter s = new StringWriter())
            {
                s.WriteLine("Don't forget Father's Day This year..");
                Console.WriteLine("Contens of StringWriter is \n{0}\n", s);
                StringBuilder sb = s.GetStringBuilder();
                Console.WriteLine("The StringBuilder generated from this is {0}", sb.ToString());
                sb.Insert(0, "Hey!!");
                Console.WriteLine("The StringBuilder after add is {0}", sb.ToString());
                sb.Remove(0, "Hey!!".Length);
                Console.WriteLine("The StringBuilder after remove is {0}", sb.ToString());
            }
            Console.ReadLine();


            using (StringWriter s = new StringWriter())
            {
                s.WriteLine("Don't forget Mother's Day this year...");
                // Get a copy of the contents (stored in a string) and dump to console
                Console.WriteLine("Contens of StringWriter is \n{0}\n", s);

                // Now read data from the StringWriter 
                using (StringReader sr = new StringReader(s.ToString()))
                {
                    string input = null;
                    while ((input = sr.ReadLine()) != null)
                    {
                        Console.WriteLine(input);
                    }
                }
            }
                Console.WriteLine("We are done");
            Console.ReadLine();

        }
    }
}
