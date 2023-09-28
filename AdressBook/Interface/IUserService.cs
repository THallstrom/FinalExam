using AdressBook.Models;

namespace AdressBook.Interface;

public interface IUserService
{
    public int AddUser(User user);
    List <User> PrintAllUser();
    public User PrintOneUser(string name);
    void DeleteUser(User user);
}
