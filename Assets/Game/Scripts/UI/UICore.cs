using UnityEngine;

namespace UI
{
    public class UICore : MonoBehaviour
    {
        public DefeatPanel defeatPanel;
        public StatsScreen statsScreen;

        private void Awake()
        {
            defeatPanel.Ctor();
            statsScreen.Ctor();
        }
    }
}