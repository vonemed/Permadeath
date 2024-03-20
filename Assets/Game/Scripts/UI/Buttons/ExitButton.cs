using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

namespace UI.Buttons
{
    public class ExitButton : MonoBehaviour, IPointerClickHandler
    {
        public void OnPointerClick(PointerEventData eventData)
        {
            Contexts.sharedInstance.uI.mainMenuPanelEntity.isShow = true;
            SceneManager.UnloadSceneAsync(1).completed += operation =>
            {
                Contexts.sharedInstance.player.DestroyAllEntities();
                Contexts.sharedInstance.enemy.DestroyAllEntities();
                Contexts.sharedInstance.objectPooler.DestroyAllEntities();
                Contexts.sharedInstance.loot.DestroyAllEntities();
            };
        }
    }
}