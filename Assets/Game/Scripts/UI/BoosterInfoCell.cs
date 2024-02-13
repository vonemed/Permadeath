using Boosters;
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

        private BoosterStats _boosterStats;
        private Vector3 _defaultScale;

        public void OnPointerClick(PointerEventData eventData)
        {
            Contexts.sharedInstance.booster.CreateEntity().ReplaceBoosterSelected(_boosterStats);
        }
        
        public void AddBoosterInfo(Booster booster)
        {
            boosterName.SetText(booster.name);
            boosterDescription.SetText(booster.description);
            boosterIcon.sprite = booster.icon;

            _boosterStats = booster.boosterStats;
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