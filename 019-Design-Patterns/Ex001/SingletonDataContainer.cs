namespace Ex001;

public class SingletonDataContainer : ISingletonContainer
{
    private static readonly Lazy<SingletonDataContainer> instance = new(() => new SingletonDataContainer());

    private readonly Dictionary<string, int> capitals = new();

    private SingletonDataContainer()
    {
        Console.WriteLine("Initializing singleton object");

        var lines = File.ReadAllLines(Path.Combine(AppContext.BaseDirectory, "capitals.txt"));
        for (var i = 0; i + 1 < lines.Length; i += 2)
            capitals.Add(lines[i], int.Parse(lines[i + 1]));
    }

    public static SingletonDataContainer Instance => instance.Value;

    public int GetPopulation(string name) => capitals[name];
}
