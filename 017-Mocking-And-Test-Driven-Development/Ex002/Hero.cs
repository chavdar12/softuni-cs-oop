namespace Ex002;

public class Hero
{
    public Hero(string name, IWeapon weapon)
    {
        Name = name;
        Weapon = weapon;
    }

    public string Name { get; }

    public int Experience { get; private set; }

    public IWeapon Weapon { get; }

    public void Attack(ITarget target)
    {
        Weapon.Attack(target);

        if (target.IsDead())
            Experience += target.GiveExperience();
    }
}
