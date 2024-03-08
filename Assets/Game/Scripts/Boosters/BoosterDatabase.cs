using System;
using System.Collections.Generic;
using DefaultNamespace;
using UnityEngine;

namespace Boosters
{
    [CreateAssetMenu(fileName = "New Booster Database", menuName = "Assets/Databases/Booster Database")]
    public class BoosterDatabase : ScriptableObject
    {
        public List<BoosterScriptable> boosters = new List<BoosterScriptable>();

        public BoosterScriptable GetBoosterById(int id)
        {
            return boosters.Find(x => x.id == id);
        }

        public List<BoosterScriptable> GetRandomBoosters(int amount)
        {
            if (amount <= 0)
            {
                Debug.LogWarning("Random booster request. Amount can't be 0 or less.");
                return null;
            }

            return boosters.GetRandomSubset(amount);
        }
    }
}