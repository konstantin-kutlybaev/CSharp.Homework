using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Homework4.PersonnelManagementSystem
{
    public abstract class Employee
    {
        public string Name { get; set; }
        public decimal BaseSalary { get; set; }
        public Employee(string name, decimal baseSalary) 
        {
            this.Name = name;
            this.BaseSalary = baseSalary;
        }

        public abstract decimal CalculateSalary();
        
    }
}
