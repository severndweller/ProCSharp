using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ObjectInitializers
{
    class Point
    {
        public int X { get; set; }
        public int Y { get; set; }

        public Point(int XVal, int YVal)
        {
            X = XVal;
            Y = YVal;
        }
        public Point() { }

        public void DisplayStats()
        {
            Console.WriteLine("[{0}, {1}]", X, Y);
        }
    }
}
