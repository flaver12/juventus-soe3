namespace IndexerNamespace;

public class IndexerGeneric<T>
{
    private readonly T[] _data;

    public IndexerGeneric(int length)
    {
        _data = new T[length];
    }

    public T this[int index]
    {
        get => _data[index];
        set => _data[index] = value;
    }
}
