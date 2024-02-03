using UnityEngine;

namespace ConfigScripts
{
    public class ConfigsManager : MonoBehaviour
    {
        public static ConfigsManager Instance;

        public PlayerConfig playerConfig;
        public EnemyConfig enemyConfig;
        public BoosterConfig boosterConfig;
        public ParticlesConfig particlesConfig;

        private void Awake()
        {
            Instance = this;
        }
    }
}