using AdressBook.Interface;
using AdressBook.Models;
using System.Diagnostics;

namespace AdressBook.Services;

public static class MenuService
{
    private static readonly IUserService _userService = new UserService();
    private static readonly FileHandler fileHandler = new FileHandler();

    static void Message(int num, User user)
    {
        Console.WriteLine($"{user.FirstName} {user.LastName} tillagd i listan");
        Console.WriteLine($"Listan innehåller: {num} personer");
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
        Message(num, user);
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
        Message(num, user);

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
        Message(num, user1);
    }

    public static void DeleteUser()
    {
        try
        {
            var list = _userService.PrintAllUser();
            if (list.Count != 0)
            {
                PrintList();
                Console.WriteLine("Vilken användare önskar du radera: ");
                var option = Convert.ToInt32(Console.ReadLine());
                _userService.DeleteUser(list[option]);
            }
            else
            {
                Console.WriteLine("Adresslistan är tyvärr tom");
                Console.ReadLine();
            }
        }
        catch (Exception)
        {

            throw;
        }

    }

    public static void MainMenu()
    {
        try
        {
            do
            {
                _userService.UpdateList();
                Console.Clear();
                Console.WriteLine("");
                Console.WriteLine("1. Lägg till i adressboken");
                Console.WriteLine("2. Skriv ut en användare");
                Console.WriteLine("3. Skriv ut alla användare");
                Console.WriteLine("4. Ändra uppgifter om användare");
                Console.WriteLine("5. Radera användare");
                Console.WriteLine("0. Avsluta");
                Console.Write("Välj det val som passar: ");
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
                        ChangeUserInfo();
                        break;
                    case "5":
                        DeleteUser();
                        break;
                    case "6":
                        AddUserCheat();
                        break;
                    case "7":

                        break;
                    case "0":
                        Environment.Exit(0);
                        break;
                }
            } while (true);
        }
        catch (FileNotFoundException e) 
        {
            Console.WriteLine("Filen hittades inte, var vänlig ända sökvägen");
            Console.ReadLine();
        };
        //{
        //    
        //}
    }

    public static void PrintAllUser()
    {
        PrintList();
        Console.ReadLine();

    }
    public static void PrintList()
    {
        try
        {
            var list = _userService.PrintAllUser();
            var i = 0;
            if (list.Count != 0)
            {
                Console.Clear();
                foreach (var item in list)
                {
                    Console.WriteLine($"{i} {item.FirstName} {item.LastName}");
                    i++;
                }
            }
            else
            {
                Console.WriteLine("Adresslistan är tyvärr tom");
            }

        }
        catch (Exception)
        {

            throw;
        }

    }
    public static void PrintAllInfo(User mySelf)
    {
        Console.Clear();
        Console.WriteLine("Info om användaren");
        Console.WriteLine("----------------------------");
        Console.WriteLine($"Namn: \t\t{mySelf.FirstName} {mySelf.LastName}");
        Console.WriteLine($"Email: \t\t{mySelf.Email}");
        Console.WriteLine($"Telefon: \t{mySelf.PhoneNumber}");
        Console.WriteLine($"Adress: \t{mySelf.Address.StreetAdress} {mySelf.Address.StreetNumber}");
        Console.WriteLine($"Postadress: \t{mySelf.Address.PostalCode} {mySelf.Address.City}");
        
    }
    public static void PrintOneUser()
    {
        try
        {
            Console.Clear();
            PrintList();
            Console.Write("Skriv in förnamnet på den du söker eller index: ");

            string searchUser = Console.ReadLine()!;

            if (searchUser != "")
            {
                bool result = Int32.TryParse(searchUser, out int number);
                if (result == true)
                {
                    var mySelf = _userService.PrintOneUser(number);
                    PrintAllInfo(mySelf);
                }
                else
                {
                    var mySelf = _userService.PrintOneUser(searchUser);
                    PrintAllInfo(mySelf);
                }
            }
            else
            {
                Console.WriteLine("Jag behöver ett namn att söka på");
            }
            Console.ReadLine();
        }
        catch (Exception)
        {

            throw;
        }
    }
    public static void ChangeUserInfo()
    {
        PrintList();
        Console.WriteLine("Vilket index önskar du ändra i adressboken");
        int option = Convert.ToInt32(Console.ReadLine());
        _userService.ChangeInfo(option);
        PrintAllInfo(_userService.PrintOneUser(option));
        Console.ReadLine();

    }
}
