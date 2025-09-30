namespace _1._3._1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            while (true)
            {
                Console.WriteLine("Введите значение числителя: ");
                int chisl = Convert.ToInt32(Console.ReadLine());

                Console.WriteLine("Введите значение знаменателя: ");
                int znam = Convert.ToInt32(Console.ReadLine());

                int nod = SearchNOD(chisl, znam);
                chisl = chisl / nod;
                znam = znam / nod;
                Console.WriteLine($"Полученная сокращенная дробь: {chisl}/{znam}");
                Console.ReadKey();
                Console.Clear();
            }
        }
        public static int SearchNOD(int a, int b)
        {
            while(b != 0)
            {
                int temp = b;
                b = a % b;
                a = temp;
            }
            return a;
        }
            
    }
}
