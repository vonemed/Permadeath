using System;
using UnityEngine;

[CreateAssetMenu(fileName = "PlayerConfig", menuName = "Configs/PlayerConfig")]
public class PlayerConfig : ScriptableObject
{
    [Serializable]
    public class PlayerStats
    {
        public float moveSpeed = 20f;
        public int health = 100;
        public int attackDamage = 5;
        public float attackRange = 5f;
        public float attackRate = 1f;

        public int critChance = 0;
        public float healthRegen = 0f;
        public int dodgeChance = 0;
        public int defence = 0;
        public float pickUpRange = 2f;
    }

    [Header("[Stats]")] public PlayerStats playerStats;
}
