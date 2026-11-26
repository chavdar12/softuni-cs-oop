namespace Ex001;

public interface IProductStock : IEnumerable<Product>
{
    int Count { get; }

    Product this[int index] { get; }

    void Add(Product product);

    bool Contains(Product product);

    Product Find(int index);

    Product FindByLabel(string label);

    IEnumerable<Product> FindAllInPriceRange(decimal low, decimal high);

    IEnumerable<Product> FindAllByPrice(decimal price);

    IEnumerable<Product> FindMostExpensiveProducts(int count);

    IEnumerable<Product> FindAllByQuantity(int quantity);
}
