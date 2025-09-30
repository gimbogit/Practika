namespace _1._1._5
{
    internal class Program
    {
        static void Main(string[] args)
        {
            while (true)
            {
                Random random = new Random();

            
                int randomNum = random.Next(10);

                Console.WriteLine("Попробуйте угадать число загаданное программой: ");
                int peopleNum = Convert.ToInt32(Console.ReadLine());

                if (peopleNum == randomNum)
                {
                    Console.WriteLine("ПОЗДРАВЛЯЮ!!!! ВЫ УГАДАЛИ !!!!");
                }
                else 
                {
                    Console.WriteLine("Вы не угадали((((");
                }
                
            }
        }
    }
}
