public class SWriter
{
    private readonly string outputFilePath;
    public void Write(List<string> text)
    {
        if (text == null || text.Count == 0)
            throw new NullReferenceException("�������������� ����� ����");

        StreamWriter writer = new(outputFilePath);
        foreach (var line in text)
            writer.WriteLine(line);

        writer.Close();
    }

    public SWriter() 
    {
        DirectoryInfo currentDirectory = new DirectoryInfo(Directory.GetCurrentDirectory());
        outputFilePath = System.Environment.OSVersion.Platform == PlatformID.Unix
            ? currentDirectory.FullName + "../../../../TxtFiles/outputFile.txt"
            : currentDirectory.FullName + "..\\..\\..\\..\\TxtFiles\\outputFile.txt";
    }
}