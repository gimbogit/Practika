namespace _3._2
{
    public class Notification
    {
        
        public event Action<string> OnMessage;
        public event Action<string> OnCall;
        public event Action<string> OnEmail;

        public void SendMessage(string text)
        {
            OnMessage?.Invoke(text);
        }

        public void MakeCall(string number)
        {
            OnCall?.Invoke(number);
        }

        public void SendEmail(string address)
        {
            OnEmail?.Invoke(address);
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
          
            Notification notification = new Notification();

            notification.OnMessage += (text) =>
            {
                Console.WriteLine($"СООБЩЕНИЕ: {text}");
            };

            notification.OnCall += (number) =>
            {
                Console.WriteLine($"ЗВОНОК: Входящий вызов с номера {number}");
            };

            notification.OnEmail += (address) =>
            {
                Console.WriteLine($"EMAIL: Новое письмо на адрес {address}");
            };


            while (true)
            {
                Console.WriteLine("\n=== СИСТЕМА УВЕДОМЛЕНИЙ ===");
                Console.WriteLine("1. Отправить сообщение");
                Console.WriteLine("2. Сделать звонок");
                Console.WriteLine("3. Отправить email");
                Console.WriteLine("4. Выйти");
                Console.Write("Выберите действие: ");

                string choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        Console.Write("Введите текст сообщения: ");
                        string message = Console.ReadLine();
                        notification.SendMessage(message);
                        break;

                    case "2":
                        Console.Write("Введите номер телефона: ");
                        string number = Console.ReadLine();
                        notification.MakeCall(number);
                        break;

                    case "3":
                        Console.Write("Введите email адрес: ");
                        string email = Console.ReadLine();
                        notification.SendEmail(email);
                        break;

                    case "4":
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
    }
}
