using System;
using Entitas.Unity;
using UnityEngine;

namespace UI
{
    public class PausePanel : MonoBehaviour, IUIShowListener, IUIHideListener
    {
        private UIEntity _linkedEntity;
        private Canvas _canvas;
        public void Ctor()
        {
            _linkedEntity = Contexts.sharedInstance.uI.CreateEntity();
            gameObject.Link(_linkedEntity);

            _canvas = GetComponent<Canvas>();

            _linkedEntity.isPausePanel = true;
            
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
            Debug.Log("pause panel destroyed");
            gameObject.Unlink();
            _linkedEntity.Destroy();
        }
    }
}