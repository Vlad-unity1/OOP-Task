using CharacterInfo;
using CharactersArcher;
using DebuffEffectSystem;
using PoisonedEffectSystem;
using StuntEffectSystem;
using UnityEngine;

public class FactorySpawner : MonoBehaviour
{
    public Character CreateCharacterInstance(CharacterDataObject data, GameObject characterObject)
    {
        switch (data.Type)
        {
            case CharacterType.Wizard:
                var wizard = characterObject.AddComponent<DebuffEffect>();
                return new CharacterWizard.Wizard(data.Damage, data.Health, data.EffectTime, wizard);

            case CharacterType.Warrior:
                var warrior = characterObject.AddComponent<StuntEffect>();
                return new CharacterWarrior.Warrior(data.Damage, data.Health, data.EffectTime, warrior);

            case CharacterType.Archer:
                var archer = characterObject.AddComponent<PoisonedArrowsEffect>();
                return new Archer(data.Damage, data.Health, data.EffectTime, archer);

            default:
                return null;
        }
    }
}
