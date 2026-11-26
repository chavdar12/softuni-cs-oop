using Ex003;

var modifyPrice = new ModifyPrice();
var product = new Product("Phone", 500);

Execute(new ProductCommand(product, PriceAction.Increase, 100));
Execute(new ProductCommand(product, PriceAction.Increase, 50));
Execute(new ProductCommand(product, PriceAction.Decrease, 25));

Console.WriteLine(product);

void Execute(ICommand command)
{
    modifyPrice.SetCommand(command);
    modifyPrice.Invoke();
}
