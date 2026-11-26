using Ex002;

namespace DesignPatternsTests;

public class Ex002Tests
{
    [Test]
    public void BuildersFillTheSameCar()
    {
        var car = new CarBuilderFacade().Info.WithType("Audi").Built.InCity("Sofia").Build();

        Assert.That(car.Type, Is.EqualTo("Audi"));
        Assert.That(car.City, Is.EqualTo("Sofia"));
    }

    [Test]
    public void ProgramBuildsCar()
    {
        Assert.That(
            ConsoleRunner.Run(typeof(Car).Assembly),
            Is.EqualTo(
                "CarType: BMW, Color: Black, Number of doors: 5, Manufactured in Leipzig, at address: Some address 254"
            )
        );
    }
}
