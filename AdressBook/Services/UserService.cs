using AdressBook.Interface;
using AdressBook.Models;
using Newtonsoft.Json;
using System.Xml.Linq;

namespace AdressBook.Services;

public class UserService : IUserService
{
    public List<User> _users = new();
        FileHandler fileHandler= new FileHandler();
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

    public int DeleteUser(User user)
    {
        _users.Remove(user);
        string json = JsonConvert.SerializeObject(_users);
        fileHandler.SaveToFile(json);
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

}
