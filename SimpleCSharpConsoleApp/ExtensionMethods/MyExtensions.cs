using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;

namespace ExtensionMethods
{
    static class MyExtensions
    {
        // This mthod allows any object to display the assembly it is defined in
        public static void DisplayDefiningAssembly (this object obj)
        {
            Console.WriteLine("{0} lives here: => {1}\n", obj.GetType().Name, Assembly.GetAssembly(obj.GetType()).GetName().Name);
        }

        // This method allows any integer to reverse its digits
        // For example, 56 would return 65
        public static int ReverseDigits (this int i)
        {
            char[] digits = i.ToString().ToCharArray();
            // Reverse those digitywidgeties
            Array.Reverse(digits);

            // Put the new string into a new array
            string newString = new string(digits);

            return int.Parse(newString);
        }
    }
}
