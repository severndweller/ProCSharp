using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ObjectInitializers
{
    class Program
    {
        static void Main(string[] args)
        {
            Point firstPoint = new Point();
            firstPoint.X = 10;
            firstPoint.Y = 10;
            firstPoint.DisplayStats();

            // or make a point via a  custome constructor
            Point secondPoint = new Point(20, 20);
            secondPoint.DisplayStats();

            // or make a point using object syntax
            Point thirdPoint = new Point{X = 30, Y = 30};
            thirdPoint.DisplayStats();
            Console.ReadLine();
        }
    }
}
