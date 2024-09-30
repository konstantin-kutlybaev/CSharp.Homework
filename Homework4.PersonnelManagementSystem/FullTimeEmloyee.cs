using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Homework4.PersonnelManagementSystem
{
    public class FullTimeEmloyee : Employee
    {
        public FullTimeEmloyee(string name, decimal baseSalary) : base(name, baseSalary) { }

        public override decimal CalculateSalary()
        {
            return BaseSalary;
        }
    }
}
