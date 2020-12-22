using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StaticDataAndMembers
{
    class SavingsAccount
    {
        public double currBalance;

        public static double currInterestRate;

        public SavingsAccount(double balance)
        {
            Console.WriteLine("In Instance ctor");
            currBalance = balance;
        }

        static SavingsAccount()
        {
            Console.WriteLine("In Static ctor");
            currInterestRate = 0.04;    // this is static data
        }

        public static void SetInterestRate(double newRate)
        {
            currInterestRate = newRate;
        }

        public static double GetInterestRate()
        { return currInterestRate; }

        public static double InterestRate
            {
            get => currInterestRate;
            set => currInterestRate = value;
            }
    }

}

