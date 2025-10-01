using System.Xml.Linq;
using static _2._3.Program;

namespace _2._3
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Book book1 = new Book("Валентин Катаев", 56, "Сын полка", 1897);
            book1.BookInfo();
            Book book2 = new Book("Лев Толстой", 41, "Война и мир", 1869);
            book2.BookInfo();
            Book book3 = new Book("Чак Паланик", 34, "Бойцовский клуб", 1962);
            book3.BookInfo();
        }
        public class Author
        {
            private string AuthorName;
            private int AuthorAge;

            public Author(string name, int age)
            {
                AuthorName = name;
                AuthorAge = age;
            }
            public string GetName() => AuthorName;
            public int GetAge() => AuthorAge;

        }
        public class Book
        {
            private string _nameBook;
            private int _ageBook;
            private Author _author;

            public Book(string AuthorName, int AuthorAge, string nameBook, int ageBook)
            {
                _author = new Author(AuthorName,AuthorAge);
                _nameBook = nameBook;
                _ageBook = ageBook;
            }
            public void BookInfo()
            {
                Console.WriteLine($"Книга: {_nameBook}, Год издания: {_ageBook}");
                Console.WriteLine($"Автор: {_author.GetName()}, Возраст автора: {_author.GetAge()}");
                Console.WriteLine("-----------------------------------------------");
            }

        }
        
    }
}
