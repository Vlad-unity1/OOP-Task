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
                var wizard = characterObject.GetComponent<DebuffEffect>() ?? characterObject.AddComponent<DebuffEffect>();
                return new CharacterWizard.Wizard(data.Damage, data.Health, data.EffectTime, wizard);

            case CharacterType.Warrior:
                var warrior = characterObject.GetComponent<StuntEffect>() ?? characterObject.AddComponent<StuntEffect>();
                return new CharacterWarrior.Warrior(data.Damage, data.Health, data.EffectTime, warrior);

            case CharacterType.Archer:
                var archer = characterObject.GetComponent<PoisonedArrowsEffect>() ?? characterObject.AddComponent<PoisonedArrowsEffect>();
                return new Archer(data.Damage, data.Health, data.EffectTime, archer);

            case CharacterType.Broodmother:
                var broodmother = characterObject.GetComponent<VampirEffect>() ?? characterObject.AddComponent<VampirEffect>();
                return new Broodmother(data.Damage, data.Health, data.EffectTime, broodmother);

            default:
                return null;
        }
    }
}
