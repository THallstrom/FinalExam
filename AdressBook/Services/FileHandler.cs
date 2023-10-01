namespace AdressBook.Services;

public class FileHandler
{
    private readonly string _filePath = @"C:\Nackademin\c-sharp\json.txt";
    public void SaveToFile(string json)
    {
        using StreamWriter sr = new StreamWriter(_filePath);
        sr.WriteLine(json);
    }

    public string ReadFromFile()
    {
        using StreamReader sr = new StreamReader(_filePath);
        return sr.ReadToEnd();
        
    }
}
