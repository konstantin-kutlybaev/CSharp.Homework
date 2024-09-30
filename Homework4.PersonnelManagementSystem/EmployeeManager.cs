using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Homework4.PersonnelManagementSystem
{
    public class EmployeeManager<T> : IEmployeeManager<T> where T : Employee
    {
        List<T> employees = new List<T>();

        public void Add(T employee)
        {
            employees.Add(employee);
        }
       public T Get(string name)
        {
            return employees.Find(e => e.Name == name);
        }

        public void Update(T employee)
        {
            var updateEmployee = Get(employee.Name);
            if (updateEmployee != null)
            {
                updateEmployee.BaseSalary = employee.BaseSalary;
                updateEmployee.Name = employee.Name;
                if (updateEmployee is PartTimeEmployee partTimeEmployee)
                {
                    updateEmployee.Name = employee.Name;
                    (updateEmployee as PartTimeEmployee).PayPerHour = partTimeEmployee.PayPerHour;
                    (updateEmployee as PartTimeEmployee).HoursWorked = partTimeEmployee.HoursWorked;
                }
            }
        }
    }
}
