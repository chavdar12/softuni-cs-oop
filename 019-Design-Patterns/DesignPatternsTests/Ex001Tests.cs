using Ex001;

namespace DesignPatternsTests;

public class Ex001Tests
{
    [Test]
    public void InstanceIsShared()
    {
        Assert.That(SingletonDataContainer.Instance, Is.SameAs(SingletonDataContainer.Instance));
    }

    [Test]
    public void ConstructorIsHidden()
    {
        Assert.That(typeof(SingletonDataContainer).GetConstructors(), Is.Empty);
    }

    [Test]
    public void ProgramPrintsPopulationsFromFile()
    {
        // The singleton may already exist from another test, so only the populations are checked.
        Assert.That(ConsoleRunner.Run(typeof(SingletonDataContainer).Assembly), Does.EndWith("37400068\n21581000"));
    }
}
