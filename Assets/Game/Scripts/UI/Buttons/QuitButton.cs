using UnityEngine;
using UnityEngine.EventSystems;

namespace UI.Buttons
{
    public class QuitButton : MonoBehaviour, IPointerClickHandler
    {
        public void OnPointerClick(PointerEventData eventData)
        {
            Application.Quit();
            
        }
    }
}