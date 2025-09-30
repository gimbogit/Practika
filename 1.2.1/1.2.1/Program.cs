namespace _1._2._1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            while (true)
            {
                Console.WriteLine("Введите размер массива");
                int arraySize = Convert.ToInt32(Console.ReadLine());

                int[] nums = new int[arraySize];
                for (int i = 0; i < nums.Length; i++)
                {
                    Console.WriteLine($"Введите значение элемента #{i+1}:");
                    nums[i] = Convert.ToInt32(Console.ReadLine());
                }
                Console.WriteLine("Введенный массив:");
                for (int i = 0; i < nums.Length; i++)
                {
                    Console.WriteLine(nums[i]);
                }
                Array.Sort(nums);
                Console.WriteLine("Нормирированный массив:");
                for (int i = 0; i < nums.Length; i++)
                {
                    Console.WriteLine(nums[i]);
                }
                Console.ReadKey(); 
                Console.Clear();
            }
        }
    }
}
