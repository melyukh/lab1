/*
    класс множества
*/
public class SetClass<T> : ISet<T>
{
    private List<T> _set; //элементы множества
    private readonly string _name; //имя множества
    public List<T> Set
    {
        get { return _set; }
    }
    public string Name
    {
        get { return _name; }
    }    
    public SetClass(List<T> set, string name)
    {
        _set = set.Distinct().ToList();
        _name = name;
    }

    public SetClass(List<T> set) : this(set, "_") { }

    public ISet<T> Union(ISet<T> set)
        => set is SetClass<T>
        ? new SetClass<T>(this.Set.Union(set.Set).ToList())
        : new SetClassFromUnique<T>(set.Set.Where(value => !this.Set.Contains(value)).ToList());

    public ISet<T> Intersection(ISet<T> set)
        => set is SetClass<T>
        ? new SetClass<T>(this.Set.Intersect(set.Set).ToList())
        : new SetClass<T>(this.Set.Where(value => !set.Set.Contains(value)).ToList());

    public ISet<T> Difference(ISet<T> set)
        => set is SetClass<T>
        ? new SetClass<T>(this.Set.Except(set.Set).ToList())
        : new SetClass<T>(this.Set.Where(value => set.Set.Contains(value)).ToList());

    public ISet<T> SymmetricDifference(ISet<T> set)
        => set is SetClass<T>
        ? new SetClass<T>((this.Set.Except(set.Set)).Union(set.Set.Except(this.Set)).ToList())
        : new SetClassFromUnique<T>((this.Set.Except(set.Set)).Union(set.Set.Except(this.Set)).ToList());

    public ISet<T> Adding()
        => new SetClassFromUnique<T>(this.Set);
}
