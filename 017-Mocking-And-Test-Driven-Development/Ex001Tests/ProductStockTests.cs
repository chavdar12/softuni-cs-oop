using Ex001;

namespace Ex001Tests;

[TestFixture]
public class ProductStockTests
{
    [SetUp]
    public void Setup()
    {
        stock = new ProductStock();
        milk = new Product("Milk", 2.50m, 10);
        bread = new Product("Bread", 1.20m, 0);
        cheese = new Product("Cheese", 8.90m, 10);
        butter = new Product("Butter", 2.50m, 3);
        foreach (var product in new[] { milk, bread, cheese, butter })
            stock.Add(product);
    }

    private ProductStock stock;
    private Product milk;
    private Product bread;
    private Product cheese;
    private Product butter;

    [Test]
    public void AddIncreasesCount()
    {
        Assert.That(stock.Count, Is.EqualTo(4));
    }

    [Test]
    public void AddThrowsForDuplicateLabel()
    {
        Assert.Throws<ArgumentException>(() => stock.Add(new Product("Milk", 1, 1)));
    }

    [Test]
    public void ContainsMatchesByLabelOnly()
    {
        Assert.That(stock.Contains(new Product("Milk", 99, 99)), Is.True);
        Assert.That(stock.Contains(new Product("Eggs", 2.50m, 10)), Is.False);
    }

    [Test]
    public void FindReturnsProductsInInsertionOrder()
    {
        Assert.That(stock.Find(0), Is.SameAs(milk));
        Assert.That(stock[2], Is.SameAs(cheese));
    }

    [TestCase(-1)]
    [TestCase(4)]
    public void FindThrowsForMissingIndex(int index)
    {
        Assert.Throws<IndexOutOfRangeException>(() => stock.Find(index));
    }

    [Test]
    public void FindByLabelReturnsProduct()
    {
        Assert.That(stock.FindByLabel("Bread"), Is.SameAs(bread));
    }

    [Test]
    public void FindByLabelThrowsWhenMissing()
    {
        Assert.Throws<ArgumentException>(() => stock.FindByLabel("Eggs"));
    }

    [Test]
    public void FindAllInPriceRangeIsInclusiveAndDescending()
    {
        Assert.That(stock.FindAllInPriceRange(1.20m, 2.50m), Is.EqualTo(new[] { milk, butter, bread }));
    }

    [Test]
    public void FindAllInPriceRangeReturnsEmptyWhenNothingMatches()
    {
        Assert.That(stock.FindAllInPriceRange(100, 200), Is.Empty);
    }

    [Test]
    public void FindAllByPriceReturnsMatches()
    {
        Assert.That(stock.FindAllByPrice(2.50m), Is.EqualTo(new[] { milk, butter }));
        Assert.That(stock.FindAllByPrice(3), Is.Empty);
    }

    [Test]
    public void FindMostExpensiveProductsReturnsTopByPrice()
    {
        Assert.That(stock.FindMostExpensiveProducts(2), Is.EqualTo(new[] { cheese, milk }));
    }

    [Test]
    public void FindMostExpensiveProductsThrowsWhenCountExceedsStock()
    {
        Assert.Throws<ArgumentException>(() => stock.FindMostExpensiveProducts(5));
    }

    [Test]
    public void FindAllByQuantityReturnsMatches()
    {
        Assert.That(stock.FindAllByQuantity(10), Is.EqualTo(new[] { milk, cheese }));
        Assert.That(stock.FindAllByQuantity(7), Is.Empty);
    }

    [Test]
    public void EnumeratesAllProducts()
    {
        Assert.That(stock, Is.EqualTo(new[] { milk, bread, cheese, butter }));
    }
}
