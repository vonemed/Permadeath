using System.Threading.Tasks;
using ConfigScripts;
using DefaultNamespace;
using DG.Tweening;
using Entitas.Unity;
using GameApp;
using Player;
using UnityEngine;

namespace UI
{
    public class CursedPanel : MonoBehaviour, IUIShowListener, IUIHideListener, ICursedPanelBoosterListener
    {
        private UIEntity _linkedEntity;
        public BoosterInfoCell booster;

        public ParticleSystem curseParticle;
        public void Ctor()
        {
            _linkedEntity = Contexts.sharedInstance.uI.CreateEntity();
            gameObject.Link(_linkedEntity);

            _linkedEntity.isCursedPanel = true;
            
            _linkedEntity.AddUIShowListener(this);
            _linkedEntity.AddUIHideListener(this);
            _linkedEntity.AddCursedPanelBoosterListener(this);
        }
        
        public void OnShow(UIEntity entity)
        {
            gameObject.SetActive(true);
        }

        public void OnHide(UIEntity entity)
        {
            gameObject.SetActive(false);
        }

        public void OnCursedPanelBooster(UIEntity entity, PlayerBooster value)
        {
            var boosterDatabase = ConfigsManager.Instance.boosterDatabase;
            var normalBooster = boosterDatabase.GetBoosterById(value.id);
            
            booster.AddCursedBoosterInfo(normalBooster.id, false);
            AnimTimer(normalBooster);
        }
        
        private async void AnimTimer(BoosterScriptable normalBooster)
        {
            var seconds = 0f;
            while (seconds < 1.5f)
            {
                seconds += Time.deltaTime;
                await Task.Yield();
            }
            
            booster.gameObject.transform.DOShakeScale(1f);
            curseParticle.Play();
            booster.AddCursedBoosterInfo(normalBooster.id, true);
            Contexts.sharedInstance.player.baseEntity.playerBoosterInventory.value
                .Find(x => x.id == normalBooster.id).cursed = true; //todo: refactor?
            
            Contexts.sharedInstance.player.baseEntity. //to trigger listener todo: refactor?
                ReplacePlayerBoosterInventory(Contexts.sharedInstance.player.baseEntity.playerBoosterInventory.value);
        }
    }
}