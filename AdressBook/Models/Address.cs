using AdressBook.Interface;

namespace AdressBook.Models
{
    public class Address : IAddress
    {
        public string? StreetAdress { get; set; }
        public string? StreetNumber { get; set; }
        public string? PostalCode { get; set; }
        public string? City { get; set; }
    }
}
