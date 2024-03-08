using DefaultNamespace;
using UnityEngine;

namespace Boosters
{
    [CreateAssetMenu(fileName = "New Attack Booster", menuName = "Assets/Attack Booster")]
    public class AttackBoosterScriptable : BoosterScriptable
    {
        public BoosterEnums.DamageType damageTypeTrigger;
        public float chance;
        public BoosterEnums.AttackModifier attackModifier;
        public float duration;
    }
}