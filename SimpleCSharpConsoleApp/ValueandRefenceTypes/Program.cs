using System;

namespace ValueandRefenceTypes
{
    class Program
    {

        class ShapeInfo
        {
            public string InfoString;
            public int seedValue;
            public ShapeInfo(string info, int seed)
            {
                InfoString = info;
                seedValue = seed;
            }
        }

        struct Rectangle
        {
            public ShapeInfo rectInfo;
            public int rectTop, rectLeft, rectBottom, rectRight;
            public Rectangle(string info, int top, int left, int bottom, int right, int seed)
            {
                rectInfo = new ShapeInfo(info, seed);
                rectInfo.InfoString = info;
                rectTop = top;
                rectLeft = left;
                rectBottom = bottom;
                rectRight = right;
            }

            public void Display()
            {
                Console.WriteLine("String = {0}, Top = {1}, Left = {2}, Bottom = {3}, Right = {4}, Seed = {5}",
                        rectInfo.InfoString, rectTop, rectLeft, rectBottom, rectRight, rectInfo.seedValue);
            }
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

        class PointRef
        {
            public int X;
            public int Y;

            public PointRef()
            {

            }

            public PointRef(int x, int y)
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
            ValueTypeContainingRefType();
            Console.ReadLine();
        }

        static void ValueTypeAssignment()
        {
            Console.WriteLine("Assigning Static Types");
            Point p1 = new Point(10, 10);
            Point p2 = p1;

            // Print Both
            p1.Display();
            p2.Display();


            p2.X += 10;
            p2.Y += 1;
            p2.Display();


            Console.WriteLine("HERE  ************************");
            PointRef np1 = new PointRef();
            PointRef np2 = np1;
            np1.Display();
            np2.Display();
            np2.X = 100;
            np2.Y = 200;
            np1.Display();
            np2.Display();

        }
        static void ReferenceTypeAsignment()
        {
            Console.WriteLine("Assigning ref types");
            PointRef p1 = new PointRef(10, 10);
            PointRef p2 = p1;
            p1.Display();
            p2.Display();

            p1.X = 150;
            Console.WriteLine("\n=> Changed p1.X\n");
            p1.Display();
            p2.Display();

        }

        static void ValueTypeContainingRefType()
        {
            Console.WriteLine("creating r1");
            Rectangle r1 = new Rectangle("First Rect", 10, 50, 10, 50, 678);

            Console.WriteLine("assigning r2 to r1");
            Rectangle r2 = r1;

            // Change some values of r2
            r2.rectInfo.InfoString = "This is new info";
            r2.rectInfo.seedValue = 789;
            r2.rectBottom = 4444;

            r1.Display();
            r2.Display();
        }
    }
}
