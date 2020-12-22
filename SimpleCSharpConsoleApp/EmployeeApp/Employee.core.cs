using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeApp
{
	partial class Employee
	{
		// Field Data
		private string empName;
		private int empID;
		private float currPay;
		private int empAge;


		// Constructors
		public Employee() { }

		public Employee(string name, int id, float pay)
			: this(name, id, pay, 0) { }
		public Employee(string name, int id, float pay, int age)
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
	}


}
