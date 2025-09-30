namespace _1._2._5
{
    internal class Program
    {
        static void Main(string[] args)
        {
            while (true)
            {
                Console.WriteLine("Введите количество элементов массива:");
                int razmer = Convert.ToInt32(Console.ReadLine());

                Random random = new Random();
                List<char> liter = new List<char>(razmer);

                for (int i = 0; i < razmer; i++) 
                {
                    liter.Add((char)random.Next('а', 'я' + 1));
                    //liter[i] = (char)random.Next('а', 'я' + 1);
                }
                char[] glas = {'у','е','ы','а','о','э','я','и','ю' };

                List <char> glasLiter = new List<char> { };

                for (int i = liter.Count - 1; i >= 0; i--)
                {
                    if (glas.Contains(liter[i]))
                    {
                        glasLiter.Add(liter[i]);
                        liter.RemoveAt(i);
                    }
                }

                Console.WriteLine($"Оставшиеся согласные буквы:");
                for (int i = 0; i < liter.Count; i++)
                {
                    Console.WriteLine(liter[i]);
                }
                Console.WriteLine("---------------------");
                
                    Console.WriteLine($"Полученные гласные буквы:");
                for (int i = 0; i < glasLiter.Count; i++)
                {
                    Console.WriteLine(glasLiter[i]);
                }

                    Console.ReadKey();
                Console.Clear();
            }
        }
    }
}
