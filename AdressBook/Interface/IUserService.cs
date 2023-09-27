using AdressBook.Models;

namespace AdressBook.Interface;

public interface IUserService
{
    public void AddUser(User user);
    List <User> PrintAllUser();
    IUser PrintOneUSer(string name);
    void SearchUser();
    void DeleteUser(User user);
}
