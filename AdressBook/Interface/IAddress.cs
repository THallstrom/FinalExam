namespace AdressBook.Interface;

public interface IAddress
{
    public string? StreetAdress { get; set; }
    public string? StreetNumber { get; set; }
    public string? PostalCode { get; set; }
    public string? City { get; set; }
}
