using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeApp
{
    class Program
    {
        static void Main(string[] args)
        {
            Employee myEmployee = new Employee("Marvin the para", 456, 30_000, 55);
            myEmployee.GiveBonus(1000);
            myEmployee.DisplayStats();
            // Use get/set to interact with the object's name
            myEmployee.SetName("Maryldkgdsggggggggggggggg");
            Console.WriteLine("Employee is named {0}", myEmployee.GetName());
            myEmployee.Age++;
            Console.WriteLine("Tis your birthday");
            myEmployee.DisplayStats();
            Console.WriteLine("You're on £{0}. Have a pay rise!",myEmployee.Pay);
            myEmployee.Pay += 1_000;
            myEmployee.DisplayStats();
            Console.ReadLine();
        }
    }
}

