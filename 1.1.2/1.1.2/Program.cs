namespace _1._1._2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            while (true)
            {
                Console.WriteLine("Введите число для определения его четности/нечетности ");
                int num = Convert.ToInt32(Console.ReadLine());

                if (num % 2 > 0)
                {
                    Console.WriteLine("Число нечетное ");
                    Console.ReadKey();
                    Console.Clear();    
                }
                else {
                    Console.WriteLine("Число четное ");
                    Console.ReadKey();
                    Console.Clear();
                }
            }
        }
    }
}
