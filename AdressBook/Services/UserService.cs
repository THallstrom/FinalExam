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
        // throw new NotImplementedException();
    }

    public List<User> PrintAllUser()
    {
        return _users;
    }

    public void PrintOneUSer()
    {
        throw new NotImplementedException();
    }

    public void SearchUser()
    {
        throw new NotImplementedException();
    }
}
