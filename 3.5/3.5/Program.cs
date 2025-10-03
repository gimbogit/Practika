namespace _3._5
{
    public delegate void SortDelegate(int[] array);

    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("=== ПРИЛОЖЕНИЕ ДЛЯ СОРТИРОВКИ ЧИСЕЛ ===");

            while (true)
            {
                ShowMenu();
                string choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        SortNumbers();
                        break;
                    case "2":
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

        static void ShowMenu()
        {
            Console.WriteLine("\n=== ГЛАВНОЕ МЕНЮ ===");
            Console.WriteLine("1. Сортировка чисел");
            Console.WriteLine("2. Выйти");
            Console.Write("Выберите действие: ");
        }

        static void SortNumbers()
        {
            int[] numbers = InputNumbers();

            if (numbers == null || numbers.Length == 0)
                return;

            Console.WriteLine("\n=== ВЫБОР МЕТОДА СОРТИРОВКИ ===");
            Console.WriteLine("1. Сортировка пузырьком");
            Console.WriteLine("2. Быстрая сортировка");
            Console.WriteLine("3. Сортировка выбором");
            Console.Write("Выберите метод сортировки: ");

            string sortChoice = Console.ReadLine();
            SortDelegate sortMethod = null;
            string methodName = "";

            switch (sortChoice)
            {
                case "1":
                    sortMethod = BubbleSort;
                    methodName = "Сортировка пузырьком";
                    break;
                case "2":
                    sortMethod = QuickSort;
                    methodName = "Быстрая сортировка";
                    break;
                case "3":
                    sortMethod = SelectionSort;
                    methodName = "Сортировка выбором";
                    break;
                default:
                    Console.WriteLine("Неверный выбор метода сортировки!");
                    return;
            }

            Console.WriteLine($"\nИсходный массив: {ArrayToString(numbers)}");

            int[] sortedArray = new int[numbers.Length];
            Array.Copy(numbers, sortedArray, numbers.Length);

            sortMethod(sortedArray);

            Console.WriteLine($"Отсортированный массив ({methodName}): {ArrayToString(sortedArray)}");
        }

        static int[] InputNumbers()
        {
            Console.WriteLine("\n=== ВВОД ЧИСЕЛ ===");
            Console.Write("Введите числа через пробел: ");
            string input = Console.ReadLine();

            if (string.IsNullOrWhiteSpace(input))
            {
                Console.WriteLine("Не введены числа!");
                return null;
            }

            string[] numberStrings = input.Split(' ');
            int[] numbers = new int[numberStrings.Length];

            for (int i = 0; i < numberStrings.Length; i++)
            {
                if (!int.TryParse(numberStrings[i], out numbers[i]))
                {
                    Console.WriteLine($"Ошибка: '{numberStrings[i]}' не является числом!");
                    return null;
                }
            }

            return numbers;
        }

        static string ArrayToString(int[] array)
        {
            return string.Join(" ", array);
        }

        static void BubbleSort(int[] array)
        {
            for (int i = 0; i < array.Length - 1; i++)
            {
                for (int j = 0; j < array.Length - i - 1; j++)
                {
                    if (array[j] > array[j + 1])
                    {
                        int temp = array[j];
                        array[j] = array[j + 1];
                        array[j + 1] = temp;
                    }
                }
            }
        }

        static void QuickSort(int[] array)
        {
            QuickSortRecursive(array, 0, array.Length - 1);
        }

        static void QuickSortRecursive(int[] array, int left, int right)
        {
            if (left < right)
            {
                int pivotIndex = Partition(array, left, right);
                QuickSortRecursive(array, left, pivotIndex - 1);
                QuickSortRecursive(array, pivotIndex + 1, right);
            }
        }

        static int Partition(int[] array, int left, int right)
        {
            int pivot = array[right];
            int i = left - 1;

            for (int j = left; j < right; j++)
            {
                if (array[j] <= pivot)
                {
                    i++;
                    Swap(array, i, j);
                }
            }

            Swap(array, i + 1, right);
            return i + 1;
        }

        static void SelectionSort(int[] array)
        {
            for (int i = 0; i < array.Length - 1; i++)
            {
                int minIndex = i;

                for (int j = i + 1; j < array.Length; j++)
                {
                    if (array[j] < array[minIndex])
                    {
                        minIndex = j;
                    }
                }

                if (minIndex != i)
                {
                    Swap(array, i, minIndex);
                }
            }
        }

        static void Swap(int[] array, int i, int j)
        {
            int temp = array[i];
            array[i] = array[j];
            array[j] = temp;
        }
    }
}
