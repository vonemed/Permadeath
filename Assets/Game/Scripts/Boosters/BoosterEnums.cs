using System;

namespace Boosters
{
    public class BoosterEnums
    {
        [Serializable]
        public enum BoosterRarity
        {
            Common,
            Uncommon,
            Rare,
            Epic,
            Ancient
        }

        [Serializable]
        public enum BoosterType
        {
            StatBooster,
            AttackBooster
        }

        public enum PlayerStatType
        {
            MoveSpeed,
            MaxHealth,
            AttackDamage,
            AttackRange,
            AttackSpeed,
            CritChance,
            PureDamageChance,
            HealthRegen,
            DodgeChance,
            Defence,
            PickupRange,
            ProjectileAmount,
            AbilityCooldown
        }

        public enum DamageType
        {
            Normal,
            True,
            Crit
        }

        public enum AttackModifier
        {
            None,
            SelfStatus,
            EnemyStatus,
            AreaDamage,
            ExtraDamage
        }
    }
}