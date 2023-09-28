using AdressBook.Models;

namespace AdressBook.Interface;

public interface IUserService
{
    public void AddUser(User user);
    List <User> PrintAllUser();
    public IUser PrintOneUser(string name);
    void DeleteUser(User user);
}
