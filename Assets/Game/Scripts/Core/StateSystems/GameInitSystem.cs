using Entitas;

namespace Game
{
    public class GameInitSystem : IInitializeSystem
    {
        public void Initialize()
        {
            var stateEntity = Contexts.sharedInstance.game.CreateEntity();

            stateEntity.isStateHandler = true;
            stateEntity.ReplaceCurrentState(GameCore.GameState.Play);
        }
    }
}