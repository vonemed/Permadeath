using Entitas.Unity;
using UnityEngine;

namespace Projectiles
{
    public class Projectile : MonoBehaviour
    {
        public GameEntity linkedEntity;

        private void Awake()
        {
            linkedEntity = Contexts.sharedInstance.game.CreateEntity();
            gameObject.Link(linkedEntity);

            linkedEntity.isProjectile = true;
            linkedEntity.AddTransform(transform);
        }
    }
}