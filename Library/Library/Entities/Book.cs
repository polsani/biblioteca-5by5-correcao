using System;

namespace Library.Entities
{
    public class Book
    {
        public long PulledDownNumber { get; set; }
        public string Isbn { get; set; }
        public string Title { get; set; }
        public string Genre { get; set; }
        public DateTime PublishDate { get; set; }
        public string Author { get; set; }
    }
}
