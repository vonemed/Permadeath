using System;
using UnityEngine;

[CreateAssetMenu(fileName = "PlayerConfig", menuName = "Configs/PlayerConfig")]
public class PlayerConfig : ScriptableObject
{
    [Serializable]
    public class PlayerStats
    {
        public float moveSpeed = 20f;
        public float maxHealth = 100;
        public float currentHealth = 100;
        public float attackDamage = 5;
        public float attackRange = 5f;
        public float attackRate = 1f;

        public float critChance = 0;
        public float pureDamageChance = 0;
        public float healthRegen = 0f;
        public float dodgeChance = 0;
        public int defence = 0;
        public float pickUpRange = 2f;
        public int projectileAmount = 1;
        public float abilityCooldown = 15f;
        public float currentEXP;
    }



    [Header("[Stats]")] public PlayerStats playerStats;
}
