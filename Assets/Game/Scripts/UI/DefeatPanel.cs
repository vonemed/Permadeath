using Entitas.Unity;
using TMPro;
using UnityEngine;

namespace UI
{
    public class DefeatPanel : MonoBehaviour, IUIShowListener, IUIHideListener
    {
        private UIEntity _linkedEntity;
        private Canvas _canvas;

        
        [SerializeField] private TMP_Text title;
        public void Ctor()
        {
            _linkedEntity = Contexts.sharedInstance.uI.CreateEntity();
            gameObject.Link(_linkedEntity);

            _linkedEntity.isDefeatPanel = true;
            _canvas = GetComponent<Canvas>();

            _linkedEntity.AddUIShowListener(this);
            _linkedEntity.AddUIHideListener(this);
        }

        public void OnShow(UIEntity entity)
        {
            _canvas.enabled = true;

        }

        public void OnHide(UIEntity entity)
        {
            _canvas.enabled = false;
        }
        
        private void OnDestroy()
        {
            gameObject.Unlink();
            _linkedEntity.Destroy();
        }
    }
}