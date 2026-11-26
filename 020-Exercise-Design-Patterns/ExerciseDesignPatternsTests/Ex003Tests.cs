using Ex003;

namespace ExerciseDesignPatternsTests;

public class Ex003Tests
{
    [Test]
    public void ProgramMakesEveryBreadInTemplateOrder()
    {
        Assert.That(
            ConsoleRunner.Run(typeof(Bread).Assembly),
            Is.EqualTo(
                """
                Gathering Ingredients for 12-Grain Bread.
                Baking the 12-Grain Bread. (25 minutes)
                Slicing the TwelveGrain bread!

                Gathering Ingredients for Sourdough Bread.
                Baking the Sourdough Bread. (20 minutes)
                Slicing the Sourdough bread!

                Gathering Ingredients for Whole Wheat Bread.
                Baking the Whole Wheat Bread. (15 minutes)
                Slicing the WholeWheat bread!
                """
            )
        );
    }
}
