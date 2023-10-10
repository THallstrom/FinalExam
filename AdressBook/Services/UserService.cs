using AdressBook.Interface;
using AdressBook.Models;
using Newtonsoft.Json;
using System.Collections.Generic;

namespace AdressBook.Services;

public class UserService : IUserService
{
    public List<User> _users = new();
    FileHandler fileHandler = new FileHandler();
    public int AddUser(User user)
    {
        _users.Add(user);
        string json = JsonConvert.SerializeObject(_users);
        fileHandler.SaveToFile(json);

        return _users.Count;
    }

    public void UpdateList()
    {
        var json = fileHandler.ReadFromFile();
        if (!string.IsNullOrEmpty(json))
            _users = JsonConvert.DeserializeObject<List<User>>(json)!;
    }

    public void AddToListFile()
    {
        string json = JsonConvert.SerializeObject(_users);
        fileHandler.SaveToFile(json);
    }

    public int DeleteUser(User user)
    {
        _users.Remove(user);
        AddToListFile();
        Console.WriteLine($"{user.FirstName} {user.LastName} raderades från listan");
        Console.ReadLine();
        return _users.Count;
    }
    public int DeleteUser(string user)
    {
        var userDelete = _users.FirstOrDefault(x => x.FirstName.ToLower() == user.ToLower())!;
        _users.Remove(userDelete);
        AddToListFile();
        Console.WriteLine($"{userDelete.FirstName} {userDelete.LastName} raderades från listan");
        Console.ReadLine();
        return _users.Count;
    }

    public List<User> PrintAllUser()
    {
        return _users;
    }

    public User PrintOneUser(string name)
    {
        try
        {
            return _users.FirstOrDefault(x => x.FirstName.ToLower() == name.ToLower())!;
        }
        catch { }
        return _users[0];
    }

    public User PrintOneUser(int index)
    {
        try
        {
            return _users[index];
        }
        catch { }
        return null!;
    }

    public void ChangeInfo(int index)
    {
        Console.Clear();
        Console.WriteLine($"Du önskar ändra info om: {_users[index].FirstName} {_users[index].LastName}");
        Console.WriteLine();
        Console.WriteLine("1. Förnamn");
        Console.WriteLine("2. Efternamn");
        Console.WriteLine("3. Email");
        Console.WriteLine("4. Telefonnummer");
        Console.WriteLine("5. GatuAdress");
        Console.WriteLine("6. Gatunummer");
        Console.WriteLine("7. Postadress");
        Console.WriteLine("8. Postnummer");
        Console.Write("Välj alternativ 1-8 ");
        var option = Console.ReadLine();
        switch (option)
        {
            case "1":
                Console.WriteLine("Vänligen skriv in nya förnamnet");
                _users[index].FirstName = Console.ReadLine()!;
                AddToListFile();
                break;
            case "2":
                Console.WriteLine("Vänligen skriv in nya efternamnet");
                _users[index].LastName = Console.ReadLine()!;
                AddToListFile();
                break;
            case "3":
                Console.WriteLine("Vänligen skriv in nya email");
                _users[index].Email = Console.ReadLine()!;
                AddToListFile();
                break;
            case "4":
                Console.WriteLine("Vänligen skriv in nya telefonnummer");
                _users[index].PhoneNumber = Console.ReadLine()!;
                AddToListFile();
                break;
            case "5":
                Console.WriteLine("Vänligen skriv in nya gatuadress");
                _users[index].Address.StreetAdress = Console.ReadLine()!;
                AddToListFile();
                break;
            case "6":
                Console.WriteLine("Vänligen skriv in nya gatunummer");
                _users[index].Address.StreetNumber = Console.ReadLine()!;
                AddToListFile();
                break;
            case "7":
                Console.WriteLine("Vänligen skriv in nya postadressen");
                _users[index].Address.City = Console.ReadLine()!;
                AddToListFile();
                break;
            case "8":
                Console.WriteLine("Vänligen skriv in nya postnummer");
                _users[index].Address.PostalCode = Console.ReadLine()!;
                AddToListFile();
                break;
            default:
                Console.WriteLine("Det var ett felaktigt val");
                    break;
        }
    }
}
