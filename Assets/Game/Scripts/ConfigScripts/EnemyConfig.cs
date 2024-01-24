using UnityEngine;

namespace ConfigScripts
{
    [CreateAssetMenu(fileName = "EnemyConfig", menuName = "Configs/EnemyConfig")]
    public class EnemyConfig : ScriptableObject
    {
        [Header("[Stats]")] 
        public float moveSpeed;
        public int health;
        public int attackDamage;
        public float attackRange;
        public float attackRate;
    }
}