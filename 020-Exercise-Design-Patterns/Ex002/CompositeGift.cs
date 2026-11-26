namespace Ex002;

public class CompositeGift : GiftBase, IGiftOperations
{
    private readonly List<GiftBase> gifts = new();

    public CompositeGift(string name, int price)
        : base(name, price) { }

    public void Add(GiftBase gift) => gifts.Add(gift);

    public void Remove(GiftBase gift) => gifts.Remove(gift);

    public override int CalculateTotalPrice()
    {
        Console.WriteLine($"{Name} contains the following products with prices:");
        return Price + gifts.Sum(g => g.CalculateTotalPrice());
    }
}
