//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by Entitas.CodeGeneration.Plugins.ComponentEntityApiInterfaceGenerator.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
public partial interface ILevelEntity {

    Game.LevelComponent level { get; }
    bool hasLevel { get; }

    void AddLevel(int newValue);
    void ReplaceLevel(int newValue);
    void RemoveLevel();
}