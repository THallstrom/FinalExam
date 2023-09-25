using AdressBook.Interface;

namespace AdressBook.Models
{
    public class Address : IAddress
    {
        public string StreetAdress { get; set; } = null!;
        public string StreetNumber { get; set; } = null!;
        public string PostalCode { get; set; } = null!;
        public string City { get; set; } = null!;
    }
}
