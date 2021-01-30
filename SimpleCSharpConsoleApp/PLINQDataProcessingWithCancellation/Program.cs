using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace PLINQDataProcessingWithCancellation
{
    class Program
    {

        static CancellationTokenSource cancelToken = new CancellationTokenSource();
        static void Main(string[] args)
        {
            Console.WriteLine("Hit any key to start processing");
            Console.ReadKey();

            Console.WriteLine("Processing");
            Task.Factory.StartNew(() => ProcessIntData());
            //ProcessIntData();
            Console.WriteLine("Hit Q to quit");
            string answer = Console.ReadLine();
            if (answer.Equals("Q", StringComparison.OrdinalIgnoreCase))
            {
                cancelToken.Cancel();
            }
        }

        static void ProcessIntData()
        {
            // Get a very large array of integers
            int[] source = Enumerable.Range(1, 1_000_000_0).ToArray();
            Console.WriteLine("Array length is {0}", source.Length);
            // Find the numbers where num % 3 == 0 is true, returned

            // SINGULAR LINQ
//            var threeMultiples = from num in source where (num % 3 == 0) orderby num descending select num;
//            Console.WriteLine("Number of items divisble by 3 is {0}", threeMultiples.ToArray().Length);

            // Paralel LINQ
            Console.WriteLine("In parallel");
            try
            {
                var threeMultiples2 = from num in source.AsParallel().WithCancellation(cancelToken.Token) 
                    where (num % 3 == 0) orderby num descending select num;
                Console.WriteLine("Number of items divisble by 3 is {0}", threeMultiples2.ToArray().Length);

            }
            catch (OperationCanceledException ex)
            {
                Console.WriteLine("Operation cancelled", ex.Message);
            };

        }
    }
}
