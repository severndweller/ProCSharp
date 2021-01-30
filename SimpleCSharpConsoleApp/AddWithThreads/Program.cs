using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Diagnostics;

namespace AddWithThreads
{
    class Program
    {
        static AutoResetEvent waithandle = new AutoResetEvent(false);

        static void Main(string[] args)
        {
            Console.WriteLine("Adding with Thread Objects");
            Console.WriteLine("ID of thread in Main() is {0}", Thread.CurrentThread.ManagedThreadId);

            // Make an AddParams object to pass to the secondary thread
            AddParams ap  = new AddParams(10, 20);
            Thread t = new Thread(new ParameterizedThreadStart(Add));
            t.Start(ap);

            // Force a wait to let other threads finish
//            Thread.Sleep(5000);
            Console.ReadLine();

            // Now use the AutoResetEvent class to signal
            Thread t2 = new Thread(new ParameterizedThreadStart(AddWithSignal));

            // SETING the secondary thread as a background thread means the program will complete as soon as the primary thread's execution path is complete.
            t2.IsBackground = true;
            t2.Start(ap);
            Console.WriteLine("Thread started, now waiting..");
            waithandle.WaitOne();
            Console.WriteLine("Thread signalled");
            // Force a wait to let other threads finish
            //            Thread.Sleep(5000);
            //Console.ReadLine();

            // NOW Test the use of the TimerCallback and Time classes in setting up periodic method invocations
            TimerCallback timeCB = new TimerCallback(PrintTime);

            // Calling the timed callback in 3 seconds....
            Console.WriteLine("Calling the timed callback in 3 seconds....");


            var _ = new Timer(timeCB, "It was me wot called it", 3000, 1000);
            do
            {
                Console.WriteLine("NUmber of threads is {0}", Process.GetCurrentProcess().Threads.Count);
                Thread.Sleep(5000);
            } while (true);

            Console.ReadLine();
        }

        static void Add(object data)
        {
            if (data is AddParams)
            {
                Console.WriteLine("ID of thread in Add(): {0}", Thread.CurrentThread.ManagedThreadId);
                AddParams ap = (AddParams)data;
                Console.WriteLine("{0} + {1} = {2}", ap.a, ap.b, ap.a + ap.b);
            }
        }


        static void AddWithSignal(object data)
        {
            if (data is AddParams)
            {
                Console.WriteLine("ID of thread in AddWithSignal(): {0}", Thread.CurrentThread.ManagedThreadId);
                AddParams ap = (AddParams)data;
                Console.WriteLine("{0} + {1} = {2}", ap.a, ap.b, ap.a + ap.b);
                Thread.Sleep(3000);
                waithandle.Set();
            }
        }

        static void PrintTime (object state)
        {
            Console.WriteLine("PrintTime called at {0} on thread {1} on Background Thread? {2}", 
                DateTime.Now.ToString(), Thread.CurrentThread.ManagedThreadId, Thread.CurrentThread.IsBackground.ToString());
            Thread.Sleep(12200);
            Console.WriteLine("PrintTime ended at {0} on thread {1} on Background Thread? {2}",
                DateTime.Now.ToString(), Thread.CurrentThread.ManagedThreadId, Thread.CurrentThread.IsBackground.ToString());
        }

    }

    class AddParams
    {
        public int a, b;

        public AddParams(int numb1, int numb2)
        {
            a = numb1;
            b = numb2;
        }
    }

}
