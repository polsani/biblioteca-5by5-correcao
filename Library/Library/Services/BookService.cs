using Library.Repositories;
using System.Linq;

namespace Library.Services
{
    public class BookService
    {
        private BookRepository _bookRepository;

        public void Create()
        {
            _bookRepository = new BookRepository();
        }

        private long GenerateNextId()
        {
            var books = _bookRepository.ReadAll();

            if (books == null || !books.Any())
                return 1;

            return books.Max(x => x.PulledDownNumber) + 1;
        }
    }
}
