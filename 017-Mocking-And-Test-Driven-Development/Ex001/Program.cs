using Ex001;

var stock = new ProductStock();
stock.Add(new Product("Milk", 2.50m, 10));
stock.Add(new Product("Bread", 1.20m, 0));
stock.Add(new Product("Cheese", 8.90m, 4));

foreach (var product in stock.FindAllInPriceRange(1, 5))
    Console.WriteLine($"{product.Label} - {product.Price}");
