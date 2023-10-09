namespace AdressBook.Services;

public class FileHandler
{
    private readonly string _filePath = @"json";
    public void SaveToFile(string json)
    {
        using StreamWriter sr = new StreamWriter(_filePath);
        sr.WriteLine(json);
    }

    public string ReadFromFile()
    {
        try
        {
            using StreamReader sr = new StreamReader(_filePath);
            if (sr != null)
                return sr.ReadToEnd();
        }
        catch (Exception)
        {
            
        }
        return null!;
    }
}
