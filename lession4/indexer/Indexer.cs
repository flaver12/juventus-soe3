namespace IndexerNamespace;

public class Indexer
{
    private readonly string[] _data;

    public Indexer(int length)
    {
        _data = new string[length];
    }

    public string this[int index]
    {
        get => _data[index];
        set => _data[index] = value;
    }
}
