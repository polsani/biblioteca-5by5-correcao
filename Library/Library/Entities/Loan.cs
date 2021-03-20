using CsvHelper.Configuration.Attributes;
using System;

namespace Library.Entities
{
    public class Loan
    {
        [Name("IdCliente")]
        public long CustomerId { get; set; }

        [Name("NumeroTombo")]
        public long BookPulledDownNumber { get; set; }

        [Name("DataEmprestimo")]
        public DateTime LoanDate { get; set; }

        [Name("DataDevolucao")]
        public DateTime ReturnDate { get; set; }
        
        /// <summary>
        /// 1 - Emprestado
        /// 2 - Devolvido
        /// </summary>
        [Name("StatusEmprestimo")]
        public int Status { get; set; }

        [Ignore]
        public Customer Customer { get; set; }

        [Ignore]
        public Book Book { get; set; }
    }
}
