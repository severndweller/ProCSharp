using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FunWithLinqExpressions
{
    class Program
    {
        static void Main(string[] args)
        {
            ProductInfo[] itemsInStock = {
                new ProductInfo() { Name = "Jemima" },
                new ProductInfo() { Name = "Steve" },
                new ProductInfo() { Name = "Kim" },
            };

            ProductInfo[] itemsInStock2 = new[]
            {
                new ProductInfo() { Name = "Jess", Description="GO Easy", NumberInStock = 16000 },
                new ProductInfo() { Name = "Mike", NumberInStock=15 },
                new ProductInfo() { Name = "Arnold", Description="Wild one" },
            };

            var nameDesc = from p in itemsInStock2 select new { p.Name, p.Description };

            foreach (var item in nameDesc)
            {
                Console.WriteLine("Anon Type : {0}", item.ToString());
            }

            foreach (ProductInfo item in itemsInStock2)
            {
                Console.WriteLine(item.ToString());
            }
            Console.ReadLine();
            Array myWants = GetNewAnonTypesBack();

            foreach (object item in myWants)
            {
                Console.WriteLine("Passed back wants {0}", item.ToString());
            }

            Console.ReadLine();
        }

        static Array GetNewAnonTypesBack()
        {
            ProductInfo[] wantedStock = new[]
            {
                new ProductInfo() { Name = "Jess", Description="GO Easy", NumberInStock = 16000 },
                new ProductInfo() { Name = "Jess", Description="Am Easy", NumberInStock = 16000 },
                new ProductInfo() { Name = "Jess", Description="ZZZZZZs", NumberInStock = 16000 },
                new ProductInfo() { Name = "Mike", NumberInStock=15 },
                new ProductInfo() { Name = "Arnold", Description="Wild one" },
            };

            var nbrMatches = (from p in wantedStock where p.NumberInStock > 5 select p).Count();

            Console.WriteLine("NUmber of matches {0}", nbrMatches);

            Console.WriteLine("------------------");

            var elements1 = (from p in wantedStock where p.NumberInStock > 5 select p);
            foreach (var item in elements1)
            {
                Console.WriteLine("Unreversed {0}", item.ToString());
            }

            Console.WriteLine("------------------");

            var elements2 = (from p in wantedStock where p.NumberInStock > 5 select p).Reverse();
            foreach (var item in elements2)
            {
                Console.WriteLine("REVERSED {0}", item.ToString());
            }

            Console.WriteLine("------------------");

            foreach (var item in elements2.Reverse())
            {
                Console.WriteLine("RE-REVERSED {0}", item.ToString());
            }

            Console.WriteLine("------------------");
            Console.WriteLine("------------------");
            Console.WriteLine("------------------");

            var elements3 = (from p in wantedStock orderby p.Name, p.Description ascending select p).Reverse();
            foreach (var item in elements3)
            {
                Console.WriteLine("order ascending Name & Description {0}", item.ToString());
            }

            Console.WriteLine("+++++++++++++++++++++++");

            var elements4 = (from p in wantedStock orderby p.Name descending select p).Reverse();
            foreach (var item in elements4)
            {
                Console.WriteLine("order descending {0}", item.ToString());
            }

            Console.WriteLine("+++++++++++++++++++++++");

            var elements5 = (from p in wantedStock orderby p.Name select p).Reverse();
            foreach (var item in elements5)
            {
                Console.WriteLine("ORDERED but neither asc/desc {0}", item.ToString());
            }

            Console.WriteLine("+++++++++++++++++++++++");



            var nameDesc = from p in wantedStock select new { p.Name, p.Description };
            return nameDesc.ToArray();

        }
    }
}
