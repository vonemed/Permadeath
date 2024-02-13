using System;
using UnityEngine;

namespace Boosters
{
    [Serializable]
    public class Booster
    {
        public Sprite icon;
        public string name;
        public string description;
        public BoosterRarity boosterRarity;

        public BoosterStats boosterStats;
    }

    [Serializable]
    public class BoosterStats
    {
        public PlayerConfig.PlayerStatType statType;
        public float percentageBuff;
    }

    [Serializable]
    public enum BoosterRarity
    {
        Common,
        Uncommon,
        Rare,
        Legendary
    }
}