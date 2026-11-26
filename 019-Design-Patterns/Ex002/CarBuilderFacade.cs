namespace Ex002;

public class CarBuilderFacade
{
    public CarBuilderFacade()
    {
        Car = new Car();
    }

    protected Car Car { get; set; }

    public CarInfoBuilder Info => new(Car);

    public CarAddressBuilder Built => new(Car);

    public Car Build() => Car;
}
