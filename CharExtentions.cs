namespace ExtentionNamespace;
static class CharExtension
{
    static private readonly List<char> binaryOperators = new() {'∪', '∩', '\\', '∆'};
    static public bool IsOperand(this char symbol)
        => char.IsLetter(symbol) || symbol == '_';
    static public bool IsOperator(this char symbol)
        => binaryOperators.Contains(symbol) || symbol == '\'';
    static public int CheckOperator(this char symbol)
        => binaryOperators.Contains(symbol) ? 2 : 1; // возвращает 2, если оператор бинарный, 1 - если унарный(дополнение)   
}
