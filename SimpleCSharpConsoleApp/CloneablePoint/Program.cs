using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CloneablePoint
{
    class Program
    {
        static void Main(string[] args)
        {
            Point p1 = new Point(50, 50);
            Point p2 = p1;
            p2.X = 0;
            Console.WriteLine(p1);
            Console.WriteLine(p2);

            Console.WriteLine("===============");
            Point p3 = new Point(100, 100, "Jane");
            Point p4 = (Point) p3.Clone();
            p4.X = 0;
            Console.WriteLine(p3);
            Console.WriteLine(p4);
            Console.WriteLine("Changing P4 PetName");
            p4.desc.Petname = "Mikey";
            Console.WriteLine(p3);
            Console.WriteLine(p4);
            Console.ReadLine();
            
        }
    }
}
