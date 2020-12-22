using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ImplicitlyTypedLocalVars
{
    class Program
    {
        static void Main(string[] args)
        {
            //DeclareImplicitVars();
            //SwitchTests();
            //DayOfWeekTest();

            object myChoice;
            Console.WriteLine("Give me an input");
            myChoice = Console.ReadLine();

            switch (myChoice)
            {
                //case 1:
                //    Console.WriteLine("this is 1");
                //    return;
                case int i when i < 10:
                    Console.WriteLine("It was an integer < 10 {i.Tostring}");
                    break;
                case int i:
                    Console.WriteLine("It was an integer {i.Tostring}");
                    break;
                case string s:
                    Console.WriteLine("It was a string {0}", s.ToString());
                    break;
                default:
                    Console.WriteLine("this is not it");
                    break;
            }
            Console.WriteLine("Reached the end of the switch");
            Console.ReadLine();
        }

        private static void DayOfWeekTest()
        {
            Console.WriteLine(DayOfWeek.Monday);
            Console.WriteLine(Enum.Parse(typeof(DayOfWeek), "Monday"));
            Console.WriteLine(DayOfWeek.Thursday.ToString());
            DayOfWeek thisVal = DayOfWeek.Friday;
            try
            {
                thisVal = (DayOfWeek)Enum.Parse(typeof(DayOfWeek), Console.ReadLine());
            }

            catch (Exception e)
            {

            }
            switch (thisVal)
            {
                case DayOfWeek.Sunday:
                case DayOfWeek.Monday:
                    Console.WriteLine("Sunday or Monday");
                    return;
                //                    break;
                default:
                    Console.WriteLine("Defualt hit");
                    break;
            }
            Console.WriteLine("Done with this");
        }


        private static void SwitchTests()
        {
            Console.WriteLine("1 [C#], 2[VB]");
            bool valid;
            do
            {
                valid = true;
                Console.WriteLine("Take your preference");
                string choice = Console.ReadLine();
                switch (choice)
                {
                    case "C#":
                        Console.WriteLine("C# is the winner");
                        break;

                    case "VB":
                        Console.WriteLine("VB is the winner");
                        break;

                    default:
                        Console.WriteLine("No-one is the winner");
                        valid = false;
                        break;
                }
            } while (!valid);
            Console.WriteLine();
        }

        static void DeclareImplicitVars()
        {
            var myInt = 0;
            var myBool = false;
            var myString = "Time marches on...";
            Console.WriteLine("Type of myInt is {0}", myInt.GetType().Name);
            Console.WriteLine("Type of myBool is {0}", myBool.GetType().Name);
            Console.WriteLine("Type of myString is {0}", myString.GetType().Name);
            Console.ReadLine();
            for (int i = 0; i < 10; i++)
            {
                Console.WriteLine("Loop is at {0}", i);
                if (i > 5)
                {
                    break;
                }
            }
            int[] myIntArray = new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };
            int[] secondarry = new int[] { 1, 3, 5 };
            string[] strArray = new string[] { "Hi", "There" };

            foreach (var item in myIntArray)
            {
                Console.WriteLine("At {0}", item);
                if (item > 2)
                {
                    break;
                }
            }
        }
    }
}
