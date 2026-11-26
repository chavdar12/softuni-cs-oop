namespace Ex001;

public class SandwichMenu
{
    private readonly Dictionary<string, SandwichPrototype> sandwiches = new();

    public SandwichPrototype this[string name]
    {
        get => sandwiches[name];
        set => sandwiches[name] = value;
    }
}
