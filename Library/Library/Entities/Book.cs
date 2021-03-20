using CsvHelper.Configuration.Attributes;
using System;

namespace Library.Entities
{
    public class Book
    {
        [Name("NumeroTombo")]
        public long PulledDownNumber { get; set; }

        [Name("ISBN")]
        public string Isbn { get; set; }

        [Name("Titulo")]
        public string Title { get; set; }

        [Name("Genero")]
        public string Genre { get; set; }

        [Name("DataPublicacao")]
        public DateTime PublishDate { get; set; }

        [Name("Autor")]
        public string Author { get; set; }
    }
}
