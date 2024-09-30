using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Homework4.PersonnelManagementSystem
{
    internal interface IEmployeeManager<T>
    {
       public void Add(T employee);
       public T Get(string name);
       public void Update(T employee);
    }
}
