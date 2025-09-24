using ExtentionNamespace;
using System.Text;
/*
    алгоритм, вычисляющий результат выражения после преобразования в польскую обратную нотацию
*/
class Computer<T>
{
    public ISet<T> ComputeSet(string line, Dictionary<string, ISet<T>> occurencesOfNamesAndSets)
    {
        Stack<ISet<T>> computerStack = new();
        char element;
        for (int index = 0; index < line.Length; index++)
        {
            element = line[index];
            if (element.IsOperand())
            {
                string name = ParseNameOfSet(ref line, ref index);
                computerStack.Push(occurencesOfNamesAndSets[name]);
            }
            else if (element == ' ')
                continue;
            else
            {
                switch (element.CheckOperator())
                {
                    case 1:
                        var operand = computerStack.Pop();
                        computerStack.Push(operand.Adding());
                        break;
                    case 2:
                        var lastOperand = computerStack.Pop();
                        var firstOperand = computerStack.Pop();
                        
                        switch (element)
                        {
                            case '\\':
                                computerStack.Push(firstOperand.Difference(lastOperand));
                                break;
                            case '∪':
                                computerStack.Push(firstOperand.Union(lastOperand));
                                break;
                            case '∩':
                                computerStack.Push(firstOperand.Intersection(lastOperand));
                                break;
                            case '∆':
                                computerStack.Push(firstOperand.SymmetricDifference(lastOperand));
                                break;
                        }
                        break;
                }
            }
        }

        //последний элемент который останется в стеке - и есть наш ответ
        return computerStack.Pop();
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

        return name.ToString();
    }
}