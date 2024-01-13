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

public sealed class RemoveSpawnObjectsObjectPoolerSystem : ICleanupSystem {

    readonly IGroup<ObjectPoolerEntity> _group;
    readonly List<ObjectPoolerEntity> _buffer = new List<ObjectPoolerEntity>();

    public RemoveSpawnObjectsObjectPoolerSystem(Contexts contexts) {
        _group = contexts.objectPooler.GetGroup(ObjectPoolerMatcher.SpawnObjects);
    }

    public void Cleanup() {
        foreach (var e in _group.GetEntities(_buffer)) {
            e.isSpawnObjects = false;
        }
    }
}
