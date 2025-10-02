using System.Security.Cryptography.X509Certificates;

namespace _2._6
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Employee persona1 = new Employee("Владимир",22,"Менеджер",3200);
            persona1.MoneyToYear(3200);
            persona1.PrintInfo("Владимир", 22, "Менеджер", 3200);
            
        }

        class Employee
        {
            private string _name;
            private int _age;
            private string _job;
            private int _money;

            public Employee(string name, int age, string job, int money)
            {
                _name = name;
                _age = age;
                _job = job;
                _money = money;
                
                
            }
            public double MoneyToYear(double money)
            {
                return _money * 12;
            }
            public void PrintInfo(string name, int age, string job, int money)
            {
                Console.WriteLine($"Сотрудник {name}; Возраст:{age}");
                Console.WriteLine($"Должность {job}; Зарплата:{money}");
                Console.WriteLine($"Годовая зарплата {money*12}");
            }
        }

    }
}
