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
                var booster = boosterEntity.boosterSelected.boosterStats;
                var player = Contexts.sharedInstance.player.baseEntity;
                player.playerBoosterInventory.value.Add(ConfigsManager.Instance.boosterConfig.GetBoosterByStats(booster));
                player.ReplacePlayerBoosterInventory(player.playerBoosterInventory.value); //just to trigger listener todo: redo?
                 
                switch (booster.statType)
                {
                    case(PlayerConfig.PlayerStatType.AttackSpeed):
                        var currentAttackSpeed = player.playerStats.value.attackRate;
                        var newAttackSpeed  =  (currentAttackSpeed / 100) * booster.percentageBuff;;
                        player.playerStats.value.attackRate = currentAttackSpeed - newAttackSpeed;
                        break;
                    
                    case(PlayerConfig.PlayerStatType.HealthRegen):
                        var currentHealthRegen = player.playerStats.value.healthRegen;
                        var newHealthRegen  =  (currentHealthRegen / 100) * booster.percentageBuff;;
                        player.playerStats.value.healthRegen = currentHealthRegen + newHealthRegen;
                        break;
                    
                    case(PlayerConfig.PlayerStatType.AttackDamage):
                        var currentDamage = player.playerStats.value.attackDamage;
                        var newDamage  =  (currentDamage / 100) * booster.percentageBuff;
                        player.playerStats.value.attackDamage = currentDamage + newDamage;
                        break;
                }
            }
        }
    }
}