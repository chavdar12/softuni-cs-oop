namespace Ex003;

public class Product
{
    public Product(string name, int price)
    {
        Name = name;
        Price = price;
    }

    public string Name { get; }

    public int Price { get; private set; }

    public void IncreasePrice(int amount)
    {
        Price += amount;
        Console.WriteLine($"The price for the {Name} has been increased by {amount}$.");
    }

    public void DecreasePrice(int amount)
    {
        if (amount >= Price)
            return;

        Price -= amount;
        Console.WriteLine($"The price for the {Name} has been decreased by {amount}$.");
    }

    public override string ToString() => $"Current price for the {Name} product is {Price}$.";
}
