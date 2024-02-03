using System;
using Entitas.Unity;
using UnityEngine;

namespace Loot
{
    public abstract class Loot : MonoBehaviour
    {
        public LootEntity linkedEntity;
        [HideInInspector] public Reward reward;
        public void Init()
        {
            linkedEntity = Contexts.sharedInstance.loot.CreateEntity();
            gameObject.Link(linkedEntity);

            linkedEntity.isLoot = true;
            linkedEntity.AddTransform(transform);
            linkedEntity.AddLootReward(reward);
        }

        [Serializable]
        public class Reward
        {
            public int xpReward;
        }
    }
}