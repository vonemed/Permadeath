using Entitas;
using Game;
using UnityEngine;

namespace CoreSystems
{
    public class KeyboardSystem : IExecuteSystem
    {
        public KeyboardSystem(Contexts contexts)
        {

        }
        public void Execute()
        {
            if (Input.GetKeyDown(KeyCode.Escape))
            {
                var currentState = Contexts.sharedInstance.game.stateHandlerEntity.currentState.value;

                if (currentState == GameCore.GameState.Pause)
                {
                    Contexts.sharedInstance.game.stateHandlerEntity.ReplaceCurrentState(GameCore.GameState.Play);
                    Contexts.sharedInstance.uI.pausePanelEntity.isHide = true;
                }
                else
                {
                    Contexts.sharedInstance.game.stateHandlerEntity.ReplaceCurrentState(GameCore.GameState.Pause);
                    Contexts.sharedInstance.uI.pausePanelEntity.isShow = true;
                }
            }
        }
    }
}