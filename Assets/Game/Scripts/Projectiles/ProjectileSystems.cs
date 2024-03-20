
namespace Projectiles
{
    public sealed class ProjectileSystems : Feature
    {
        public ProjectileSystems(Contexts contexts)
        {
            Add(new ProjectileMoveSystem(contexts.game));
        }
    }
}