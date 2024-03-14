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
    

}