using IndexerNamespace;

// Fruites indexer
Indexer indexer =
    new(5)
    {
        [0] = "Apple",
        [1] = "Banana",
        [2] = "Cherry",
        [3] = "Date",
        [4] = "Elderberry"
    };

Console.WriteLine("Fruites:");
Console.WriteLine("-----------------");

for (int i = 0; i < 5; i++)
{
    Console.WriteLine(indexer[i]);
}

// Fruites indexer Generic
IndexerGeneric<string> indexerGeneric =
    new(5)
    {
        [0] = "Apple",
        [1] = "Banana",
        [2] = "Cherry",
        [3] = "Date",
        [4] = "Elderberry"
    };

// Int indexer Generic
IndexerGeneric<int> indexerGenericInt =
    new(5)
    {
        [0] = 1,
        [1] = 2,
        [2] = 3,
        [3] = 4,
        [4] = 5
    };

Console.WriteLine("\nFruites indexer Generic:");
Console.WriteLine("-----------------");

for (int i = 0; i < 5; i++)
{
    Console.WriteLine(indexerGeneric[i]);
}

Console.WriteLine("\nInt indexer Generic:");
Console.WriteLine("-----------------");

for (int i = 0; i < 5; i++)
{
    Console.WriteLine(indexerGenericInt[i]);
}

Console.ReadLine();
