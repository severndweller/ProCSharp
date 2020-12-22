using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Employees
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("******* The Employee Class Heirarchy ******");
            SalesPerson fred = new SalesPerson();
            fred.Age = 38;
            fred.Name = "Fred";
            fred.SalesNumber = 50;

            Manager chucky = new Manager("Chucky", 50, 92, 100000, "333-23-2322", 9000);
            double cost = chucky.GetBenefitCost();
            Console.WriteLine("Manager {0} has benefits of {1}", chucky.Name, cost.ToString());
            chucky.GiveBonus(300);
            chucky.DisplayStats();
            SalesPerson fran = new SalesPerson("Fran", 43, 93, 3000, "932-32-3232", 31);
            fran.GiveBonus(200);
            fran.DisplayStats();

            Employee.AwardPackage awardPackage = new Employee.AwardPackage();
            double awardAmount = awardPackage.ComputeAwards();
            Console.WriteLine("Award Package of {0}", awardAmount.ToString());

            //Employee randomEmp = new Employee();
            Console.ReadLine();
        }
    }
}
