using CsvHelper;
using CsvHelper.Configuration;
using Library.Entities;
using System.Globalization;
using System.IO;
using System.Linq;

namespace Library.Repositories
{
    public class CustomerRepository
    {
        private const string filePath = "DataSource/CLIENTE.csv";

        public void Create(Customer customer)
        {
            var config = new CsvConfiguration(CultureInfo.InvariantCulture)
            {
                HasHeaderRecord = true
            };

            using (var stream = File.Open(filePath, FileMode.Append))
            using (var sw = new StreamWriter(stream))
            using (var csvHelper = new CsvWriter(sw, config))
            {
                csvHelper.WriteRecord(customer);
            };
        }

        public Customer Read(string document)
        {
            using (var sr = new StreamReader(filePath))
            using (var csvHelper = new CsvReader(sr, CultureInfo.InvariantCulture))
            {
                var customers = csvHelper.GetRecords<Customer>();

                return customers.SingleOrDefault(x => x.Document == document);
            }
        }

        public Customer Read(long id)
        {
            using (var sr = new StreamReader(filePath))
            using (var csvHelper = new CsvReader(sr, CultureInfo.InvariantCulture))
            {
                var customers = csvHelper.GetRecords<Customer>();

                return customers.SingleOrDefault(x => x.Id == id);
            }
        }
    }
}
