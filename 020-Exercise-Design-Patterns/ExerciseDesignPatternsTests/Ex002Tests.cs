using Ex002;

namespace ExerciseDesignPatternsTests;

public class Ex002Tests
{
    [Test]
    public void RemovedGiftIsNotCounted()
    {
        var box = new CompositeGift("Box", 5);
        var toy = new SingleGift("Toy", 10);
        box.Add(toy);
        box.Add(new SingleGift("Ball", 3));
        box.Remove(toy);

        Assert.That(box.CalculateTotalPrice(), Is.EqualTo(8));
    }

    [Test]
    public void ProgramSumsNestedGifts()
    {
        Assert.That(
            ConsoleRunner.Run(typeof(GiftBase).Assembly),
            Is.EqualTo(
                """
                Phone with the price 256

                RootBox contains the following products with prices:
                TruckToy with the price 289
                PlainToy with the price 587
                ChildBox contains the following products with prices:
                SoldierToy with the price 200
                Total price of this composite present is: 1076
                """
            )
        );
    }
}
