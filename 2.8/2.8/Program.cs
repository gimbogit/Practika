    namespace _2._8
    {
        internal class Program
        {
            static void Main(string[] args)
            {
                Library library = new Library();
                var books = library.GetAllBooks();

                while (true)
                {
                    Console.WriteLine("Выберите операцию:");
                    Console.WriteLine("1) Добавление книги");
                    Console.WriteLine("2) Удаление книги");
                    Console.WriteLine("3) Поиск по автору");
                    Console.WriteLine("4) Поиск по году издательства");
                    Console.WriteLine("5) Вывод всех книг");

                    byte numOfOperation = Convert.ToByte(Console.ReadLine());

                    switch (numOfOperation)
                    {
                        case 1:
                            Console.WriteLine("Имя автора:");
                            string nameToAuthor = Console.ReadLine();
                            Console.WriteLine("Фамилия автора:");
                            string lastNameToAuthor = Console.ReadLine();
                            Console.WriteLine("Год рождения автора:");
                            int ageToAuthor = Convert.ToInt32(Console.ReadLine());
                            Console.WriteLine("Название книги:");
                            string nameToBook = Console.ReadLine();
                            Console.WriteLine("Год выхода книги:");
                            int ageToBook = Convert.ToInt32(Console.ReadLine());

                            Author author = new Author();
                            author.NewAuthor(nameToAuthor, lastNameToAuthor, ageToAuthor);
                            Book book = new Book();
                            book.NewBook(nameToBook, author, ageToBook);
                            library.AddBook(book); 
                            Console.WriteLine("Книга успешно добавлена");
                            Console.ReadKey();
                            Console.Clear();
                            break;

                        case 2:
                        
                            if (books.Count == 0)
                            {
                                Console.WriteLine("Список книг пуст");
                            }
                            else
                            {
                                Console.WriteLine("Какую книгу вы желаете удалить?");
                                for (int i = 0; i < books.Count; i++) 
                                {
                                    Console.WriteLine($"{i + 1}: {books[i]}");
                                }
                                int numOfDeletedBook = Convert.ToInt32(Console.ReadLine());
                                if (numOfDeletedBook > 0 && numOfDeletedBook <= books.Count)
                                {
                                    library.DeleteBook(books[numOfDeletedBook - 1]); 
                                    Console.WriteLine("Книга успешно удалена");
                                }
                                else
                                {
                                    Console.WriteLine("Неверный номер книги");
                                }
                            }
                            Console.ReadKey();
                            Console.Clear();
                            break;
                        case 3:
                            Console.WriteLine("Напишите фамилию автора:");
                            string searchLastName = Console.ReadLine();

                            List<Book> foundBooks = new List<Book>();
                            for (int i = 0; i < books.Count; i++)
                            {
                           
                                if (searchLastName.Equals(books[i].Author.LastName, StringComparison.OrdinalIgnoreCase))
                                {
                                    foundBooks.Add(books[i]);
                                }
                            }

                            if (foundBooks.Count == 0)
                            {
                                Console.WriteLine("Книги данного автора не найдены.");
                            }
                            else
                            {
                                Console.WriteLine("Найденные книги:");
                                for (int i = 0; i < foundBooks.Count; i++)
                                {
                                    Console.WriteLine($"{i + 1}: {foundBooks[i]}");
                                }
                            }

                            Console.ReadKey();
                            Console.Clear();
                            break;

                            case 4:
                            Console.WriteLine("Напишите год выпуска книги");
                            int searchAgeMake = Convert.ToInt32(Console.ReadLine());

                            List<Book> foundBooksToAge = new List<Book>();
                            for (int i = 0; i < books.Count; i++)
                            {

                                if (searchAgeMake.Equals(books[i].YearMake))
                                {
                                    foundBooksToAge.Add(books[i]);
                                }
                            }
                            if (foundBooksToAge.Count == 0)
                            {
                                Console.WriteLine("Книги данного года не найдены.");
                            }
                            else
                            {
                                Console.WriteLine("Найденные книги:");
                                for (int i = 0; i < foundBooksToAge.Count; i++)
                                {
                                    Console.WriteLine($"{i + 1}: {foundBooksToAge[i]}");
                                }
                            }
                            Console.ReadKey();
                            Console.Clear();
                            break;
                            case 5:
                            Console.WriteLine("Вот все имеющиеся книги:");
                            for (int i = 0; i < books.Count; i++)
                            {
                                Console.WriteLine($"{i + 1}: {books[i]}");
                            }
                            Console.WriteLine("Нажмите Enter...");
                            Console.ReadKey();
                            Console.Clear();
                            break;
                    }
                }
            }

            class Book
            {
                private string _name;
                private Author _author;
                private int _yearMake;

                public string Name => _name;
                public Author Author => _author;
                public int YearMake => _yearMake;

                public void NewBook(string name, Author author, int yearMake)
                {
                    _name = name;
                    _author = author;
                    _yearMake = yearMake;
                }

            
                public override string ToString()
                {
                    return $"\"{_name}\"  {_author} ({_yearMake})";
                }
            }

            class Author
            {
                private string _authorName;
                private string _authorLastName;
                private int _ageToBorn;

                public string FirstName => _authorName;
                public string LastName => _authorLastName;
                public int BirthYear => _ageToBorn;

                public void NewAuthor(string authorName, string authorLastName, int ageToBorn)
                {
                    _authorName = authorName;
                    _authorLastName = authorLastName;
                    _ageToBorn = ageToBorn;
                }

            
                public override string ToString()
                {
                    return $"{_authorName} {_authorLastName}";
                }
            }

            class Library
            {
                private List<Book> _books = new List<Book>(); 

                public void AddBook(Book newBook)
                {
                    _books.Add(newBook);
                }

                public void DeleteBook(Book deletedBook)
                {
                    _books.Remove(deletedBook);
                }

                public List<Book> GetAllBooks()
                {
                    return _books;
                }
            }
        }
    }