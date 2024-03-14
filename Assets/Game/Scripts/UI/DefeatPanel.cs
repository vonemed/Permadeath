using Entitas.Unity;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace UI
{
    public class DefeatPanel : MonoBehaviour, IUIShowListener, IUIHideListener
    {
        private UIEntity _linkedEntity;

        [SerializeField] private Button restartButton;
        [SerializeField] private Button exitButton;
        [SerializeField] private TMP_Text title;
        public void Ctor()
        {
            _linkedEntity = Contexts.sharedInstance.uI.CreateEntity();
            gameObject.Link(_linkedEntity);

            _linkedEntity.isDefeatPanel = true;
            
            _linkedEntity.AddUIShowListener(this);
            _linkedEntity.AddUIHideListener(this);
        }

        public void OnShow(UIEntity entity)
        {
            gameObject.SetActive(true);
            var player = Contexts.sharedInstance.player.baseEntity;

            if (player.isPermaDeath)
            {
                title.SetText($"Permadeath");
                restartButton.gameObject.SetActive(true);
                exitButton.gameObject.SetActive(true);
            }
            else
            {
                restartButton.gameObject.SetActive(false);
                exitButton.gameObject.SetActive(false);
                
                title.SetText($"Death");
            }
        }

        public void OnHide(UIEntity entity)
        {
            gameObject.SetActive(false);
        }
    }
}