using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SimpleMultiThreadApp
{
    public class Printer
    {
        static void Main(string[] args)
        {
            Console.WriteLine("The Amazing thread App");
            Console.WriteLine("Do you want [1] or [2] threads?");
            string threadCount = Console.ReadLine();

            // Name the current thread
            Thread primaryThread = Thread.CurrentThread;
            primaryThread.Name = "Primary";

            // Display Thread Info
            Console.WriteLine("Display Thread Info");
            Console.WriteLine("This thread's name is {0}", Thread.CurrentThread.Name);

            // Make worker class
            Printer p = new Printer();

            switch(threadCount)
            {
                case "2":
                    // Now make the thread
                    Thread backgroundThread = new Thread(new ThreadStart(p.PrintNumbers));
                    backgroundThread.Name = "Secondary";
                    backgroundThread.Start();
                    break;

                case "1":
                    p.PrintNumbers();
                    break;

                default:
                    Console.WriteLine("I don't know what you want - you get 1 thread!");
                    goto case "1";
            }
            // Do some additional work
            MessageBox.Show("I'm busy, working on the main thread");
            Console.ReadLine();

        }

        public void PrintNumbers()
        {
            // Display Thread Info
            Console.WriteLine("-> {0} is exececuting  PrintNUmbers()", Thread.CurrentThread.Name);

            // Print out numbers
            Console.WriteLine("Your NUmbers: ");
            for (int i = 0; i < 10; i++)
            {
                Console.WriteLine("{0}, ", i);
                Thread.Sleep(1000);
            }
            Console.WriteLine();
        }
    }
}
