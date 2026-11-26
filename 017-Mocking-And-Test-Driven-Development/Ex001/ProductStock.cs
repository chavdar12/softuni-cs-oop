using System.Collections;

namespace Ex001;

public class ProductStock : IProductStock
{
    private readonly List<Product> products = new();
    private readonly Dictionary<string, Product> byLabel = new();

    public int Count => products.Count;

    public Product this[int index] => Find(index);

    public void Add(Product product)
    {
        if (!byLabel.TryAdd(product.Label, product))
            throw new ArgumentException($"Product {product.Label} is already in stock.");

        products.Add(product);
    }

    public bool Contains(Product product) => byLabel.ContainsKey(product.Label);

    public Product Find(int index)
    {
        if (index < 0 || index >= products.Count)
            throw new IndexOutOfRangeException();

        return products[index];
    }

    public Product FindByLabel(string label)
    {
        return byLabel.TryGetValue(label, out var product)
            ? product
            : throw new ArgumentException($"Product {label} is not in stock.");
    }

    public IEnumerable<Product> FindAllInPriceRange(decimal low, decimal high)
    {
        return products.Where(p => p.Price >= low && p.Price <= high).OrderByDescending(p => p.Price);
    }

    public IEnumerable<Product> FindAllByPrice(decimal price) => products.Where(p => p.Price == price);

    public IEnumerable<Product> FindMostExpensiveProducts(int count)
    {
        if (count > products.Count)
            throw new ArgumentException("Not enough products in stock.");

        return products.OrderByDescending(p => p.Price).Take(count);
    }

    public IEnumerable<Product> FindAllByQuantity(int quantity) => products.Where(p => p.Quantity == quantity);

    public IEnumerator<Product> GetEnumerator() => products.GetEnumerator();

    IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
}
