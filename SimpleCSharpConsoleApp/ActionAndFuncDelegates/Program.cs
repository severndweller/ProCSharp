using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ActionAndFuncDelegates
{
    class Program
    {
        static void DisplayMessage (string msg, ConsoleColor txtColour, int printCount)
        {
            // Set the colour of console text
            ConsoleColor previous = Console.ForegroundColor;
            Console.ForegroundColor = txtColour;

            for (int i = 0; i < printCount; i++)
            {
                Console.WriteLine(msg);
            }

            // Restore colour
            Console.ForegroundColor = previous;
        }

        static int Add(int x, int y)
        {
            return x + y;
        }

        static string SumToString (int x, int y)
        {
            return (x + y).ToString();
        }
        static void Main(string[] args)
        {
            Console.WriteLine("Fun with Action and Func *******");
            // Use the action delegate to point to DisplayMessage
            Action<string, ConsoleColor, int> actionTarget = new Action<string, ConsoleColor, int>(DisplayMessage);
            actionTarget("Action Message", ConsoleColor.Yellow, 5);
            Console.WriteLine("Back to normal");
            Console.ReadLine();

            Func<int, int, int> funcTarget = new Func<int, int, int>(Add);
            Console.WriteLine(funcTarget(40, 50));
            Console.ReadLine();

            Func<int, int, string> funcTarget2 = new Func<int, int, string>(SumToString);
            Console.WriteLine(funcTarget2(10, 15));
            Console.ReadLine();


        }
    }
}
