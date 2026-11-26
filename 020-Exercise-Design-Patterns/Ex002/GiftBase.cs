namespace Ex002;

public abstract class GiftBase
{
    protected GiftBase(string name, int price)
    {
        Name = name;
        Price = price;
    }

    public string Name { get; }

    public int Price { get; }

    public abstract int CalculateTotalPrice();
}
