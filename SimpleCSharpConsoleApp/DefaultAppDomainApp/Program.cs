using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;

namespace DefaultAppDomainApp
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Fun with the default App Domain");
            InitDAD();
            DisplayDADStats();
            ListAllAssembliesInAppDomain();
            Console.ReadLine();
        }

        private static void DisplayDADStats()
        {
            // Get access to the AppDomain for the current thread
            AppDomain defaultAD = AppDomain.CurrentDomain;

            // Print out the various stats about this domain
            Console.WriteLine("Name of this domain {0}", defaultAD.FriendlyName);
            Console.WriteLine("ID of the domain in this process {0}", defaultAD.Id);
            Console.WriteLine("Is this the default domain {0}", defaultAD.IsDefaultAppDomain());
            Console.WriteLine("Base directory of this domain {0}", defaultAD.BaseDirectory);

            Console.WriteLine("===========================");
            ListAllAssembliesInAppDomain();

        }

        static void ListAllAssembliesInAppDomain()
        {
            // Get access to the app domain for the current thread.
            AppDomain defaultAD = AppDomain.CurrentDomain;

            // Now get all loaded assemblies in the default app domain. 
            var loadedAssemblies = from a in defaultAD.GetAssemblies()
                                   orderby a.GetName().Name
                                   select a;

            Console.WriteLine("***** Here are the assemblies loaded in {0} *****\n",
                defaultAD.FriendlyName);
            foreach (var a in loadedAssemblies)
            {
                Console.WriteLine("-> Name: {0}", a.GetName().Name);
                Console.WriteLine("-> Version: {0}\n", a.GetName().Version);
            }
        }

        private static void InitDAD()
        {
            //Print the name of the assembly loaded into the AppDomain after it's been created
            AppDomain defaultAD = AppDomain.CurrentDomain;
            defaultAD.AssemblyLoad += (obj, eventArgs) =>
            {
                Console.WriteLine("Assembly Loaded {0}", eventArgs.LoadedAssembly.GetName().Name);
            };
        }

    }

}
