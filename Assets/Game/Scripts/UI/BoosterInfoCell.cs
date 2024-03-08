using Boosters;
using DefaultNamespace;
using DG.Tweening;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using Image = UnityEngine.UI.Image;

namespace UI
{
    public class BoosterInfoCell : MonoBehaviour, IPointerClickHandler, IPointerEnterHandler, IPointerExitHandler
    {
        [SerializeField] private TMP_Text boosterName;
        [SerializeField] private TMP_Text boosterDescription;
        [SerializeField] private Image boosterIcon;

        private int _boosterHash;
        private Vector3 _defaultScale;

        public void OnPointerClick(PointerEventData eventData)
        {
            Contexts.sharedInstance.booster.CreateEntity().ReplaceBoosterSelected(_boosterHash);
        }
        
        public void AddBoosterInfo(BoosterScriptable booster)
        {
            boosterName.SetText(booster.name);
            boosterDescription.SetText(booster.description);
            boosterIcon.sprite = booster.icon;

            _boosterHash = booster.id;
        }

        public void OnPointerEnter(PointerEventData eventData)
        {
            _defaultScale = boosterIcon.transform.localScale;
            boosterIcon.transform.DOScale(new Vector3(1.3f, 1.3f, 1.3f), 0.4f);
        }

        public void OnPointerExit(PointerEventData eventData)
        {
            DOTween.Clear();
            boosterIcon.transform.localScale = _defaultScale;
        }
    }
}