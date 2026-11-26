namespace Ex002;

public interface ITarget
{
    int Health { get; }

    void TakeAttack(int attackPoints);

    int GiveExperience();

    bool IsDead();
}
