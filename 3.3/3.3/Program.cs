namespace _3._3
{
    public delegate void TaskDelegate(string taskDescription);

    class Program
    {
        // Список задач
        static List<string> tasks = new List<string>();

        // Делегаты для выполнения задач
        static TaskDelegate notificationDelegate = SendNotification;
        static TaskDelegate loggingDelegate = LogToFile;
        static TaskDelegate emailDelegate = SendEmail;

        static void Main(string[] args)
        {
            Console.WriteLine("=== ПРИЛОЖЕНИЕ ДЛЯ УПРАВЛЕНИЯ ЗАДАЧАМИ ===");

            while (true)
            {
                ShowMenu();
                string choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        AddTask();
                        break;
                    case "2":
                        ShowTasks();
                        break;
                    case "3":
                        ExecuteTask();
                        break;
                    case "4":
                        ExecuteAllTasks();
                        break;
                    case "5":
                        Console.WriteLine("Выход из программы...");
                        return;
                    default:
                        Console.WriteLine("Неверный выбор!");
                        break;
                }

                Console.WriteLine("\nНажмите любую клавишу для продолжения...");
                Console.ReadKey();
                Console.Clear();
            }
        }

        static void ShowMenu()
        {
            Console.WriteLine("\n=== МЕНЮ ===");
            Console.WriteLine("1. Добавить задачу");
            Console.WriteLine("2. Показать все задачи");
            Console.WriteLine("3. Выполнить задачу");
            Console.WriteLine("4. Выполнить все задачи");
            Console.WriteLine("5. Выйти");
            Console.Write("Выберите действие: ");
        }

        static void AddTask()
        {
            Console.Write("Введите описание задачи: ");
            string task = Console.ReadLine();
            tasks.Add(task);
            Console.WriteLine($"Задача добавлена: {task}");
        }

        static void ShowTasks()
        {
            if (tasks.Count == 0)
            {
                Console.WriteLine("Список задач пуст.");
                return;
            }

            Console.WriteLine("\n=== СПИСОК ЗАДАЧ ===");
            for (int i = 0; i < tasks.Count; i++)
            {
                Console.WriteLine($"{i + 1}. {tasks[i]}");
            }
        }

        static void ExecuteTask()
        {
            if (tasks.Count == 0)
            {
                Console.WriteLine("Нет задач для выполнения.");
                return;
            }

            ShowTasks();
            Console.Write("Выберите номер задачи для выполнения: ");

            if (int.TryParse(Console.ReadLine(), out int taskNumber) && taskNumber >= 1 && taskNumber <= tasks.Count)
            {
                string task = tasks[taskNumber - 1];

                Console.WriteLine("\n=== ВЫБОР ДЕЛЕГАТА ===");
                Console.WriteLine("1. Отправить уведомление");
                Console.WriteLine("2. Записать в журнал");
                Console.WriteLine("3. Отправить email");
                Console.Write("Выберите делегат: ");

                string delegateChoice = Console.ReadLine();
                TaskDelegate selectedDelegate = null;

                switch (delegateChoice)
                {
                    case "1":
                        selectedDelegate = notificationDelegate;
                        break;
                    case "2":
                        selectedDelegate = loggingDelegate;
                        break;
                    case "3":
                        selectedDelegate = emailDelegate;
                        break;
                    default:
                        Console.WriteLine("Неверный выбор делегата!");
                        return;
                }

                // Выполняем задачу с выбранным делегатом
                selectedDelegate(task);
                Console.WriteLine($"Задача выполнена с делегатом {selectedDelegate.Method.Name}");
            }
            else
            {
                Console.WriteLine("Неверный номер задачи!");
            }
        }

        static void ExecuteAllTasks()
        {
            if (tasks.Count == 0)
            {
                Console.WriteLine("Нет задач для выполнения.");
                return;
            }

            Console.WriteLine("\n=== ВЫБОР ДЕЛЕГАТА ДЛЯ ВСЕХ ЗАДАЧ ===");
            Console.WriteLine("1. Отправить уведомление");
            Console.WriteLine("2. Записать в журнал");
            Console.WriteLine("3. Отправить email");
            Console.Write("Выберите делегат: ");

            string delegateChoice = Console.ReadLine();
            TaskDelegate selectedDelegate = null;

            switch (delegateChoice)
            {
                case "1":
                    selectedDelegate = notificationDelegate;
                    break;
                case "2":
                    selectedDelegate = loggingDelegate;
                    break;
                case "3":
                    selectedDelegate = emailDelegate;
                    break;
                default:
                    Console.WriteLine("Неверный выбор делегата!");
                    return;
            }

            // Выполняем все задачи с выбранным делегатом
            Console.WriteLine("\n=== ВЫПОЛНЕНИЕ ВСЕХ ЗАДАЧ ===");
            foreach (string task in tasks)
            {
                selectedDelegate(task);
            }
            Console.WriteLine($"Все задачи выполнены с делегатом {selectedDelegate.Method.Name}");
        }

        // Методы-делегаты
        static void SendNotification(string task)
        {
            Console.WriteLine($"УВЕДОМЛЕНИЕ: Задача '{task}' требует выполнения!");
        }

        static void LogToFile(string task)
        {
            Console.WriteLine($"ЗАПИСЬ В ЖУРНАЛ: [{DateTime.Now:HH:mm:ss}] Задача: {task}");
        }

        static void SendEmail(string task)
        {
            Console.WriteLine($"EMAIL ОТПРАВЛЕН: Уведомление о задаче '{task}' отправлено по email");
        }
    }
}
