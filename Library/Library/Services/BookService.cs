using Library.Entities;
using Library.Repositories;
using Library.Validations;
using System.Linq;

namespace Library.Services
{
    public class BookService
    {
        private BookRepository _bookRepository;

        public BookService()
        {
            _bookRepository = new BookRepository();
        }

        public long Create(Book book)
        {
            long pulledDownNumber = 0;
            var bookValidator = new BookValidator(book);
            book.PulledDownNumber = GenerateNextPulledDownNumber();

            if (bookValidator.IsValid())
            {
                _bookRepository.Create(book);
                pulledDownNumber = book.PulledDownNumber;
            }

            return pulledDownNumber;
        }

        public bool Exists(string isbn)
        {
            var book = _bookRepository.Read(isbn);

            return book != null;
        }

        public bool Exists(long pulledDownNumber)
        {
            var book = _bookRepository.Read(pulledDownNumber);

            return book != null;
        }

        private long GenerateNextPulledDownNumber()
        {
            var books = _bookRepository.ReadAll();

            if (books == null || !books.Any())
                return 1;

            return books.Max(x => x.PulledDownNumber) + 1;
        }
    }
}
