namespace _1._2._4
{
    internal class Program
    {
        static void Main(string[] args)
        {
            while (true)
            {
                Random random = new Random();
                Console.WriteLine("Введите количество элементов массива: ");
                int numOfEl = Convert.ToInt32(Console.ReadLine());

                int[] arrayEl = new int[numOfEl];

                Console.WriteLine("Введите диапазон минимума для рандомизации: ");
                int min = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine("Введите диапазон максимума для рандомизации: ");
                int max = Convert.ToInt32(Console.ReadLine());

                Console.WriteLine("Полученный массив: ");
                for (int i = 0; i < numOfEl; i++)
                {
                    arrayEl[i] = random.Next(min, max + 1); // +1 чтобы включить верхнюю границу
                    Console.WriteLine($"{i + 1}-й элемент: {arrayEl[i]}");
                }

                // Инициализация начальными значениями
                int maxEl = arrayEl[0];
                int maxCode = 0;

                int minEl = arrayEl[0];
                int minCode = 0;

                // Поиск минимума и максимума за один проход
                for (int i = 1; i < numOfEl; i++)
                {
                    if (arrayEl[i] > maxEl)
                    {
                        maxEl = arrayEl[i];
                        maxCode = i;
                    }

                    if (arrayEl[i] < minEl)
                    {
                        minEl = arrayEl[i];
                        minCode = i;
                    }
                }

                Console.WriteLine($"Максимальный элемент: {maxEl} (индекс: {maxCode})");
                Console.WriteLine($"Минимальный элемент: {minEl} (индекс: {minCode})");
                Console.WriteLine("Вывод значений между минимальным и максимальным: ");

                // Определяем начальный и конечный индексы
                int start = Math.Min(minCode, maxCode);
                int end = Math.Max(minCode, maxCode);

                for (int i = start + 1; i < end; i++)
                {
                    Console.WriteLine($"{arrayEl[i]} (индекс: {i})");
                }

                if (Math.Abs(maxCode - minCode) <= 1)
                {
                    Console.WriteLine("Между минимальным и максимальным элементами нет других элементов.");
                }

                Console.WriteLine("Нажмите любую клавишу для продолжения...");
                Console.ReadKey();
                Console.Clear();
            }
        }
    }
}