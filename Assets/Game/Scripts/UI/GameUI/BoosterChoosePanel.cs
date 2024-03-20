using System.Collections.Generic;
using ConfigScripts;
using Entitas.Unity;
using UnityEngine;

namespace UI
{
    public class BoosterChoosePanel : MonoBehaviour, IGameUIShowListener, IGameUIHideListener
    {
        private GameUIEntity _linkedEntity;
        [SerializeField] private List<BoosterInfoCell> boosterCells = new List<BoosterInfoCell>();
        private Canvas _canvas;

        public void Ctor()
        {
            _linkedEntity = Contexts.sharedInstance.gameUI.CreateEntity();
            gameObject.Link(_linkedEntity);

            _linkedEntity.isBoosterChoosePanel = true;
            _canvas = GetComponent<Canvas>();

            _linkedEntity.AddGameUIShowListener(this);
            _linkedEntity.AddGameUIHideListener(this);
        }

        private void OnDestroy()
        {
            Debug.Log("booster destroyed");
            gameObject.Unlink();
            _linkedEntity.Destroy();
        }

        public void OnShow(GameUIEntity entity)
        {
            BoosterCellReset();
            var randBoosters = ConfigsManager.Instance.boosterDatabase.GetRandomBoosters(3);

            for (int i = 0; i < randBoosters.Count; i++)
            {
                boosterCells[i].AddBoosterInfo(randBoosters[i].id);
            }
            
            // randBoosters.Clear();
            _canvas.enabled = true;

        }

        private void BoosterCellReset()
        {
            foreach (var boosterCell in boosterCells)
            {
                boosterCell.gameObject.SetActive(false);
            }
        }

        public void OnHide(GameUIEntity entity)
        {
            _canvas.enabled = false;

        }
    }
}