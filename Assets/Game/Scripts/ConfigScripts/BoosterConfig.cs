using System.Collections.Generic;
using Boosters;
using UnityEngine;

namespace ConfigScripts
{
    [CreateAssetMenu(fileName = "BoosterConfig", menuName = "Configs/BoosterConfig")]
    public class BoosterConfig : ScriptableObject
    {
        public List<Booster> boosters = new List<Booster>();

        public Booster GetBoosterByStats(BoosterStats stats)
        {
            return boosters.Find(x => x.boosterStats == stats);
        }
    }
}