//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by Entitas.CodeGeneration.Plugins.EventSystemsGenerator.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
public sealed class LootEventSystems : Feature {

    public LootEventSystems(Contexts contexts) {
        Add(new LootHideEventSystem(contexts)); // priority: 0
        Add(new LootShowEventSystem(contexts)); // priority: 0
    }
}
