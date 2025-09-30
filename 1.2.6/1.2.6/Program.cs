namespace _1._2._6
{
    internal class Program
    {
        static void Main(string[] args)
        {
            while (true)
            {
                double[] array = new double[10];
                Random rnd = new Random();

                for (int i = 0; i < array.Length; i++)
                {
                    array[i] = rnd.NextDouble() * 20 - 10;
                    Console.WriteLine($"{i}: {array[i]:F2}");
                }

                var indices = array
        .Select((value, index) => new { value, index })
        .OrderBy(x => x.value)
        .Select(x => x.index)
        .ToArray();
                Console.WriteLine("Массив индексов в порядке возрастания значений:");
                foreach (var index in indices)
                {
                    Console.Write(index + " ");
                }
                Console.ReadKey();
                Console.Clear();    
            }
        }

    }
}
