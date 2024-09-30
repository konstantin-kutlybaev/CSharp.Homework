using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Homework5.Exception
{
    public class UserManager
    {
        List<User> users = new List<User>();

        public void AddUser(User user)
        {
            if(users.Exists(u => u.Id == user.Id))
            {
                throw new UserAlreadyExistsException("Пользователь с таким Id уже существует.");
            }
            users.Add(user);
        }
        public void RemoveUser(int id)
        {
            var user = users.Find(i => i.Id == id);
            if (user != null)
            { 
                users.Remove(user);
            }
        }
        public User GetUser(int id)
        {
            var user = users.Find(i => i.Id == id);
            if (user == null)
            {
                throw new UserNotFoundException("Пользователь не найден.");
            }
            return user;
        }
        public void ListUsers()
        {
            if (users.Count == 0)
            {
                Console.WriteLine("Список пользователей пуст.");
                return;
            }

            foreach (var user in users)
            {
                Console.WriteLine($"Id: {user.Id}, Name: {user.Name}, Email: {user.Email}");
            }
        }

    }
}
