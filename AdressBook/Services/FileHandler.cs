namespace AdressBook.Services;

public class FileHandler
{
    public void SaveToFile()
    {

    }

    public string ReadFromFile(string filePath)
    {
        using StreamReader sr = new StreamReader(filePath);
        return sr.ReadToEnd();
        
    }
}
