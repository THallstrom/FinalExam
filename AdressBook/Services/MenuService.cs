using AdressBook.Interface;
using AdressBook.Models;

namespace AdressBook.Services;

public static class MenuService
{
    private static readonly IUserService _userService = new UserService();

    static void Message(int num)
    {
        Console.WriteLine($"Användare tillagd till list, Listan innehåller: {num} personer");
        Console.WriteLine("Click för att komma vidare");
        Console.ReadKey();
    }
    public static void AddUser()
    {
        User user = new User();
        Console.Write("Förnamn: ");
        user.FirstName = Console.ReadLine()!;
        Console.Write("Efternamn: ");
        user.LastName = Console.ReadLine()!;
        Console.Write("Email: ");
        user.Email = Console.ReadLine()!;
        user.Address = new Address();
        Console.Write("Gatunamn: ");
        user.Address.StreetAdress = Console.ReadLine()!;
        Console.Write("Gatunummer: ");
        user.Address.StreetNumber = Console.ReadLine()!;
        Console.Write("Postadress ");
        user.Address.City = Console.ReadLine()!;
        Console.Write("Postnummer:");
        user.Address.PostalCode = Console.ReadLine()!;
        var num = _userService.AddUser(user);
        Message(num);
    }

    public static void AddUserCheat()
    {
        User user = new User
        {
            FirstName = "Thomas",
            LastName = "Hallström",
            Email = "minimoto@hotmail.com",
            PhoneNumber = "0706815628",

            Address = new Models.Address
            {
                StreetNumber = "117",
                StreetAdress = "Kvartärvägen",
                PostalCode = "13732",
                City = "Haninge"
            }
        };
        var num = _userService.AddUser(user);
        Message(num);

        User user1 = new User
        {
            FirstName = "Tina",
            LastName = "Granne",
            Email = "tine@hotmail.com",
            PhoneNumber = "0706815562",

            Address = new Models.Address
            {
                StreetNumber = "119",
                StreetAdress = "Kvartärvägen",
                PostalCode = "13732",
                City = "Haninge"
            }
        };
        num = _userService.AddUser(user1);
        Message(num);
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
                Console.Clear();
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
                    case "6":
                        AddUserCheat();
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
