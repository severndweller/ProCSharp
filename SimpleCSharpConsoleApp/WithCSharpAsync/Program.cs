using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace WithCSharpAsync
{
    class Program
    {
        static async Task Main(string[] args)
        {
            Console.WriteLine("Fun with Async");
            // This is to prompt Visual Studio to upgrade the project to C# 7.1. Actually we're already beyond it
            List<int> l = default;

            // TESTING 

            Console.WriteLine("Calling the async staging point method with await");
            await DoAwaitWorkFromThisMethodAsync();
            Console.WriteLine("Back from the async staging point method following await");

            Console.WriteLine("Hit Return to continue");
            Console.ReadLine();

            Console.WriteLine("Calling the staging point method WITHOUT await");
            DoAwaitWorkFromThisMethodAsync();
            Console.WriteLine("Back from the staging point method WITHOUT await");

            Console.WriteLine("Give it chance to finish, but Hit Return to continue");

            Console.ReadLine();



            // THE MAIN EXAMPLE
            // The below would lock the main thread until complete.
            Console.WriteLine("Starting Synchronous work");
            Console.WriteLine(DoWork());
            Console.WriteLine("Completed Synchronous work");

            // INSTEAD

            Console.WriteLine("Starting " +
                "asynchronous work");
            DoWorkAsync();
            Console.WriteLine("Completed asynchronous work");

            for (int i = 0; i < 10; i++)
            {
                Console.ReadLine();
                Console.WriteLine("Still running, {0} keypresses left", (10-i-1).ToString());
            }

            Console.WriteLine("Now waiting on another asynchronous call this time from thread {0}", Thread.CurrentThread.ManagedThreadId.ToString());

            string message = await DoWorkAsync();
            Console.WriteLine(message);
            Console.ReadLine();
        }

        static async Task DoAwaitWorkFromThisMethodAsync()
        {
            Console.WriteLine("DoAwaitWorkFromThisMethodAsync Starting");

            string theResponse = await DoWorkAsync();

            Console.WriteLine("This was returned [{0}]", theResponse);

            Console.WriteLine("DoAwaitWorkFromThisMethodAsync Ending");

        }

        static string DoWork()
        {
            Thread.Sleep(5_000);
            return "Done with work";
        }

        static async Task<string> DoWorkAsync()
        {
            return await Task.Run(() =>
            {
                Thread.Sleep(15000);
                return String.Format("Done with asynchronous work from thread {0}, Backgroun? {1}", 
                    Thread.CurrentThread.ManagedThreadId.ToString(),
                    Thread.CurrentThread.IsBackground);
//                return "Done with asynchronous work";
            });
            Console.WriteLine("ENDING Synchronous work");
        }
    }
}
