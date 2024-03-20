using System.Globalization;
using Boosters;
using ConfigScripts;
using DefaultNamespace;
using DG.Tweening;
using GameApp;
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
        [SerializeField] private TMP_Text boosterValues;
        [SerializeField] private TMP_Text cursedBoosterValues;
        [SerializeField] private Image boosterIcon;
        [SerializeField] private Image rarityBackground;

        private int _boosterHash;
        private bool _cursed = false;
        private BoosterScriptable _booster;
        private Vector3 _defaultScale;

        private Sequence twn;

        public void OnPointerClick(PointerEventData eventData)
        {
            if(!_cursed) Contexts.sharedInstance.booster.CreateEntity().ReplaceBoosterSelected(_boosterHash);
        }
        
        public void AddBoosterInfo(int boosterId)
        {
            gameObject.SetActive(true);
            //clear tweens
            twn.Kill();
            if(_defaultScale != Vector3.zero) transform.localScale = _defaultScale;
            
            _booster = ConfigsManager.Instance.boosterDatabase.GetBoosterById(boosterId);
            
            var boosterLevel = GameTools.GetBoosterLevel(_booster.id);
            string values = "";
            
            if (_booster.boosterType == BoosterEnums.BoosterType.StatBooster)
            {
                values = StatBoosterStringBuilder((StatBoosterScriptable)_booster, boosterLevel);
            }
            else
            {
                values = AttackBoosterStringBuilder((AttackBoosterScriptable)_booster);
            }
            
            boosterValues.color = Color.green;
            cursedBoosterValues.color = Color.red;
            cursedBoosterValues.SetText("");
            boosterValues.SetText(values);
            
            boosterName.SetText(_booster.name);
            boosterDescription.SetText(_booster.description);
            boosterIcon.sprite = _booster.icon;

            rarityBackground.color = ConfigsManager.Instance.boosterDatabase.GetRarityColor(_booster.boosterRarity);
            
            _boosterHash = boosterId;
        }

        public void AddCursedBoosterInfo(int boosterId, bool cursed)
        {
            gameObject.SetActive(true);

            _cursed = cursed;
            _booster = ConfigsManager.Instance.boosterDatabase.GetBoosterById(boosterId);
            var boosterLevel = GameTools.GetBoosterLevel(boosterId);

            if (_cursed)
            {
                boosterName.SetText(_booster.cursedVariant.name);
                boosterDescription.SetText(_booster.cursedVariant.description);
                boosterIcon.sprite = _booster.cursedVariant.icon;
                
                if (_booster.cursedVariant.boosterType == BoosterEnums.BoosterType.StatBooster)
                {
                    cursedBoosterValues.SetText(CursedStatBoosterStringBuilder((StatBoosterScriptable)_booster.cursedVariant, boosterLevel));
                }
                else
                {
                    cursedBoosterValues.SetText(AttackBoosterStringBuilder((AttackBoosterScriptable)_booster.cursedVariant));
                }
            }
            else
            {
                boosterName.SetText(_booster.name);
                boosterDescription.SetText(_booster.description);
                boosterIcon.sprite = _booster.icon;
                cursedBoosterValues.SetText("");
            }
            
            boosterValues.color = Color.green;
            cursedBoosterValues.color = Color.red;
            rarityBackground.color = ConfigsManager.Instance.boosterDatabase.GetRarityColor(_booster.boosterRarity);
            boosterValues.SetText($"+{_booster.values[boosterLevel - 1].ToString(CultureInfo.InvariantCulture)}%");
        }

        public void OnPointerEnter(PointerEventData eventData)
        {
            _defaultScale = transform.localScale;
            twn.Append(transform.DOScale(new Vector3(_defaultScale.x * 1.2f, _defaultScale.y * 1.2f, _defaultScale.z * 1.2f), 0.4f));
            twn.Play();
        }

        public void OnPointerExit(PointerEventData eventData)
        {
            twn.Append(transform.DOScale(_defaultScale, 0.4f));
            twn.Play();
            // boosterIcon.transform.localScale = _defaultScale;
        }

        private string StatBoosterStringBuilder(StatBoosterScriptable booster, int boosterLevel)
        {
            if(boosterLevel == 0) return $"+{booster.values[boosterLevel].ToString(CultureInfo.InvariantCulture)}%";
            else return $"+{booster.values[boosterLevel-1].ToString(CultureInfo.InvariantCulture)}%->+{booster.values[boosterLevel].ToString(CultureInfo.InvariantCulture)}%";
        }
        
        private string CursedStatBoosterStringBuilder(StatBoosterScriptable booster, int boosterLevel)
        {
            return $"-{booster.values[boosterLevel-1]}%";
        }
        
        private string AttackBoosterStringBuilder(AttackBoosterScriptable booster)
        {
            return "";
        }
        
    }
}