using UnityEngine;

namespace Player
{
    public class PlayerView : MonoBehaviour
    {
        public PlayerEntity linkedEntity;
        private void Awake()
        {
            linkedEntity = Contexts.sharedInstance.player.CreateEntity();
        }
    }
}