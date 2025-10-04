namespace _4._2
{

    public interface IProduct
    {
        decimal GetPrice();          
        int GetStockBalance();       
    }

    
    public class Milk : IProduct
    {
        private decimal price;
        private int stockBalance;

        public Milk(decimal price, int stockBalance)
        {
            this.price = price;
            this.stockBalance = stockBalance;
        }

        public decimal GetPrice()
        {
            return price;
        }

        public int GetStockBalance()
        {
            return stockBalance;
        }
    }

    
    public class Bread : IProduct
    {
        private decimal price;
        private int stockBalance;

        public Bread(decimal price, int stockBalance)
        {
            this.price = price;
            this.stockBalance = stockBalance;
        }

        public decimal GetPrice()
        {
            return price;
        }

        public int GetStockBalance()
        {
            return stockBalance;
        }
    }

    
    public class Apples : IProduct
    {
        private decimal price;
        private int stockBalance;

        public Apples(decimal price, int stockBalance)
        {
            this.price = price;
            this.stockBalance = stockBalance;
        }

        public decimal GetPrice()
        {
            return price;
        }

        public int GetStockBalance()
        {
            return stockBalance;
        }
    }

  
    class Program
    {
        static void Main()
        {
            
            List<IProduct> products = new List<IProduct>
        {
            new Milk(85.50m, 25),
            new Bread(45.00m, 10),
            new Apples(120.00m, 8)
        };

            
            Console.WriteLine("Учет товаров в магазине:");
            Console.WriteLine("=========================");

            foreach (IProduct product in products)
            {
                string productType = product.GetType().Name;
                decimal price = product.GetPrice();
                int balance = product.GetStockBalance();

                Console.WriteLine($"{productType}: Цена - {price} руб., Остаток - {balance} шт.");
            }

          
            Console.WriteLine("\nОбщая стоимость товаров на складе:");
            decimal totalValue = 0;
            foreach (IProduct product in products)
            {
                totalValue += product.GetPrice() * product.GetStockBalance();
            }
            Console.WriteLine($"{totalValue} руб.");
        }
    }
}