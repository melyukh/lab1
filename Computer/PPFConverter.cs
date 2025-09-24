using System.Text;
using ExtentionNamespace;
public class Converter
{
    private Dictionary<char, byte> operatorPriority = new()
    {
        {'(', 0},
        { '∪', 1}, //объединение
        {'∩', 2}, //пересечение
        {'\\', 1}, //разность
        {'∆', 1}, //симметричная разность
        {'\'', 3} //дополнение
    };
    public string ConvertFromBasicFormToPPF(string line) // функция конвертации
    {
        StringBuilder ppfResult = new();
        Stack<char> operatorStack = new();
        char symbol;

        for (int index = 0; index < line.Length; index++)
        {
            symbol = line[index];
            // если операнд, то парсим имя пока не закончится:
            if (symbol.IsOperand())
                ppfResult.Append(ParseNameOfSet(ref line, ref index));
            /*
                если символ - оператор, то
                выталкиваем в строку все операторы, пока те имеют больший/равный приоритет по отношению к нашему оператору
                пока не сможем положить элемент в стек 
            */
            else if (symbol.IsOperator())
            {
                while (operatorStack.Count > 0 && operatorPriority[operatorStack.Peek()] >= operatorPriority[symbol])
                    ppfResult.Append(operatorStack.Pop());

                operatorStack.Push(symbol);
            }

            //если скобка открывающая, то кладем в стек:
            else if (symbol == '(')
                operatorStack.Push(symbol);

            /* 
                если скобка закрывающая, то
                достаем элементы из стека и кладем в выходную строку пока не встретим открывающую скобку
                при этом нужно учесть, что если мы не встретим скобку, а стек закончится, то у нас есть ошибка в вводе
            */
            else if (symbol == ')')
            {
                while (operatorStack.Count > 0 && operatorStack.Peek() != '(')
                    ppfResult.Append(operatorStack.Pop());
                operatorStack.Pop();
            }


        }

        //все, что осталось в стеке нужно положить в выходную строку
        while (operatorStack.Count > 0)
            ppfResult.Append(operatorStack.Pop());

        return ppfResult.ToString();
    }
    private string ParseNameOfSet(ref string line, ref int index)
    {
        StringBuilder name = new();
        for (; index < line.Length; index++)
        {
            char element = line[index];
            if (element.IsOperand())
                name.Append(element);
            else
            {
                index--;
                break;
            }    
        }

        return name.ToString() + " ";
    }
}

