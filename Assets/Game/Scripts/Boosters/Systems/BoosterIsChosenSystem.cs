using System.Collections.Generic;
using Entitas;
using Game;
using Player;

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
                var player = Contexts.sharedInstance.player.baseEntity;
                
                //Adding booster to player inventory
                if (!player.playerBoosterInventory.value.Exists(x => x.id == boosterId))
                {
                    //new booster
                    player.playerBoosterInventory.value.Add(new PlayerBooster()
                    {
                        cursed = false,
                        id = boosterId,
                        level = 1
                    });
                }
                else
                {
                    player.playerBoosterInventory.value.Find(x => x.id == boosterId).level++;
                }

                player.ReplacePlayerBoosterInventory(player.playerBoosterInventory.value); //just to trigger listener todo: redo?
            }
        }
    }
}