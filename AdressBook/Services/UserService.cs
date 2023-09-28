using AdressBook.Interface;
using AdressBook.Models;

namespace AdressBook.Services;

public class UserService : IUserService
{
    private readonly List<User> _users = new();
    public int AddUser(User user)
    {
        //using StreamReader sr = new(@"C:\Nackademin\c-sharp\FinalExam\TestFile");
        //sr.ReadToEnd();
        //Console.WriteLine(sr.ReadToEnd());

        _users.Add(user);

        //using StreamWriter sw = new StreamWriter(@"C:\Nackademin\TestFile.txt");
        //sw.WriteLine(_users);
        return _users.Count;
    }

    public void DeleteUser(User user)
    {
        _users.Remove(user);
    }

    public List<User> PrintAllUser()
    {
        return _users;
    }

    public User PrintOneUser(string name)
    {
        return _users.FirstOrDefault(x => x.FirstName.ToLower() == name)!;
    }

}
