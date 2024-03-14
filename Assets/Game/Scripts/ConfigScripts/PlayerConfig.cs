using System;
using System.Collections.Generic;
using Boosters;
using UnityEngine;

[CreateAssetMenu(fileName = "PlayerConfig", menuName = "Configs/PlayerConfig")]
public class PlayerConfig : ScriptableObject
{
    [Serializable]
    public class PlayerStats
    {
        public List<PlayerStat> playerStats = new List<PlayerStat>();

        public float GetStat(BoosterEnums.PlayerStatType statType)
        {
            return playerStats.Find(x => x.statType == statType).value;
        }
        
        public void SetStat(BoosterEnums.PlayerStatType statType, float value)
        {
            playerStats.Find(x => x.statType == statType).value = value;
        }
    }

    [Serializable]
    public sealed class PlayerStat
    {
        public BoosterEnums.PlayerStatType statType;
        public float value;
    }

    [Header("[Stats]")] public PlayerStats playerStats;
}
