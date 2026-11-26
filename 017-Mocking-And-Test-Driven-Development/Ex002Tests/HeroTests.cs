using Ex002;
using Moq;

namespace Ex002Tests;

[TestFixture]
public class HeroTests
{
    private const int Experience = 20;

    [Test]
    public void HeroGainsExperienceWhenTargetDies()
    {
        var weapon = new Mock<IWeapon>();
        var target = new Mock<ITarget>();
        target.Setup(t => t.IsDead()).Returns(true);
        target.Setup(t => t.GiveExperience()).Returns(Experience);
        var hero = new Hero("Pesho", weapon.Object);

        hero.Attack(target.Object);

        Assert.That(hero.Experience, Is.EqualTo(Experience), "Hero didn't gain experience after killing the target.");
        weapon.Verify(w => w.Attack(target.Object), Times.Once);
    }

    [Test]
    public void HeroGainsNothingWhileTargetIsAlive()
    {
        var target = new Mock<ITarget>();
        target.Setup(t => t.IsDead()).Returns(false);
        var hero = new Hero("Pesho", Mock.Of<IWeapon>());

        hero.Attack(target.Object);

        Assert.That(hero.Experience, Is.Zero, "Hero gained experience from a living target.");
        target.Verify(t => t.GiveExperience(), Times.Never);
    }
}
