using Entitas.Unity;
using UnityEngine;

namespace UI
{
    public class DefeatPanel : MonoBehaviour, IShowListener, IHideListener
    {
        private UIEntity _linkedEntity;
        
        public void Ctor()
        {
            _linkedEntity = Contexts.sharedInstance.uI.CreateEntity();
            gameObject.Link(_linkedEntity);

            _linkedEntity.isDefeatPanel = true;
            
            _linkedEntity.AddShowListener(this);
            _linkedEntity.AddHideListener(this);
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