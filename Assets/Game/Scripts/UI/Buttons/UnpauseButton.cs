using Game;
using UnityEngine;
using UnityEngine.EventSystems;

namespace UI.Buttons
{
    public class UnpauseButton : MonoBehaviour, IPointerClickHandler
    {
        public void OnPointerClick(PointerEventData eventData)
        {
            Contexts.sharedInstance.uI.cursedPanelEntity.isHide = true;
            Contexts.sharedInstance.game.stateHandlerEntity.ReplaceCurrentState(GameCore.GameState.Play);
            Contexts.sharedInstance.enemy.CreateEntity().ReplaceFreezeAllEnemies(5f);
        }
    }
}