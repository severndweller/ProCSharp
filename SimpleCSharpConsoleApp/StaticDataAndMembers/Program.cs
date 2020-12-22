using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StaticDataAndMembers
{

    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("FUn with Static Data");

            SavingsAccount s1 = new SavingsAccount(50);
            Console.WriteLine("Interest rate is {0}", SavingsAccount.InterestRate);

            SavingsAccount.SetInterestRate(0.08);
            Console.WriteLine("Interest rate is {0}", SavingsAccount.InterestRate);


            SavingsAccount s2 = new SavingsAccount(100);
            Console.WriteLine("Interest rate is {0}", SavingsAccount.InterestRate);


            Console.ReadLine();

        }
    }
}
