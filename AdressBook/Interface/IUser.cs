using AdressBook.Models;

namespace AdressBook.Interface;

public interface IUser
{
    string? FirstName { get; set; }
    string? LastName { get; set; }
    string? Email { get; set; }
    IAddress? Address { get; set; }
    string? PhoneNumber {  get; set; }
}
