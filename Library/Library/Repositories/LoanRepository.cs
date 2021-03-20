using CsvHelper;
using CsvHelper.Configuration;
using Library.Entities;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;

namespace Library.Repositories
{
    public class LoanRepository
    {
        private const string filePath = "DataSource/EMPRESTIMO.csv";
        private CultureInfo _culture = new CultureInfo("pt-BR");

        private BookRepository _bookRepository;
        private CustomerRepository _customerRepository;

        public LoanRepository()
        {
            _bookRepository = new BookRepository();
            _customerRepository = new CustomerRepository();
        }

        public void Create(Loan loan)
        {
            var config = new CsvConfiguration(_culture)
            {
                HasHeaderRecord = true
            };

            using (var stream = File.Open(filePath, FileMode.Append))
            using (var sw = new StreamWriter(stream))
            using (var csvHelper = new CsvWriter(sw, config))
            {
                csvHelper.WriteRecord(loan);
            }
        }

        public Loan Read(long bookPulledDownNumber)
        {
            using (var sr = new StreamReader(filePath))
            using (var csvHelper = new CsvReader(sr, _culture))
            {
                var loans = csvHelper.GetRecords<Loan>();

                var loan = loans.SingleOrDefault(x => x.BookPulledDownNumber == bookPulledDownNumber && x.Status == 1);

                if (loan == null)
                    return null;

                loan.Book = _bookRepository.Read(loan.BookPulledDownNumber);
                loan.Customer = _customerRepository.Read(loan.CustomerId);

                return loan;
            }
        }

        public IEnumerable<Loan> ReadAll()
        {
            using (var sr = new StreamReader(filePath))
            using (var csvHelper = new CsvReader(sr, _culture))
            {
                var loans = csvHelper.GetRecords<Loan>();

                return loans.Select(x => new Loan
                {
                    CustomerId = x.CustomerId,
                    BookPulledDownNumber = x.BookPulledDownNumber,
                    Book = x.Book = _bookRepository.Read(x.BookPulledDownNumber),
                    Customer = x.Customer = _customerRepository.Read(x.CustomerId),
                    LoanDate = x.LoanDate,
                    ReturnDate = x.ReturnDate,
                    Status = x.Status
                });
            }
        }

        public void UpdateStatus(long bookPulledDownNumber, int newStatus)
        {
            IEnumerable<Loan> loans;

            using (var sr = new StreamReader(filePath))
            using (var csvHelper = new CsvReader(sr, _culture))
            {
                loans = csvHelper.GetRecords<Loan>();
            }

            var loan = loans.SingleOrDefault(x => x.BookPulledDownNumber == bookPulledDownNumber && x.Status == 1);

            loan.Status = newStatus;

            var config = new CsvConfiguration(_culture)
            {
                HasHeaderRecord = true
            };

            using (var stream = File.Open(filePath, FileMode.Truncate))
            using (var sw = new StreamWriter(stream))
            using (var csvHelper = new CsvWriter(sw, config))
            {
                csvHelper.WriteHeader<Loan>();
                csvHelper.WriteRecords(loans);
            }
        }
    }
}
