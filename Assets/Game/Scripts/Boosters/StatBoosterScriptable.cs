using DefaultNamespace;
using UnityEditor;
using UnityEngine;

namespace Boosters
{
    [CreateAssetMenu(fileName = "New Stat Booster", menuName = "Assets/Stat Booster")]
    public class StatBoosterScriptable : BoosterScriptable
    {
        public BoosterEnums.PlayerStatType stat;

        public StatBoosterScriptable()
        {
           boosterType = BoosterEnums.BoosterType.StatBooster;
        }
    }
    
#if UNITY_EDITOR
    [CustomEditor(typeof(StatBoosterScriptable))]
    public sealed class BoosterScriptableEditor : Editor
    {
        private StatBoosterScriptable _booster;
        private void OnEnable()
        {
            _booster = (StatBoosterScriptable)target;
        }

        public override void OnInspectorGUI()
        {
            base.OnInspectorGUI();
            if(_booster.id == 0) _booster.id = GetHashCode();
        }
    }
    
#endif
}