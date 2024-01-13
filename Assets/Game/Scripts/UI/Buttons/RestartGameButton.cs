using Game;
using UnityEngine;
using UnityEngine.EventSystems;

namespace UI.Buttons
{
    public class RestartGameButton : MonoBehaviour, IPointerClickHandler
    {
        public void OnPointerClick(PointerEventData eventData)
        {
            Contexts.sharedInstance.game.stateHandlerEntity.ReplaceCurrentState(GameCore.GameState.Restart);
        }
    }
}