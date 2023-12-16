using UnityEngine;
using UnityEngine.InputSystem;

namespace Player
{
    public class PlayerView : MonoBehaviour
    {
        public PlayerEntity linkedEntity;
        private void Awake()
        {
            linkedEntity = Contexts.sharedInstance.player.CreateEntity();
            
            linkedEntity.AddTransform(transform);
        }
        
        public void OnMove(InputAction.CallbackContext context)
        {
            Debug.Log("moooove");
            linkedEntity.ReplaceMove(context.ReadValue<Vector3>());
        }
    }
}