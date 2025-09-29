namespace _1._1._1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            while (true)
            {
                Console.WriteLine("Выберите операцию");
                Console.WriteLine("1)Из Цельсия в Фаренгейты");
                Console.WriteLine("2)Из Фаренгейта в Цельсии");
                byte numOfOperation = Convert.ToByte(Console.ReadLine());

                switch (numOfOperation)
                {
                    case 1:
                        Console.WriteLine("Введите значение в цельсиях: ");
                        int celsia = Convert.ToInt32(Console.ReadLine());

                        int toFaren = (celsia * 9) / 5 + 32;
                        Console.WriteLine($"{celsia} градусов по Цельсию равен {toFaren} градусам по Фаренгейту.");
                        Console.ReadKey();
                        Console.Clear();
                        break;
                        case 2:
                        Console.WriteLine("Введите значение в фаренгейтах: ");

                        int farengeit = Convert.ToInt32(Console.ReadLine());

                        int toCels = (farengeit - 32) * 5 / 9;
                        Console.WriteLine($"{farengeit} градусов по Фаренгейту равен {toCels} градусам по Цельсию.");
                        Console.ReadKey();
                        Console.Clear();
                        break;
                }
            }
        }
    }
}
