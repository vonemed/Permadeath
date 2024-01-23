
namespace Projectiles
{
    public class ProjectileSystems : Feature
    {
        public ProjectileSystems(Contexts contexts)
        {
            Add(new ProjectileMoveSystem(contexts.game));
        }
    }
}