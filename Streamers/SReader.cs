public class SReader
{
    private readonly string initFilePath;
    private readonly string initDataTypePath;
    private readonly int numOfLines;
    public void Initialize(out Dictionary<string, ISet<int>> nameAndSetsPairs, out string operationLine)
    {
        StreamReader reader = new(initFilePath);
        nameAndSetsPairs = new();
        string name;
        List<int> ints;
        for (int i = 1; i < numOfLines; i += 2)
        {
            name = reader.ReadLine()!;
            ints = reader.ReadLine()!.Split(" ").Select(item => Convert.ToInt32(item)).ToList();
            if (name.EndsWith("_U"))
                nameAndSetsPairs.Add(name, new SetClassFromUnique<int>(ints, name));
            else
                nameAndSetsPairs.Add(name, new SetClass<int>(ints, name));
        }
        operationLine = reader.ReadLine()!;
        reader.Close();
    }

    public void Initialize(out Dictionary<string, ISet<string>> nameAndSetsPairs, out string operationLine)
    {
        StreamReader reader = new(initFilePath);
        nameAndSetsPairs = new();
        string name;
        List<string> strings;
        for (int i = 1; i < numOfLines; i += 2)
        {
            name = reader.ReadLine()!;
            strings = reader.ReadLine()!.Split(" ").ToList();
            if (name.EndsWith("_U"))
                nameAndSetsPairs.Add(name, new SetClassFromUnique<string>(strings, name));
            else
                nameAndSetsPairs.Add(name, new SetClass<string>(strings, name));
        }
        operationLine = reader.ReadLine()!;
        reader.Close();
    }

    public void Initialize(out Dictionary<string, ISet<double>> nameAndSetsPairs, out string operationLine)
    {
        StreamReader reader = new(initFilePath);
        nameAndSetsPairs = new();
        string name;
        List<double> doubles;
        for (int i = 1; i < numOfLines; i += 2)
        {
            name = reader.ReadLine()!;
            doubles = reader.ReadLine()!.Split(" ").Select(item => Convert.ToDouble(item)).ToList();
            if (name.EndsWith("_U"))
                nameAndSetsPairs.Add(name, new SetClassFromUnique<double>(doubles, name));
            else
                nameAndSetsPairs.Add(name, new SetClass<double>(doubles, name));
        }
        operationLine = reader.ReadLine()!;
        reader.Close();
    }

    public string DataType()
    {
        StreamReader dtReader = new(initDataTypePath);
        string type = dtReader.ReadLine()!;
        dtReader.Close();
        return type;
    }
    public SReader()
    {
        DirectoryInfo currentDirectory = new DirectoryInfo(Directory.GetCurrentDirectory());
        initDataTypePath = System.Environment.OSVersion.Platform == PlatformID.Unix
            ? currentDirectory.FullName + "../../../TxtFiles.initDataTypeFile.txt"
            : currentDirectory.FullName + "..\\..\\..\\..\\TxtFiles\\initDataTypeFile.txt";
        initFilePath = System.Environment.OSVersion.Platform == PlatformID.Unix
            ? currentDirectory.FullName + "../../../TxtFiles.initFile.txt"
            : currentDirectory.FullName + "..\\..\\..\\..\\TxtFiles\\initFile.txt";
        numOfLines = File.ReadLines(initFilePath).Count();
    }
}