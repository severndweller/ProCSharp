using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//using System.Windows.Forms;

namespace SimpleCSharpConsoleApp
{
    class Program
    {
        static int Main(string[] args)
        {

            ShowEnvironmentDetails();
            Console.Title = "My Rocking App";
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.BackgroundColor = ConsoleColor.Blue;
            Console.WriteLine("************************************");
            Console.WriteLine("***** Welcome to my Rocking App *****");
            Console.WriteLine("************************************");
            Console.BackgroundColor = ConsoleColor.Black;

            Console.WriteLine("There are {0} arguments", args.Length);

            // Process any incoming args
            for (int i = 0; i < args.Length; i++)
            {
                Console.WriteLine("Argument {0} is '{1}'", i, args[i]);
            }

            foreach (var item in args)
            {
                Console.WriteLine("ForEach Arg {0}", item);
            }

            string[] theArgs = Environment.GetCommandLineArgs();
            foreach (var itemArg in theArgs)
            {
                Console.WriteLine("GetCommandLine ForEach Arg {0}", itemArg);
            }


            // Wait for Enter keyto be pressed
            Console.ReadLine();
            //            MessageBox.Show("All Done!");
            Environment.ExitCode = -8;
            return Environment.ExitCode;
        }

        static void ShowEnvironmentDetails()
        {
            // Print out the machine's drives
            // and other interesting details
            foreach (string drive in Environment.GetLogicalDrives())
            {
                Console.WriteLine("Drive: {0}", drive);
            }
            Console.WriteLine("OS Version {0}", Environment.OSVersion);
            Console.WriteLine("Processor Count {0}", Environment.ProcessorCount);
            Console.WriteLine("64 Bit? {0}", Environment.Version);
            Console.WriteLine("Machine Name  {0}", Environment.MachineName);
        }
    }
}
