namespace _3._4
{
    public delegate bool FilterDelegate(Product item);

    public class Product
    {
        public string Name { get; set; }
        public string Category { get; set; }
        public double Price { get; set; }
        public DateTime Date { get; set; }

        public Product(string name, string category, double price, DateTime date)
        {
            Name = name;
            Category = category;
            Price = price;
            Date = date;
        }

        public override string ToString()
        {
            return $"{Name} | {Category} | ${Price} | {Date:dd.MM.yyyy}";
        }
    }

    class Program
    {
        static List<Product> data = new List<Product>();

        static void Main(string[] args)
        {
            Console.WriteLine("=== СИСТЕМА УПРАВЛЕНИЯ ТОВАРАМИ ===");

            AddSampleData();

            while (true)
            {
                ShowMenu();
                string choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        ShowAllProducts();
                        break;
                    case "2":
                        AddNewProduct();
                        break;
                    case "3":
                        MultiFilter();
                        break;
                    case "4":
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

        static void AddSampleData()
        {
            data.Add(new Product("Ноутбук игровой мощный", "Электроника", 1500, new DateTime(2024, 1, 15)));
            data.Add(new Product("Смартфон", "Электроника", 800, new DateTime(2024, 2, 20)));
            data.Add(new Product("Книга по программированию на C#", "Образование", 25, new DateTime(2023, 12, 10)));
            data.Add(new Product("Кофе в зернах высший сорт", "Продукты", 15, new DateTime(2024, 3, 5)));
            data.Add(new Product("Стул офисный эргономичный", "Мебель", 120, new DateTime(2024, 1, 30)));
            data.Add(new Product("Футболка хлопковая", "Одежда", 30, new DateTime(2024, 2, 15)));
            data.Add(new Product("Наушники беспроводные", "Электроника", 200, new DateTime(2024, 3, 1)));
            data.Add(new Product("Ручка гелевая черная", "Канцелярия", 5, new DateTime(2023, 11, 20)));
        }

        static void ShowMenu()
        {
            Console.WriteLine("\n=== ГЛАВНОЕ МЕНЮ ===");
            Console.WriteLine("1. Показать все товары");
            Console.WriteLine("2. Добавить новый товар");
            Console.WriteLine("3. Многофункциональный фильтр");
            Console.WriteLine("4. Выйти");
            Console.Write("Выберите действие: ");
        }

        static void ShowAllProducts()
        {
            ShowData(data, "Все товары");
        }

        static void ShowData(List<Product> data, string filterName = "Результаты фильтрации")
        {
            Console.WriteLine($"\n=== {filterName.ToUpper()} ===");
            Console.WriteLine($"Найдено товаров: {data.Count}");

            if (data.Count == 0)
            {
                Console.WriteLine("Товары не найдены.");
                return;
            }

            Console.WriteLine(new string('-', 80));
            Console.WriteLine("| №  | Название                 | Категория    | Цена   | Дата       |");
            Console.WriteLine(new string('-', 80));

            for (int i = 0; i < data.Count; i++)
            {
                PrintProductRow(i + 1, data[i]);

                if (i < data.Count - 1)
                    Console.WriteLine("|----|--------------------------|--------------|--------|------------|");
            }

            Console.WriteLine(new string('-', 80));
        }

        static void PrintProductRow(int number, Product product)
        {
            int maxNameLength = 24;
            string name = product.Name;
            string category = product.Category.Length > 12 ? product.Category.Substring(0, 12) : product.Category.PadRight(12);
            string price = $"${product.Price}";
            string date = product.Date.ToString("dd.MM.yyyy");

            if (name.Length <= maxNameLength)
            {
                Console.WriteLine($"| {number,-2} | {name.PadRight(maxNameLength)} | {category,-12} | {price,-6} | {date,-10} |");
            }
            else
            {
                List<string> nameLines = SplitLongName(name, maxNameLength);

                Console.WriteLine($"| {number,-2} | {nameLines[0].PadRight(maxNameLength)} | {category,-12} | {price,-6} | {date,-10} |");

                for (int i = 1; i < nameLines.Count; i++)
                {
                    Console.WriteLine($"|    | {nameLines[i].PadRight(maxNameLength)} |              |        |            |");
                }
            }
        }

        static List<string> SplitLongName(string name, int maxLength)
        {
            List<string> result = new List<string>();

            if (name.Length <= maxLength)
            {
                result.Add(name);
                return result;
            }

            string[] words = name.Split(' ');
            string currentLine = "";

            foreach (string word in words)
            {
                if ((currentLine + " " + word).Length <= maxLength)
                {
                    if (string.IsNullOrEmpty(currentLine))
                        currentLine = word;
                    else
                        currentLine += " " + word;
                }
                else
                {
                    if (!string.IsNullOrEmpty(currentLine))
                    {
                        result.Add(currentLine);
                        currentLine = word;
                    }
                    else if (word.Length > maxLength)
                    {
                        for (int i = 0; i < word.Length; i += maxLength)
                        {
                            int length = Math.Min(maxLength, word.Length - i);
                            result.Add(word.Substring(i, length));
                        }
                        currentLine = "";
                    }
                }
            }

            if (!string.IsNullOrEmpty(currentLine))
            {
                result.Add(currentLine);
            }

            return result;
        }

        static void AddNewProduct()
        {
            Console.WriteLine("\n=== ДОБАВЛЕНИЕ НОВОГО ТОВАРА ===");

            Console.Write("Введите название товара: ");
            string name = Console.ReadLine();

            Console.Write("Введите категорию товара: ");
            string category = Console.ReadLine();

            double price = 0;
            while (true)
            {
                Console.Write("Введите цену товара: ");
                if (double.TryParse(Console.ReadLine(), out price) && price >= 0)
                    break;
                Console.WriteLine("Неверный формат цены! Введите число.");
            }

            DateTime date;
            while (true)
            {
                Console.Write("Введите дату добавления (дд.мм.гггг): ");
                if (DateTime.TryParse(Console.ReadLine(), out date))
                    break;
                Console.WriteLine("Неверный формат даты!");
            }

            Product newProduct = new Product(name, category, price, date);
            data.Add(newProduct);

            Console.WriteLine($"\n Товар успешно добавлен!");
            Console.WriteLine(newProduct);
        }

        static void MultiFilter()
        {
            Console.WriteLine("\n=== МНОГОФУНКЦИОНАЛЬНЫЙ ФИЛЬТР ===");

            List<FilterDelegate> filters = new List<FilterDelegate>();

            Console.Write("Фильтровать по ключевому слову? (y/n): ");
            if (Console.ReadLine().ToLower() == "y")
            {
                Console.Write("Введите ключевое слово: ");
                string keyword = Console.ReadLine();
                filters.Add(p =>
                    p.Name.ToLower().Contains(keyword.ToLower()) ||
                    p.Category.ToLower().Contains(keyword.ToLower()));
            }

            Console.Write("Фильтровать по цене? (y/n): ");
            if (Console.ReadLine().ToLower() == "y")
            {
                Console.Write("Введите минимальную цену: ");
                if (double.TryParse(Console.ReadLine(), out double minPrice))
                {
                    Console.Write("Введите максимальную цену: ");
                    if (double.TryParse(Console.ReadLine(), out double maxPrice))
                    {
                        filters.Add(p => p.Price >= minPrice && p.Price <= maxPrice);
                    }
                }
            }

            Console.Write("Фильтровать по категории? (y/n): ");
            if (Console.ReadLine().ToLower() == "y")
            {
                Console.Write("Введите категорию: ");
                string category = Console.ReadLine();
                filters.Add(p => p.Category.ToLower().Contains(category.ToLower()));
            }

            Console.Write("Фильтровать по дате? (y/n): ");
            if (Console.ReadLine().ToLower() == "y")
            {
                Console.Write("Введите начальную дату (дд.мм.гггг): ");
                if (DateTime.TryParse(Console.ReadLine(), out DateTime startDate))
                {
                    Console.Write("Введите конечную дату (дд.мм.гггг): ");
                    if (DateTime.TryParse(Console.ReadLine(), out DateTime endDate))
                    {
                        filters.Add(p => p.Date >= startDate && p.Date <= endDate);
                    }
                }
            }

            if (filters.Count > 0)
            {
                FilterDelegate combinedFilter = p =>
                {
                    foreach (FilterDelegate filter in filters)
                    {
                        if (!filter(p))
                            return false;
                    }
                    return true;
                };

                List<Product> filteredData = ApplyFilter(data, combinedFilter);
                ShowData(filteredData, "Результаты многофункционального фильтра");
            }
            else
            {
                Console.WriteLine("Фильтры не выбраны!");
            }
        }

        static List<Product> ApplyFilter(List<Product> data, FilterDelegate filter)
        {
            List<Product> result = new List<Product>();

            foreach (Product item in data)
            {
                if (filter(item))
                {
                    result.Add(item);
                }
            }

            return result;
        }
    }
}
