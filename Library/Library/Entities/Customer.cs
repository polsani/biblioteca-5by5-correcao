using System;

namespace Library.Entities
{
    public class Customer
    {
        public long Id { get; set; }
        public string Document { get; set; }
        public string Name { get; set; }
        public DateTime BirthDate { get; set; }
        public string Phone { get; set; }
        public Address Address { get; set; }
    }
}
