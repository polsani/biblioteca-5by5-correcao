using CsvHelper;
using CsvHelper.Configuration;
using Library.Entities;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;

namespace Library.Repositories
{
    public class BookRepository
    {
        private const string filePath = "DataSource/LIVRO.csv";
        private CultureInfo _culture = new CultureInfo("pt-BR");

        public void Create(Book book)
        {
            var config = new CsvConfiguration(_culture)
            {
                HasHeaderRecord = true
            };

            using (var stream = File.Open(filePath, FileMode.Append))
            using (var sw = new StreamWriter(stream))
            using (var csvHelper = new CsvWriter(sw, config))
            {
                csvHelper.WriteRecord(book);
            };
        }

        public Book Read(string isbn)
        {
            using (var sr = new StreamReader(filePath))
            using (var csvHelper = new CsvReader(sr, _culture))
            {
                var books = csvHelper.GetRecords<Book>();

                return books.SingleOrDefault(x => x.Isbn == isbn);
            }
        }

        public Book Read(long pulledDownNumber)
        {
            using (var sr = new StreamReader(filePath))
            using (var csvHelper = new CsvReader(sr, _culture))
            {
                var books = csvHelper.GetRecords<Book>();

                return books.SingleOrDefault(x => x.PulledDownNumber == pulledDownNumber);
            }
        }

        public IEnumerable<Book> ReadAll()
        {
            using (var sr = new StreamReader(filePath))
            using (var csvHelper = new CsvReader(sr, _culture))
            {
                return csvHelper.GetRecords<Book>().ToList();
            }
        }
    }
}
