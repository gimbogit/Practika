namespace _1._2._3
{
    internal class Program
    {
        static void Main(string[] args)
        {
            while (true) 
            {
                Random random = new Random();

                int[] arrayOfInt = new int[0];

                Console.WriteLine("Введите количество элементов ");
                int numOfint = Convert.ToInt32(Console.ReadLine());
                arrayOfInt = new int[numOfint];

                for (int i = 0; i < numOfint; i++)
                {
                    arrayOfInt[i] = random.Next(0, 100);
                    Console.Write($"{arrayOfInt[i]}, ");
                    if ((i % 10 == 0)&& (i!=0))
                    {
                        Console.Write("\n");
                    }
                }
                Console.ReadKey();
                Console.Clear();
            }

        }
    }
}
