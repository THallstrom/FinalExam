using AdressBook.Models;

namespace AdressBook.Interface;

public interface IUserService
{
    public int AddUser(User user);
    List <User> PrintAllUser();
    public User PrintOneUser(string name);
    public User PrintOneUser(int index);
    public void ChangeInfo(int index);
    public int DeleteUser(User user);
    public int DeleteUser(string index);
    public void UpdateList();
}
