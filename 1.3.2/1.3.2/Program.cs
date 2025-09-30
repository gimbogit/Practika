namespace _1._3._2
{
    internal class Program
    {
        static Random random = new Random();

        
        public static int[] MadeToArray(int maxSum)
        {
            int sum = 0;
            int count = 0;
            int[] tempArray = new int[100]; 
            while (sum <= maxSum)
            {
                int value = random.Next(1, 10); 
                sum += value;
                if (sum > maxSum) break;
                tempArray[count++] = value;
            }
            int[] resultArray = new int[count];
            Array.Copy(tempArray, resultArray, count);
            return resultArray;
        }

        static void Main()
        {
            while (true)
            {
                Console.Write("Введите максимальную сумму: ");
                int maxSum = int.Parse(Console.ReadLine());

                int[] array = MadeToArray(maxSum);
                Console.WriteLine("Сгенерированный массив:");
                foreach (int element in array)
                {
                    Console.Write(element + " ");
                }
                Console.ReadKey();
                Console.Clear();
            }
        }

    }
}
