using Library.Entities;
using Library.Services;
using System;
using System.Globalization;

namespace Library.UserInterface
{
    public class BookUserInterface
    {
        public static void CreateBook()
        {
            Console.WriteLine("");
            Console.Write("Para iniciar o cadastro, digite o ISBN do livro: ");
            var isbn = Console.ReadLine();

            var bookService = new BookService();
            if (bookService.Exists(isbn))
            {
                BookAlreadyExists();
                return;
            }

            var book = new Book();
            book.Isbn = isbn;

            Console.WriteLine("");
            Console.Write("Título: ");
            book.Title = Console.ReadLine();

            Console.Write("Data publicação (dd/mm/aaaa): ");
            var culture = CultureInfo.GetCultureInfo("pt-BR");
            book.PublishDate = DateTime.Parse(Console.ReadLine(), culture);

            Console.Write("Autor: ");
            book.Author = Console.ReadLine();

            Console.Write("Gênero: ");
            book.Genre = Console.ReadLine();

            var pulledDownNumber = bookService.Create(book);

            if (pulledDownNumber != 0)
            {
                Console.WriteLine("");
                Console.WriteLine("Livro cadastrado com sucesso, nro do tombo: " + pulledDownNumber);
                Console.ReadLine();
                return;
            }

            Console.WriteLine("Os dados do livro não são válidos. Confira os dados e tente novamente.");
            Console.ReadLine();
        }

        public static void BookAlreadyExists()
        {
            Console.WriteLine("");
            Console.WriteLine("Esse livro já existe em nossa base de dados.");
            Console.ReadLine();
        }
    }
}
