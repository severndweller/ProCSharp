using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Employees
{
	abstract partial class Employee
	{
		// Field Data
		protected string empName;
		protected int empID;
		protected float currPay;
		protected int empAge;
		protected string empSSN = "";
		protected BenefitPackage benefitPackage = new BenefitPackage();

		public class AwardPackage
		{
			public double ComputeAwards()
			{
				return 1050.0;
			}
		}

		// Constructors
		public Employee() { }

		public Employee(string name, int id, float pay)
			: this(name, 0, id, pay) { }
		public Employee(string name, int age, int id, float pay)
		{
			Name = name;
			ID = id;
			Pay = pay;
			Age = age;
			//empName = name;
			//empID = id;
			//currPay = pay;
			//empAge = age;
		}

		public Employee(string name, int age, int id, float pay, string ssn)
			:this(name, age, id, pay)
        {
			empSSN = ssn;
        }
	}


}
