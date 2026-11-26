namespace Ex001;

public class Sandwich : SandwichPrototype
{
    public Sandwich(string bread, string meat, string cheese, string veggies)
    {
        Bread = bread;
        Meat = meat;
        Cheese = cheese;
        Veggies = veggies;
    }

    public string Bread { get; }

    public string Meat { get; }

    public string Cheese { get; }

    public string Veggies { get; }

    public override SandwichPrototype Clone()
    {
        Console.WriteLine($"Cloning sandwich with ingredients: {GetIngredientList()}");
        return (SandwichPrototype)MemberwiseClone();
    }

    private string GetIngredientList()
    {
        return string.Join(", ", new[] { Bread, Meat, Cheese, Veggies }.Where(i => i != ""));
    }
}
