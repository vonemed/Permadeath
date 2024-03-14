using System.Collections.Generic;
using Boosters;
using ConfigScripts;
using Entitas;
using GameApp;
using UnityEngine;

namespace Player.Systems
{
    public class PlayerInventoryUpdateSystem : ReactiveSystem<PlayerEntity>
    {
        public PlayerInventoryUpdateSystem(IContext<PlayerEntity> context) : base(context)
        {
        }

        protected override ICollector<PlayerEntity> GetTrigger(IContext<PlayerEntity> context)
        {
            return context.CreateCollector(PlayerMatcher.PlayerBoosterInventory);
        }

        protected override bool Filter(PlayerEntity entity)
        {
            return true;
        }

        protected override void Execute(List<PlayerEntity> entities)
        {
            //Go through every item in inventory and recalculate values
            foreach (var playerInventory in entities)
            {
                foreach (var playerBooster in playerInventory.playerBoosterInventory.value)
                {
                    var actualBooster = ConfigsManager.Instance.boosterDatabase.GetBoosterById(playerBooster.id);
                    if(actualBooster.boosterType == BoosterEnums.BoosterType.StatBooster) 
                        StatBoosterHandler((StatBoosterScriptable)actualBooster, playerBooster.cursed);
                }
            }
        }

        private void StatBoosterHandler(StatBoosterScriptable statBooster, bool cursed)
        {
            var player = Contexts.sharedInstance.player.baseEntity;
            var boosterLevel = GameTools.GetBoosterLevel(statBooster.id);
            var defaultValue = ConfigsManager.Instance.playerConfig.playerStats.GetStat(statBooster.stat);
            var statValue = statBooster.values[boosterLevel - 1];
            
            Debug.Log($"Booster:{statBooster.name}");
            Debug.Log($"Booster level:{boosterLevel}");
            Debug.Log($"Booster default value:{defaultValue}");
            Debug.Log($"Booster % buff value:{statValue}%");

            if (cursed && statBooster.cursedVariant.boosterType == BoosterEnums.BoosterType.StatBooster)
            {
                Debug.Log($"CURSED BOOSTER");

                var cursedBooster = (StatBoosterScriptable)statBooster.cursedVariant;
                statValue -= cursedBooster.values[boosterLevel - 1];
                
                Debug.Log($"Cursed % buff value:{cursedBooster.values[boosterLevel - 1]}%");
                Debug.Log($"FINAL % buff value:{statValue}%");
            }
            
            switch (statBooster.stat)
            {
                case(BoosterEnums.PlayerStatType.AttackSpeed):
                    
                    var newAttackSpeed  =  (defaultValue / 100) * statValue;
                    var finalAttackSpeed = defaultValue - newAttackSpeed;
                    player.playerStats.value.SetStat(statBooster.stat,finalAttackSpeed);
                    break;
                
                case(BoosterEnums.PlayerStatType.HealthRegen):

                    if (defaultValue == 0) player.playerStats.value.SetStat(statBooster.stat,statValue);
                    else
                    {
                        var newHealthRegen  =  (defaultValue / 100) * statValue;
                        var finalHealthRegen = defaultValue + newHealthRegen;
                        player.playerStats.value.SetStat(statBooster.stat, finalHealthRegen);
                    }
            
                    break;
                
                case(BoosterEnums.PlayerStatType.AttackDamage):
                    var newDamage  =  Mathf.Clamp((defaultValue / 100) * statValue, 0, int.MaxValue);
                    if(newDamage == 0) Debug.Log("Something wrong, damage buff is 0 !!!");
                    var finalDamage = defaultValue + newDamage;
                    player.playerStats.value.SetStat(statBooster.stat, finalDamage);
                    break;
            }
        }
    }
}