using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace CustomInterface
{
    class Program
    {
        static void Main(string[] args)
        {
            Shape[] myShapes = {new Hexagon(), new Circle(), new Triangle("Joe"), new Circle("Jojo")};

            for (int i = 0; i < myShapes.Length; i++)
            {
                if (myShapes[i] is IPointy ip)
                {
                    Console.WriteLine("This is a {0} called {1} and has {2} points", 
                        myShapes[i].GetType(), myShapes[i].PetName, ip.Points);
                }
            }

            foreach (Shape  thisShape in myShapes)
            {
                IPointy ip2 = thisShape as IPointy;
                if (!(ip2 is null))
                {
                    Console.WriteLine("This again is a {0} called {1} and has {2} points",
                        thisShape.GetType(), thisShape.PetName, ip2.Points);
                }
                if (thisShape is IDraw3D ip)
                    DrawIn3D(ip);
            }

            Console.WriteLine("Looking for the first pointy shape in the array of shapes and it is {0}", 
                ReturnFirstPointyShape(myShapes));

            Console.ReadLine();
        }

        static void DrawIn3D (IDraw3D itf3d)
        {
            Console.WriteLine("Drawing IDraw3D compatible type");
            itf3d.Draw3D();
        }

        static IPointy ReturnFirstPointyShape (Shape[] shapes)
        {
            foreach (var shape in shapes)
            {
                if (shape is IPointy ip)
                    return ip;
            }

            return null;
        }
    }
}
