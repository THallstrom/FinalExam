using AdressBook.Interface;
using AdressBook.Models;

namespace AdressBook.Services;

public class UserService : IUserService
{
    private readonly List<User> _users = new();
    public void AddUser(User user)
    {
        _users.Add(user);
    }

    public void DeleteUser(User user)
    {
        _users.Remove(user);
    }

    public List<User> PrintAllUser()
    {
        return _users;
    }

    public IUser PrintOneUser(string name)
    {
        return _users.FirstOrDefault(x => x.FirstName.ToLower() == name)!;
    }

}
