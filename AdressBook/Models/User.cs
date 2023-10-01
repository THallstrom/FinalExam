using AdressBook.Interface;

namespace AdressBook.Models
{
    public class User : IUser
    {
        public string FirstName { get; set; } = null!;
        public string LastName { get; set; } = null!;
        public string Email { get; set; } = null!;
        public Address Address { get; set; } = null!;
        public string PhoneNumber { get; set; } = null!;
    }
}
