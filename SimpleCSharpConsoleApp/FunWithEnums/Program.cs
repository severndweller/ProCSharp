using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FunWithEnums
{
    class Program
    {

        enum RoleType
        {
            topman,
            foreman,
            labourer,
            secretary
        }

        struct Point
        {
            // fields of the structure
            public int X;
            public int Y;

            public Point(int x, int y)
            {
                X = x; Y = y;
            }


            public void Increment()
            {
                X++; Y++;
            }

            public void Decrement()
            {
                X--; Y--;
            }

            public void Display()
            {
                Console.WriteLine("X has value {0}, and Y has value {1}", X, Y);
            }
        }

        static void Main(string[] args)
        {
            RoleType hmRole = RoleType.secretary;
            Console.WriteLine("hi");
            Console.WriteLine(hmRole.ToString());
            Console.WriteLine(Enum.GetUnderlyingType(typeof(RoleType)));
            Console.WriteLine(Enum.GetValues(typeof(RoleType)));
            System.Array roleValues = Enum.GetValues(typeof(RoleType));

            Array rtArray = Enum.GetValues(typeof(RoleType));
            foreach (var item in rtArray)
            {
                Console.WriteLine("Type {0} has the value {0:D}", item, item);
            }
            Console.WriteLine ("******************************");
            Point myPoint;
            myPoint.X = 349;
            myPoint.Y = 76;
            myPoint.Display();

            Point myP2 = new Point();
            //myP2.X = 1;
            //myP2.Y = 4;
            myP2.Display();

            Point p3 = new Point(6, 7);
            p3.Display();
            Console.ReadLine();
        }


    }
}
