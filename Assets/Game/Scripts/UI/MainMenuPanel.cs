using Entitas.Unity;
using TMPro;
using UnityEngine;

namespace UI
{
    public class MainMenuPanel : MonoBehaviour, IUIShowListener, IUIHideListener
    {
        private UIEntity _linkedEntity;
        
        public void Ctor()
        {
            _linkedEntity = Contexts.sharedInstance.uI.CreateEntity();
            gameObject.Link(_linkedEntity);

            _linkedEntity.isMainMenuPanel = true;
            
            _linkedEntity.AddUIShowListener(this);
            _linkedEntity.AddUIHideListener(this);
        }

        public void OnShow(UIEntity entity)
        {
            gameObject.SetActive(true);
        }

        public void OnHide(UIEntity entity)
        {
            gameObject.SetActive(false);
        }
    }
}