using System.Collections.Generic;
using Boosters;
using ConfigScripts;
using Entitas.Unity;
using GameApp;
using UnityEngine;

namespace UI
{
    public class BoosterChoosePanel : MonoBehaviour, IUIShowListener, IUIHideListener
    {
        private UIEntity _linkedEntity;
        [SerializeField] private List<BoosterInfoCell> boosterCells = new List<BoosterInfoCell>();

        public void Ctor()
        {
            _linkedEntity = Contexts.sharedInstance.uI.CreateEntity();
            gameObject.Link(_linkedEntity);

            _linkedEntity.isBoosterChoosePanel = true;
            
            _linkedEntity.AddUIShowListener(this);
            _linkedEntity.AddUIHideListener(this);
        }

        public void OnShow(UIEntity entity)
        {
            var randBoosters = ConfigsManager.Instance.boosterDatabase.GetRandomBoosters(3);

            for (int i = 0; i < randBoosters.Count; i++)
            {
                boosterCells[i].AddBoosterInfo(randBoosters[i].id);
            }
            
            // randBoosters.Clear();
            gameObject.SetActive(true);
        }

        public void OnHide(UIEntity entity)
        {
            gameObject.SetActive(false);
        }
    }
}