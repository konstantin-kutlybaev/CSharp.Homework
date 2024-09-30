using Homework5.Exception;
using System.Reflection.Metadata;

class Program
{
    static void Main(string[] args)
    {
        UserManager userManager = new UserManager();

        while (true)
        {
            Console.WriteLine("Выберите операцию:");
            Console.WriteLine("1. Добавить пользователя");
            Console.WriteLine("2. Удалить пользователя");
            Console.WriteLine("3. Вывести список пользователей");
            Console.WriteLine("4. Выход");
            Console.Write("Ваш выбор: ");

            string choice = Console.ReadLine();

            try
            {
                switch (choice)
                {
                    case "1":
                        Console.Write("Введите Id пользователя: ");
                        int id = Convert.ToInt32(Console.ReadLine());
                        Console.Write("Введите имя пользователя: ");
                        string name = Console.ReadLine();
                        Console.Write("Введите email пользователя: ");
                        string email = Console.ReadLine();
                        userManager.AddUser(new User(id, name, email));
                        Console.WriteLine("Пользователь добавлен.");
                        break;

                    case "2":
                        Console.Write("Введите Id пользователя для удаления: ");
                        int removeId = Convert.ToInt32(Console.ReadLine());
                        userManager.RemoveUser(removeId);
                        Console.WriteLine("Пользователь удален.");
                        break;

                    case "3":
                        userManager.ListUsers();
                        break;

                    case "4":
                        return;

                    default:
                        Console.WriteLine("Неверный выбор. Попробуйте снова.");
                        break;
                }
            }
            catch (FormatException)
            {
                Console.WriteLine("Ошибка: Неверный формат ввода. Пожалуйста, введите число.");
            }
            catch (UserAlreadyExistsException ex)
            {
                Console.WriteLine($"Ошибка: {ex.Message}");
            }
            catch (UserNotFoundException ex)
            {
                Console.WriteLine($"Ошибка: {ex.Message}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Неизвестная ошибка: {ex.Message}");
            }
        }
    }
}