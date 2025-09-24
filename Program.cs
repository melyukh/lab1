internal class Program
{
    static public void Main(string[] args)
    {
        SReader reader = new();
        SWriter writer = new();
        List<string>? result = null;

        //получение типа данных из initDataTypeFile
        string dataType = reader.DataType();

        //в зависимости от типа данных будет создаваться соответствующий объект и производиться вычисление результата
        if (dataType == "string")
        {
            reader.Initialize(out Dictionary<string, ISet<string>> dict, out string operationLine);
            result = Calculator<string>(operationLine, dict);
        }
        else if (dataType == "int")
        {
            reader.Initialize(out Dictionary<string, ISet<int>> dict, out string operationLine);
            result = Calculator<int>(operationLine, dict);
        }
        else if (dataType == "double")
        {
            reader.Initialize(out Dictionary<string, ISet<double>> dict, out string operationLine);
            result = Calculator<double>(operationLine, dict);
        }

        //вывод результата в файл outputFile
        writer.Write(result!);
    }


    static public List<string> Calculator<T>(string operationLine, Dictionary<string, ISet<T>> dict)
    {
        Computer<T> computer = new();
        Converter converter = new();
        operationLine = converter.ConvertFromBasicFormToPPF(operationLine);
        ISet<T> set = computer.ComputeSet(operationLine, dict);

        return new()
        {
            set is SetClass<T>
            ? $"Множество типа {typeof(T)}" 
            : $"Множество, близкое к универсальному, типа {typeof(T)}",
            set.Set.Count != 0 ? '{' + String.Join(' ', set.Set)+ '}' : "∅" 
        };
    }
}
