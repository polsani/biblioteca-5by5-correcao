using CsvHelper.Configuration.Attributes;
using System;

namespace Library.Entities
{
    public class Customer
    {
        [Name("IdCliente")]
        public long Id { get; set; }
        
        [Name("CPF")]
        public string Document { get; set; }

        [Name("Nome")]
        public string Name { get; set; }

        [Name("DataNascimento")]
        public DateTime BirthDate { get; set; }

        [Name("Telefone")]
        public string Phone { get; set; }

        [Name("Logradouro")]
        public string Street { get; set; }

        [Name("Bairro")]
        public string Neighborhood { get; set; }

        [Name("Cidade")]
        public string City { get; set; }

        [Name("Estado")]
        public string State { get; set; }

        [Name("CEP")]
        public string ZipCode { get; set; }
    }
}
