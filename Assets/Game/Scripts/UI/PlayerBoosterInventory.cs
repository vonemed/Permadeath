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

        public void OnAnyPlayerBoosterInventory(PlayerEntity entity, List<PlayerBooster> value)
        {
            for (var i = 0; i < value.Count; i++)
            {
                var booster = value[i];
                var actualBooster = ConfigsManager.Instance.boosterDatabase.GetBoosterById(booster.id);
                if(booster.cursed) boosters[i].SetBoosterInfo(actualBooster.cursedVariant.icon, booster.level);
                else boosters[i].SetBoosterInfo(actualBooster.icon, booster.level);

                boosters[i].gameObject.SetActive(true);
            }
        }
    }
}