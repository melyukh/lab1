public class SWriter
{
    private readonly string outputFilePath = "../../../TxtFiles/outputFile.txt";
    public void Write(List<string> text)
    {
        StreamWriter writer = new(outputFilePath);
        foreach (var line in text)
            writer.WriteLine(line);

        writer.Close();
    }
}