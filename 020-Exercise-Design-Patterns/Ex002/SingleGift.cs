namespace Ex002;

public class SingleGift : GiftBase
{
    public SingleGift(string name, int price)
        : base(name, price) { }

    public override int CalculateTotalPrice()
    {
        Console.WriteLine($"{Name} with the price {Price}");
        return Price;
    }
}
