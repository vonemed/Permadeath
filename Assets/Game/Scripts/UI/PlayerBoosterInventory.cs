using System.Collections.Generic;
using ConfigScripts;
using Player;
using UnityEngine;

namespace UI
{
    public class PlayerBoosterInventory : MonoBehaviour, IAnyPlayerBoosterInventoryListener
    {
        [SerializeField] private List<PlayerBoosterInventoryCell> boosters = new List<PlayerBoosterInventoryCell>();

        private PlayerEntity _linkedEntity;
    
        public void Ctor()
        {
            _linkedEntity = Contexts.sharedInstance.player.CreateEntity();
            _linkedEntity.AddAnyPlayerBoosterInventoryListener(this);
        }

        public void OnAnyPlayerBoosterInventory(PlayerEntity entity, List<int> value)
        {
            List<int> ignoreList = new List<int>();
        
            for (var i = 0; i < value.Count; i++)
            {
                var booster = value[i];
                if(ignoreList.Contains(booster)) continue;
                
                var duplicates = value.FindAll(t => t == booster);
                ignoreList.AddRange(duplicates);

                var actualBooster = ConfigsManager.Instance.boosterDatabase.GetBoosterById(booster);
                
                if (duplicates.Count > 1)
                {
                    boosters[i].SetBoosterInfo(actualBooster.icon, duplicates.Count);
                    boosters[i].gameObject.SetActive(true);
                    continue;
                }
                
                boosters[i].SetBoosterInfo(actualBooster.icon, 1);
                boosters[i].gameObject.SetActive(true);
            }
        }

        public void OnAnyPlayerBoosterInventory(PlayerEntity entity, List<BoosterInfo> value)
        {
            for (var i = 0; i < value.Count; i++)
            {
                // boosters[i].SetBoosterInfo(value[i].booster, (int)value[i].amount);
                boosters[i].gameObject.SetActive(true);
            }
        }
    }
}