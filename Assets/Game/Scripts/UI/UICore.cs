using UnityEngine;

namespace UI
{
    public class UICore : MonoBehaviour
    {
        public DefeatPanel defeatPanel;
        public BoosterChoosePanel boosterPanel;
        public StatsScreen statsScreen;
        public PlayerBoosterInventory boosterInventory;

        private void Awake()
        {
            defeatPanel.Ctor();
            statsScreen.Ctor();
            boosterPanel.Ctor();
            boosterInventory.Ctor();
        }
    }
}
