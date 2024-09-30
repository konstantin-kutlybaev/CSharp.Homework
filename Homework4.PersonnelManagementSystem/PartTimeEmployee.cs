using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.ConstrainedExecution;
using System.Text;
using System.Threading.Tasks;

namespace Homework4.PersonnelManagementSystem
{
    public class PartTimeEmployee : Employee
    {
        public decimal PayPerHour { get; set; }
        public int HoursWorked { get; set; }
        public PartTimeEmployee(string name, decimal payPerHour, int hoursWorked) : base(name, 0) 
        { 
            this.HoursWorked = hoursWorked;
            this.PayPerHour = payPerHour;
        }

        public override decimal CalculateSalary()
        {
            return HoursWorked * PayPerHour;
        }
    }
}
