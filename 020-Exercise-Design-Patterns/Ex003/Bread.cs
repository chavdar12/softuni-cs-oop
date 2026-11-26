namespace Ex003;

public abstract class Bread
{
    public abstract void MixIngredients();

    public abstract void Bake();

    public virtual void Slice()
    {
        Console.WriteLine($"Slicing the {GetType().Name} bread!");
    }

    // Template method: the steps are fixed, subclasses only fill them in.
    public void Make()
    {
        MixIngredients();
        Bake();
        Slice();
    }
}
