using System.Collections.Generic;
using ConfigScripts;
using Entitas;
using Game;

namespace Boosters.Systems
{
    public class BoosterIsChosenSystem : ReactiveSystem<BoosterEntity>
    {
        public BoosterIsChosenSystem(IContext<BoosterEntity> context) : base(context)
        {
        }

        protected override ICollector<BoosterEntity> GetTrigger(IContext<BoosterEntity> context)
        {
            return context.CreateCollector(BoosterMatcher.BoosterSelected);
        }

        protected override bool Filter(BoosterEntity entity)
        {
            return true;
        }

        protected override void Execute(List<BoosterEntity> entities)
        {
            Contexts.sharedInstance.uI.boosterChoosePanelEntity.isHide = true;
            Contexts.sharedInstance.game.stateHandlerEntity.ReplaceCurrentState(GameCore.GameState.Play);

            foreach (var boosterEntity in entities)
            {
                var boosterId = boosterEntity.boosterSelected.boosterHash;
                var booster = ConfigsManager.Instance.boosterDatabase.GetBoosterById(boosterId);
                var player = Contexts.sharedInstance.player.baseEntity;

                if (booster.boosterType == BoosterEnums.BoosterType.StatBooster)
                {
                    var statBooster = (StatBoosterScriptable)booster;
                    StatBoosterHandler(statBooster);
                }

                player.playerBoosterInventory.value.Add(boosterId);
                player.ReplacePlayerBoosterInventory(player.playerBoosterInventory.value); //just to trigger listener todo: redo?
            }
        }

        private int GetBoosterLevel(int boosterId)
        {
            return Contexts.sharedInstance.player.baseEntity.playerBoosterInventory.value.FindAll(x => x == boosterId).Count;
        }
        
        private void StatBoosterHandler(StatBoosterScriptable statBooster)
        {
            var player = Contexts.sharedInstance.player.baseEntity;
            var boosterLevel = GetBoosterLevel(statBooster.id);
            
            switch (statBooster.stat)
            {
                case(BoosterEnums.PlayerStatType.AttackSpeed):
                    var currentAttackSpeed = player.playerStats.value.attackRate;
                    
                    var newAttackSpeed  =  (currentAttackSpeed / 100) * statBooster.values[boosterLevel];
                    player.playerStats.value.attackRate = currentAttackSpeed - newAttackSpeed;
                    break;
                
                case(BoosterEnums.PlayerStatType.HealthRegen):
                    var currentHealthRegen = player.playerStats.value.healthRegen;
                    if (currentHealthRegen == 0) player.playerStats.value.healthRegen = statBooster.values[boosterLevel];
                    else
                    {
                        var newHealthRegen  =  (currentHealthRegen / 100) * statBooster.values[boosterLevel];
                        player.playerStats.value.healthRegen = currentHealthRegen + newHealthRegen;
                    }
            
                    break;
                
                case(BoosterEnums.PlayerStatType.AttackDamage):
                    var currentDamage = player.playerStats.value.attackDamage;
                    var newDamage  =  (currentDamage / 100) * statBooster.values[boosterLevel];
                    player.playerStats.value.attackDamage = currentDamage + newDamage;
                    break;
            }
        }
    }
}