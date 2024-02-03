using System;
using TMPro;
using UnityEngine;

namespace UI
{
    public class Timer : MonoBehaviour
    {
        public TMP_Text displayTxt;

        private float _currentTime;
        //temp solution, cause I am lazy TODO: move it to separate system and components
        private void Update()
        {
            _currentTime += Time.deltaTime;
            var minutes = Mathf.FloorToInt(_currentTime / 60);
            var seconds = Mathf.FloorToInt(_currentTime % 60);
            displayTxt.SetText(string.Format("{0:00}:{1:00}", minutes, seconds));
        }
    }
}