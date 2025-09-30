namespace _1._1._4
{
    internal class Program
    {
        static void Main(string[] args)
        {
           List<string> city = new List<string>() {"Москва","Пекин","Владивосток","Батуми","Варшава"};
            while (true)
            {
                Console.WriteLine("Введите название города:");
                string cityName = Console.ReadLine();
                string newNameCity = null;
                int cityCode = 0;

                for (int i = 0; i < city.Count; i++)
                {
                    if (city[i] == cityName)
                    {
                        newNameCity = city[i];
                        cityCode = i;
                    }
                }
                if (newNameCity != null)
                {
                    Console.WriteLine($"Да, введенный город есть в списке. \n Индекс города {cityName}:{cityCode}");
                    Console.ReadKey();
                    Console.Clear();
                }
                else 
                {
                    Console.WriteLine("Введенного города нет в списке");
                    Console.ReadKey();
                    Console.Clear();
                }
            }


        }
    }
}
