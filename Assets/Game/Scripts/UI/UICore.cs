using UnityEngine;

namespace UI
{
    public class UICore : MonoBehaviour
    {
        public DefeatPanel defeatPanel;

        private void Awake()
        {
            defeatPanel.Ctor();
        }
    }
}