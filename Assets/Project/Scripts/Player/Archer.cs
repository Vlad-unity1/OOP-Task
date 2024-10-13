using CharacterInfo;
using PoisonedEffectSystem;

namespace CharactersArcher
{
    public class Archer : Character
    {
       private readonly PoisonedArrowsEffect _effectArrow;
        
        public Archer(int damage, int hp, int effectTime, PoisonedArrowsEffect effectArrow)
        : base(damage, hp, effectTime, CharacterType.Archer) 
        { 
            _effectArrow = effectArrow;
        }
   
        public override void ToAttack(Character opponent)
        {
            if(opponent.IsAlive)
            {
                opponent.TakeDamage(Damage, _effectArrow.GetEffectType());
                _effectArrow.PoisonedEffect(opponent, Damage * 2, EffectTime, 2);
            }
        }
    }
}
