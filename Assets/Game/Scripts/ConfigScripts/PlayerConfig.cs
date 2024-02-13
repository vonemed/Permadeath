using System;
using UnityEngine;

[CreateAssetMenu(fileName = "PlayerConfig", menuName = "Configs/PlayerConfig")]
public class PlayerConfig : ScriptableObject
{
    [Serializable]
    public class PlayerStats
    {
        public float moveSpeed = 20f;
        public float health = 100;
        public float attackDamage = 5;
        public float attackRange = 5f;
        public float attackRate = 1f;

        public uint critChance = 0;
        public float healthRegen = 0f;
        public uint dodgeChance = 0;
        public int defence = 0;
        public float pickUpRange = 2f;
    }

    public enum PlayerStatType
    {
        MoveSpeed,
        Health,
        AttackDamage,
        AttackRange,
        AttackSpeed,
        CritChance,
        HealthRegen,
        DodgeChance,
        Defence,
        PickupRange
    }

    [Header("[Stats]")] public PlayerStats playerStats;
}
