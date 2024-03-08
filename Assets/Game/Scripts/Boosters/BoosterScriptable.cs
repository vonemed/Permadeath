using System.Collections.Generic;
using Boosters;
using UnityEngine;

namespace DefaultNamespace
{
    public class BoosterScriptable : ScriptableObject
    {
        [HideInInspector] public BoosterEnums.BoosterType boosterType;
        public int id;
        public Sprite icon;
        public string name;
        public string description;
        public BoosterEnums.BoosterRarity boosterRarity;
        public List<float> values;
        public BoosterScriptable cursedVariant;
    }
    

}