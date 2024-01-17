using UnityEngine;

namespace ConfigScripts
{
    public class ConfigsManager : MonoBehaviour
    {
        public static ConfigsManager Instance;

        public PlayerConfig playerConfig;

        private void Awake()
        {
            Instance = this;
        }
    }
}