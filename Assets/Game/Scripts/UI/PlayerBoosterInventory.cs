using System.Collections.Generic;
using Boosters;
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

        public void OnAnyPlayerBoosterInventory(PlayerEntity entity, List<Booster> value)
        {
            List<Booster> ignoreList = new List<Booster>();

            for (var i = 0; i < value.Count; i++)
            {
                var booster = value[i];
                if(ignoreList.Contains(booster)) continue;
                
                var duplicates = value.FindAll(t => t.boosterStats == booster.boosterStats);
                ignoreList.AddRange(duplicates);
                
                if (duplicates.Count > 1)
                {
                    boosters[i].SetBoosterInfo(booster, duplicates.Count);
                    boosters[i].gameObject.SetActive(true);
                    continue;
                }
                
                boosters[i].SetBoosterInfo(booster, 1);
                boosters[i].gameObject.SetActive(true);
            }
        }
    }
}