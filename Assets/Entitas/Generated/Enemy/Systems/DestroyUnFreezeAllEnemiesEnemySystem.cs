//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by Entitas.Roslyn.CodeGeneration.Plugins.CleanupSystemGenerator.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
using System.Collections.Generic;
using Entitas;

public sealed class DestroyUnFreezeAllEnemiesEnemySystem : ICleanupSystem {

    readonly IGroup<EnemyEntity> _group;
    readonly List<EnemyEntity> _buffer = new List<EnemyEntity>();

    public DestroyUnFreezeAllEnemiesEnemySystem(Contexts contexts) {
        _group = contexts.enemy.GetGroup(EnemyMatcher.UnFreezeAllEnemies);
    }

    public void Cleanup() {
        foreach (var e in _group.GetEntities(_buffer)) {
            e.Destroy();
        }
    }
}
