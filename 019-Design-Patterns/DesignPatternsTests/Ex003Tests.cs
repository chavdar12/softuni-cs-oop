using Ex003;

namespace DesignPatternsTests;

public class Ex003Tests
{
    [Test]
    public void InvokerStoresExecutedCommands()
    {
        var modifyPrice = new ModifyPrice();
        modifyPrice.SetCommand(new ProductCommand(new Product("Tablet", 100), PriceAction.Decrease, 200));
        modifyPrice.Invoke();

        Assert.That(modifyPrice.Commands, Has.Count.EqualTo(1));
    }

    [Test]
    public void ProgramModifiesPrice()
    {
        Assert.That(
            ConsoleRunner.Run(typeof(Product).Assembly),
            Is.EqualTo(
                """
                The price for the Phone has been increased by 100$.
                The price for the Phone has been increased by 50$.
                The price for the Phone has been decreased by 25$.
                Current price for the Phone product is 625$.
                """
            )
        );
    }
}
