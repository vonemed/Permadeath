//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by Entitas.CodeGeneration.Plugins.ComponentEntityApiInterfaceGenerator.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
public partial interface IHealthEntity {

    Game.HealthComponent health { get; }
    bool hasHealth { get; }

    void AddHealth(int newValue);
    void ReplaceHealth(int newValue);
    void RemoveHealth();
}
