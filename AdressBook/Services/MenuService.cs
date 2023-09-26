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
        try
        {
            Console.WriteLine("");
            Console.WriteLine("1. Lägg till i adressboken");
            Console.WriteLine("2. Skriv ut en användare");
            Console.WriteLine("3. Skriv ut alla användare");
            Console.WriteLine("4. Ändra uppgifter om användare");
            Console.WriteLine("5. Radera användare");
            Console.WriteLine("0. Avsluta");
            Console.Write("Välj det val som passar:");
            var option = Console.ReadLine();
            switch (option)
            {
                case "1":
                    break;
                case "2":
                    break;
                case "3":
                    break;
                case "4":
                    break;
                case "5":
                    break;
                case "0":
                    break;
            }
        }
        catch (Exception)
        {

            throw;
        }


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
