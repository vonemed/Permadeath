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

        public void SetBoosterInfo(Sprite boosterIcon, int count)
        {
            icon.sprite = boosterIcon;
            counter.SetText($"x{count.ToString()}");
        }
    }
}