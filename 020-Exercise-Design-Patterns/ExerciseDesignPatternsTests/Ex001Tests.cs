using Ex001;

namespace ExerciseDesignPatternsTests;

public class Ex001Tests
{
    [Test]
    public void CloneIsANewSandwichWithTheSameIngredients()
    {
        var original = new Sandwich("Rye", "Ham", "Swiss", "Lettuce");
        var clone = (Sandwich)original.Clone();

        Assert.That(clone, Is.Not.SameAs(original));
        Assert.That(clone.Meat, Is.EqualTo(original.Meat));
    }

    [Test]
    public void ProgramClonesThreeSandwiches()
    {
        Assert.That(
            ConsoleRunner.Run(typeof(Sandwich).Assembly),
            Is.EqualTo(
                """
                Cloning sandwich with ingredients: Wheat, Bacon, Lettuce, Tomato
                Cloning sandwich with ingredients: Rye, Turkey, Ham, Salami, Provolone, Lettuce, Onion
                Cloning sandwich with ingredients: Wheat, Lettuce, Onion, Tomato, Olives, Spinach
                """
            )
        );
    }
}
