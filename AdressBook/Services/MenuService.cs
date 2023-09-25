using AdressBook.Interface;
using AdressBook.Models;

namespace AdressBook.Services;

public static class MenuService
{
    private static readonly IUserService _userService = new UserService();
    public static void AddUser()
    {
        throw new NotImplementedException();
    }

    public static void DeleteUser()
    {
        throw new NotImplementedException();
    }

    public static void MainMenu()
    {
        User user = new User
        {
            FirstName = "Thomas",
            LastName = "Hallström",
            Email = "minimoto@hotmail.com",
            PhoneNumber = "0706815628",

            Address = new Address
            {
                StreetNumber = "117",
                StreetAdress = "Kvartärvägen",
                PostalCode = "13732",
                City = "Haninge"
            }
        };
        _userService.AddUser(user);
        PrintAllUser();
    }

    public static void PrintAllUser()
    {
        var list = _userService.PrintAllUser();
        foreach (var item in list)
        {
            Console.WriteLine($"{item.FirstName} {item.LastName}");
        }
        Console.ReadLine();
    }

    public static void PrintOnUser()
    {
        throw new NotImplementedException();
    }
}
