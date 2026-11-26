namespace Ex001;

public class Product
{
    public Product(string label, decimal price, int quantity)
    {
        Label = label;
        Price = price;
        Quantity = quantity;
    }

    public string Label { get; }

    public decimal Price { get; }

    public int Quantity { get; }
}
