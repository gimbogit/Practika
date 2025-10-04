namespace _4._4
{
    public interface IBook
    {
        bool IsAvailable();          
        void BorrowBook();           
    }

    
    public class FictionBook : IBook
    {
        private string title;
        private string author;
        private bool isAvailable;

        public FictionBook(string title, string author)
        {
            this.title = title;
            this.author = author;
            this.isAvailable = true; 
        }

        public bool IsAvailable()
        {
            return isAvailable;
        }

        public void BorrowBook()
        {
            if (isAvailable)
            {
                isAvailable = false;
                Console.WriteLine($"Книга \"{title}\" автора {author} выдана читателю");
            }
            else
            {
                Console.WriteLine($"Книга \"{title}\" уже выдана");
            }
        }
    }

    
    public class ScientificBook : IBook
    {
        private string title;
        private string field;
        private bool isAvailable;

        public ScientificBook(string title, string field)
        {
            this.title = title;
            this.field = field;
            this.isAvailable = true;
        }

        public bool IsAvailable()
        {
            return isAvailable;
        }

        public void BorrowBook()
        {
            if (isAvailable)
            {
                isAvailable = false;
                Console.WriteLine($"Научная книга \"{title}\" (область: {field}) выдана читателю");
            }
            else
            {
                Console.WriteLine($"Научная книга \"{title}\" уже выдана");
            }
        }
    }

    
    public class Textbook : IBook
    {
        private string title;
        private string subject;
        private bool isAvailable;

        public Textbook(string title, string subject)
        {
            this.title = title;
            this.subject = subject;
            this.isAvailable = true;
        }

        public bool IsAvailable()
        {
            return isAvailable;
        }

        public void BorrowBook()
        {
            if (isAvailable)
            {
                isAvailable = false;
                Console.WriteLine($"Учебник \"{title}\" (предмет: {subject}) выдан читателю");
            }
            else
            {
                Console.WriteLine($"Учебник \"{title}\" уже выдан");
            }
        }
    }

    
    class Program
    {
        static void Main()
        {
            
            List<IBook> books = new List<IBook>
        {
            new FictionBook("Преступление и наказание", "Ф.М. Достоевский"),
            new ScientificBook("Краткая история времени", "Физика"),
            new Textbook("Основы программирования", "Информатика"),
            new FictionBook("Мастер и Маргарита", "М.А. Булгаков")
        };

          
            Console.WriteLine("Библиотека книг:");
            Console.WriteLine("================");

            
            for (int i = 0; i < books.Count; i++)
            {
                string status = books[i].IsAvailable() ? "Доступна" : "Выдана";
                Console.WriteLine($"{i + 1}. {status}");
            }

            
            Console.WriteLine("\nПроцесс выдачи книг:");
            Console.WriteLine("====================");

            books[0].BorrowBook(); 
            books[2].BorrowBook(); 
            books[0].BorrowBook(); 

           
            Console.WriteLine("\nОбновленная информация о книгах:");
            Console.WriteLine("================================");

            for (int i = 0; i < books.Count; i++)
            {
                string status = books[i].IsAvailable() ? "Доступна" : "Выдана";
                Console.WriteLine($"{i + 1}. {status}");
            }

            
            Console.WriteLine("\nСтатистика библиотеки:");
            Console.WriteLine("======================");

            int availableCount = 0;
            foreach (IBook book in books)
            {
                if (book.IsAvailable())
                    availableCount++;
            }

            Console.WriteLine($"Доступно книг: {availableCount} из {books.Count}");
        }
    }
}
    