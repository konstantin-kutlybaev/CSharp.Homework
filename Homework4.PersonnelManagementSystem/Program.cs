using Homework4.PersonnelManagementSystem;

class Program
{
    static void Main(string[] args)
    {
        var employeeManager = new EmployeeManager<Employee>();

        while (true)
        {
            
            Console.WriteLine("Выберите действие: ");
            Console.WriteLine("1. Добавить постянного сотрудника");
            Console.WriteLine("2. Добавить почасового сотрудника");
            Console.WriteLine("3. Получить информацию о сотруднике");
            Console.WriteLine("4. Обновить данные сотрудника");
            Console.WriteLine("5. Выйти");
            

            var choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    AddFullTimeEmployee(employeeManager);
                    break;
                case "2":
                    AddPartTimeEmployee(employeeManager);
                    break;
                case "3":
                    GetEmployee(employeeManager);
                    break;
                case "4":
                    UpdateEmployee(employeeManager);
                    break;
                case "5":
                    return;
                default:
                    Console.WriteLine("Неверный выбор. Попробуйте снова.");
                    break;
            }
        }
        static void AddFullTimeEmployee(EmployeeManager<Employee> employeeManager)
        {
            Console.Write("Введите имя постоянного сотрудника: ");
            var name = Console.ReadLine();
            Console.Write("Введите базовую зарплату: ");
            var salary = Convert.ToDecimal(Console.ReadLine());
            var employee = new FullTimeEmloyee(name, salary);
            employeeManager.Add(employee);
            Console.WriteLine("Постоянный сотрудник добавлен.");
            Console.ReadKey();
            Console.Clear();
        }
        static void AddPartTimeEmployee(EmployeeManager<Employee> employeeManager)
        {
            Console.Write("Введите имя почасового сотрудника: ");
            var name = Console.ReadLine();
            Console.Write("Введите почасовую ставку: ");
            var payPerHour = Convert.ToDecimal(Console.ReadLine());
            Console.Write("Введите количество отработанных часов: ");
            var hoursWorked = Convert.ToInt32(Console.ReadLine());
            var employee = new PartTimeEmployee(name, payPerHour, hoursWorked);
            employeeManager.Add(employee);
            Console.WriteLine("Почасовой сотрудник добавлен.");
            Console.ReadKey();
            Console.Clear();
        }
        static void GetEmployee(EmployeeManager<Employee> employeeManager)
        {
            Console.Write("Введите имя сотрудника: ");
            var name = Console.ReadLine();
            var employee = employeeManager.Get(name);
            if (employee != null)
            {
                Console.WriteLine($"Имя: {employee.Name}");
                Console.WriteLine($"Зарплата: {employee.CalculateSalary()}");
                Console.ReadKey();
                Console.Clear();
            }
            else
            {
                Console.WriteLine("Сотрудник не найден.");
                Console.ReadKey();
                Console.Clear();
            }
        }
        static void UpdateEmployee(EmployeeManager<Employee> employeeManager)
        {
            Console.Write("Введите имя сотрудника для обновления: ");
            var name = Console.ReadLine();
            var updateEmployee = employeeManager.Get(name);
            if (updateEmployee != null)
            {
                if (updateEmployee is FullTimeEmloyee fullTimeEmployee)
                {
                    Console.Write("Введите новое имя сотрудника: ");
                    fullTimeEmployee.Name = Console.ReadLine();
                    Console.Write("Введите новую базовую зарплату: ");
                    fullTimeEmployee.BaseSalary = Convert.ToDecimal(Console.ReadLine());
                }
                else if (updateEmployee is PartTimeEmployee partTimeEmployee)
                {
                    Console.Write("Введите новое имя сотрудника: ");
                    partTimeEmployee.Name = Console.ReadLine();
                    Console.Write("Введите новую почасовую ставку: ");
                    partTimeEmployee.PayPerHour = Convert.ToDecimal(Console.ReadLine());
                    Console.Write("Введите новое количество отработанных часов: ");
                    partTimeEmployee.HoursWorked = Convert.ToInt32(Console.ReadLine());
                }
                employeeManager.Update(updateEmployee);
                Console.WriteLine("Данные сотрудника обновлены.");
                Console.ReadKey();
                Console.Clear();
            }
            else
            {
                Console.WriteLine("Сотрудник не найден.");
                Console.ReadKey();
                Console.Clear();
            }
        }
    }
}
