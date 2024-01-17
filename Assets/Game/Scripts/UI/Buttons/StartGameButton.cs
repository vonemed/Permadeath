using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

namespace UI.Buttons
{
    public class StartGameButton : MonoBehaviour, IPointerClickHandler
    {
        public void OnPointerClick(PointerEventData eventData)
        {
            //temp trash todo: make a proper ui handler
            GameObject.Find("Canvas").SetActive(false);
            
            SceneManager.LoadSceneAsync(1, LoadSceneMode.Additive);
        }
    }
}