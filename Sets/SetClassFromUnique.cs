/*
    класс-костыль
    представляет из себя множество, которое получается при дополнении обычного множества
    поддерживает все операции что и обычное, при дополнении результатом будет множество из обычного класса
*/
public class SetClassFromUnique<T> : ISet<T> where T : IComparable<T>
{
    private List<T> _set; //хранит элементы, которые исключены из универсального множества
    private readonly string _name; //имя множества
    public List<T> Set
    {
        get { return _set; }
    }
    
    public string Name
    {
        get { return _name; }
    }
    public SetClassFromUnique(List<T> set, string name)
    {
        _set = set.Distinct().ToList();
        _name = name;
    }

    public void Sort()
        => this.Set.Sort();
    
    public SetClassFromUnique(List<T> set) : this(set, "_") { }

    public ISet<T> Union(ISet<T> set)
        => set is SetClassFromUnique<T>
        ? new SetClassFromUnique<T>(this.Set.Intersect(set.Set).ToList())
        : new SetClassFromUnique<T>(this.Set.Except(set.Set).ToList());

    public ISet<T> Intersection(ISet<T> set)
        => set is SetClassFromUnique<T>
        ? new SetClassFromUnique<T>(this.Set.Union(set.Set).ToList())
        : new SetClass<T>(set.Set.Except(this.Set).ToList());

    public ISet<T> Difference(ISet<T> set)
        => set is SetClassFromUnique<T>
        ? new SetClass<T>(set.Set.Except(this.Set).ToList())
        : new SetClassFromUnique<T>(this.Set.Union(set.Set).ToList());

    public ISet<T> SymmetricDifference(ISet<T> set)
        => set is SetClassFromUnique<T>
        ? new SetClass<T>(set.Set.Except(this.Set).Union(this.Set.Except(set.Set)).ToList())
        : new SetClassFromUnique<T>(this.Set.Union(set.Set).Except(this.Set.Intersect(set.Set)).ToList());

    public ISet<T> Adding()
        => new SetClass<T>(this.Set);
}