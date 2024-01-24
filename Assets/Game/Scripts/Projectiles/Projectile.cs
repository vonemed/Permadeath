using Entitas.Unity;
using UnityEngine;

namespace Projectiles
{
    public class Projectile : MonoBehaviour, IOffListener
    {
        public GameEntity linkedEntity;
        [SerializeField] private TrailRenderer trail;

        private void Awake()
        {
            linkedEntity = Contexts.sharedInstance.game.CreateEntity();
            gameObject.Link(linkedEntity);

            linkedEntity.isProjectile = true;
            linkedEntity.AddTransform(transform);
            
            linkedEntity.AddOffListener(this);
        }

        public void OnOff(GameEntity entity)
        {
            trail.Clear();
            gameObject.SetActive(false);
        }
    }
}