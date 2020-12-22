using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Employees
{
    abstract partial class Employee
    {

        // Accesssors and Mutators
        public int Age
        {
            get => empAge;
            set => empAge = value;
        }

        public int ID
        {
            get { return empID; }
            set { empID = value; }
        }

        //Property get and set accessor syntax
        public string Name
        {
            get { return empName; }
            set
            {
                // Apply business logic 
                if (value.Length > 15)
                    Console.WriteLine("Error, Name exceeds 15 characters in length!");
                else
                    empName = value;
            }
        }

        // Expression bodied member syntax accessors
        public float Pay
        {
            get => currPay;
            set => currPay = value;
        }

        // Defunct
        public string GetName()
        {
            return empName;
        }

        // Defunct
        public void SetName(string name)
        {
            // Apply business logic 
            if (name.Length > 15)
                Console.WriteLine("Error, Name exceeds 15 characters in length!");
            else
                empName = name;
        }




        // Methods
        public virtual void GiveBonus(float amount)
        {
            Console.WriteLine("Giving a bonus of {0}", amount);
            currPay += amount;
        }

        public virtual void DisplayStats()
        {
            Console.WriteLine("Name: {0}", Name);
            Console.WriteLine("ID: {0}", ID);
            Console.WriteLine("Pay: {0}", Pay);
            Console.WriteLine("Age: {0}", Age);
        }

        public double GetBenefitCost()
        { return benefitPackage.ComputePayDeduction(); }

        public BenefitPackage Benefits
        {
            get { return benefitPackage; }
            set { benefitPackage = value; }
        }


    }
}
