using AdressBook.Models;

namespace AdressBook.Interface;

public interface IUserService
{
    public void AddUser(User user);
    List <User> PrintAllUser();
    void PrintOneUSer();
    void SearchUser();
    void DeleteUser();
}
