using AdressBook.Interface;
using AdressBook.Models;

namespace AdressBook.Services;

public static class MenuService
{
    private static readonly IUserService _userService = new UserService();
    public static void AddUser()
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
        User user1 = new User
        {
            FirstName = "Tina",
            LastName = "Granne",
            Email = "tine@hotmail.com",
            PhoneNumber = "0706815562",

            Address = new Address
            {
                StreetNumber = "119",
                StreetAdress = "Kvartärvägen",
                PostalCode = "13732",
                City = "Haninge"
            }
        };
        _userService.AddUser(user1);
    }

    public static void DeleteUser()
    {
        var list = _userService.PrintAllUser();
        PrintList();
        Console.WriteLine("Vilken användare önskar du radera: ");
        var option = Convert.ToInt32(Console.ReadLine());
        _userService.DeleteUser(list[option]);
    }

    public static void MainMenu()
    {
        try
        {
            do
            {
                // Console.Clear();
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
                        AddUser();
                        break;
                    case "2":
                        PrintOneUser();
                        break;
                    case "3":
                        PrintAllUser();
                        break;
                    case "4":
                        break;
                    case "5":
                        DeleteUser();
                        break;
                    case "0":
                        Environment.Exit(0);
                        break;
                }
            } while (true);
        }
        catch { }
    }

    public static void PrintAllUser()
    {
        PrintList();
        Console.ReadLine();

    }
    public static void PrintList()
    {
        var list = _userService.PrintAllUser();
        var i = 0;
        Console.Clear();
        foreach (var item in list)
        {
            Console.WriteLine($"{i} {item.FirstName} {item.LastName}");
            i++;
        }
    }

    public static void PrintOneUser()
    {
        try
        {
            Console.Write("Skriv in förnamnet på den du söker: ");
            string searchUser = Console.ReadLine()!;
            
            if (searchUser != "")
            {
                var mySelf = _userService.PrintOneUser(searchUser.ToLower());
                Console.WriteLine(mySelf.FirstName + " " + mySelf.LastName);
            }
            else
            {
                Console.WriteLine("Jag behöver ett namn att söka på");
            }
            // Console.ReadLine();
        }
        catch (Exception)
        {

            throw;
        }

    }
}
