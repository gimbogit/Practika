namespace _2._1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Person person = new Person();

            person.name = "Балабанов";
            person.age = 54;
            person.adres = "Екатеринбург. СССР";

            person.PrintInfo(person.name,person.age,person.adres);
        }
        public class Person
        {
            public string name;
            public int age;
            public string adres;
            public void PrintInfo(string name, int age, string adres)
            {
                Console.WriteLine($"Имя:{name}; Возраст:{age}; Адрес:{adres} ");
            }
        }
    }
}
