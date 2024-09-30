using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Homework5.Exception
{
    public class User
    {
        public  int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public User(int id, string name, string email) 
        {
            this.Id = id;
            this.Name = name;
            this.Email = email;
        }
    }
}
