using System;
using System.Collections.Generic;
using DefaultNamespace;
using UnityEngine;

namespace Boosters
{
    [CreateAssetMenu(fileName = "New Booster Database", menuName = "Assets/Databases/Booster Database")]
    public class BoosterDatabase : ScriptableObject
    {
        [SerializeField] private Color commonColor;
        [SerializeField] private Color uncommonColor;
        [SerializeField] private Color rareColor;
        [SerializeField] private Color epicColor;
        [SerializeField] private Color ancientColor;

        public List<BoosterScriptable> boosters = new List<BoosterScriptable>();

        public BoosterScriptable GetBoosterById(int id)
        {
            List<BoosterScriptable> allBoosters = new List<BoosterScriptable>();
            allBoosters.AddRange(boosters);
            
            //Adding cursed variants to booster pool
            foreach (var booster in boosters)
            {
                if(booster.cursedVariant != null) allBoosters.Add(booster.cursedVariant);
            }
            
            return allBoosters.Find(x => x.id == id);
        }

        public List<BoosterScriptable> GetRandomBoosters(int amount)
        {
            if (amount <= 0)
            {
                Debug.LogWarning("Random booster request. Amount can't be 0 or less.");
                return null;
            }

            return boosters.GetRandomSubset(amount);
        }

        public Color GetRarityColor(BoosterEnums.BoosterRarity rarity)
        {
            var finalColor = rarity switch
            {
                BoosterEnums.BoosterRarity.Common => commonColor,
                BoosterEnums.BoosterRarity.Uncommon => uncommonColor,
                BoosterEnums.BoosterRarity.Rare => rareColor,
                BoosterEnums.BoosterRarity.Epic => epicColor,
                BoosterEnums.BoosterRarity.Ancient => ancientColor,  
                _ => throw new NotImplementedException($"Can't find rarity color!")
            };

            return finalColor;
        }
    }
}