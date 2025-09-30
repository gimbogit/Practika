namespace _1._2._2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Random random = new Random();

            int[] arrayItn = new int[10];
            Console.WriteLine("Массив до изменения ");
            for (int i = 0; i < arrayItn.Length; i++)
            {
                arrayItn[i] = random.Next();
                Console.WriteLine(arrayItn[i]);
            }
            Console.WriteLine("Введите число которое будет заменять максимальный элемент в массиве");
            int newInt = Convert.ToInt32(Console.ReadLine());

            int maxEl = 0;
            int maxInd = 0;

            for (int i = 0;i < arrayItn.Length;i++)
            {
                if (arrayItn[i] > maxEl)
                {
                    maxEl = arrayItn[i];
                    maxInd = i;
                }
            }
            arrayItn[maxInd] = newInt;
            Console.WriteLine("Массив после изменений");
            for (int i = 0; i < arrayItn.Length; i++)
            {
                Console.WriteLine(arrayItn[i]);
            }
            Console.ReadKey();
            Console.Clear();
        }
    }
}
