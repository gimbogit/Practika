namespace _1._1._3
{
    internal class Program
    {
        static void Main(string[] args)
        {
            while (true) 
            {
                Console.WriteLine("Введит слово для проверки его на палиндром");
                string originalString = Console.ReadLine();
                string reversedString = new string(originalString.ToCharArray().Reverse().ToArray());

                if (originalString == reversedString)
                {
                    Console.WriteLine("Введенное слово является палиндромом");
                }
                else 
                {
                    Console.WriteLine($"Введнное слово не является палиндромом ибо получается {reversedString}");
                }
                Console.ReadKey();
                Console.Clear();
            }

        }
    }
}
