namespace _2._7
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Guitar guitar1 = new Guitar("Gibson","2540");
            guitar1.Dispose();
            Guitar guitar2 = new Guitar("Jet", "560");
            guitar2.Dispose();
        }

         public class Guitar: IDisposable {
        
            private string _model;
            private string _price;

            public Guitar(string model, string price)
            {
                _model = model;
                _price = price;
                Console.WriteLine($"Добавлена гитара {model} по доступной цене в {price} рублей");
            }
            //~Guitar() 
            //{
            //    Console.WriteLine($"Гитара {_model} удалена ");
            //}
            public void Dispose()
            {
                Console.WriteLine($"Гитара {_model} удалена ");
            }
            }
    }
}
