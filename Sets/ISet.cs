public interface ISet<T> where T : IComparable<T>
{
    public List<T> Set
    {
        get;
    }

    public string Name
    {
        get;
    }

    public ISet<T> Union(ISet<T> set);
    public ISet<T> Intersection(ISet<T> set);
    public ISet<T> Difference(ISet<T> set);
    public ISet<T> SymmetricDifference(ISet<T> set);
    public ISet<T> Adding();
}