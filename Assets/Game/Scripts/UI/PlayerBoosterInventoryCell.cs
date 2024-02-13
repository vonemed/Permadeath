using System;
using Boosters;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace UI
{
    public class PlayerBoosterInventoryCell : MonoBehaviour
    {
        [SerializeField] private Image icon;
        [SerializeField] private TMP_Text counter;

        public void SetBoosterInfo(Booster booster, int count)
        {
            icon.sprite = booster.icon;
            counter.SetText($"x{count.ToString()}");
        }
    }
}