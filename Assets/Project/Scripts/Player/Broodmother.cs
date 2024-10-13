using CharacterInfo;

public class Broodmother : Character
{
    private readonly VampirEffect _effectVampir;

    public Broodmother(int damage, int hp, int effectTime, VampirEffect vampirEffect) : base(damage, hp, effectTime, CharacterType.Broodmother)
    {
        _effectVampir = vampirEffect;
    }

    public override void ToAttack(Character opponent)
    {
        if (opponent.IsAlive)
        {
            int restoreHealth = (int)(opponent.Damage * 0.5f);
            RestoreHealth(restoreHealth);
            opponent.TakeDamage(Damage, _effectVampir.GetEffectType());
        }
    }
}
