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

public sealed class RemoveResetEnemySystem : ICleanupSystem {

    readonly IGroup<EnemyEntity> _group;
    readonly List<EnemyEntity> _buffer = new List<EnemyEntity>();

    public RemoveResetEnemySystem(Contexts contexts) {
        _group = contexts.enemy.GetGroup(EnemyMatcher.Reset);
    }

    public void Cleanup() {
        foreach (var e in _group.GetEntities(_buffer)) {
            e.isReset = false;
        }
    }
}