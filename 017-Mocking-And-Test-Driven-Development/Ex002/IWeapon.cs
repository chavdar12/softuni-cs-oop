namespace Ex002;

public interface IWeapon
{
    int AttackPoints { get; }

    int DurabilityPoints { get; }

    void Attack(ITarget target);
}
