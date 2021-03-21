using Library.Entities;
using ProductCodeValidator;

namespace Library.Validations
{
    public class BookValidator
    {
        private Book _book;

        public BookValidator(Book book)
        {
            _book = book;
        }

        public bool IsValid()
        {
            if (//IsbnValidator.IsValidIsbn(_book.Isbn) &&
                _book.Title != string.Empty &&
                _book.Author != string.Empty)
                return true;

            return false;
        }
    }
}
