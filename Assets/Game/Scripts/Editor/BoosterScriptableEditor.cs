using Boosters;
using UnityEditor;

namespace Editor
{
#if UNITY_EDITOR
    [CustomEditor(typeof(StatBoosterScriptable))]
    public sealed class BoosterScriptableEditor : UnityEditor.Editor
    {
        private StatBoosterScriptable _booster;

        private void OnEnable()
        {
            _booster = (StatBoosterScriptable)target;
        }

        public override void OnInspectorGUI()
        {
            base.OnInspectorGUI();
            if (_booster.id == 0) _booster.id = GetHashCode();
        }
    }

#endif
}