using System.Collections.Generic;
using Boosters;
using UnityEngine;

namespace ConfigScripts
{
    [CreateAssetMenu(fileName = "BoosterConfig", menuName = "Configs/BoosterConfig")]
    public class BoosterConfig : ScriptableObject
    {
        public List<Booster> boosters = new List<Booster>();
    }
}