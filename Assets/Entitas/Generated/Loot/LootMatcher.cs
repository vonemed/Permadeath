//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by Entitas.CodeGeneration.Plugins.ContextMatcherGenerator.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
public sealed partial class LootMatcher {

    public static Entitas.IAllOfMatcher<LootEntity> AllOf(params int[] indices) {
        return Entitas.Matcher<LootEntity>.AllOf(indices);
    }

    public static Entitas.IAllOfMatcher<LootEntity> AllOf(params Entitas.IMatcher<LootEntity>[] matchers) {
          return Entitas.Matcher<LootEntity>.AllOf(matchers);
    }

    public static Entitas.IAnyOfMatcher<LootEntity> AnyOf(params int[] indices) {
          return Entitas.Matcher<LootEntity>.AnyOf(indices);
    }

    public static Entitas.IAnyOfMatcher<LootEntity> AnyOf(params Entitas.IMatcher<LootEntity>[] matchers) {
          return Entitas.Matcher<LootEntity>.AnyOf(matchers);
    }
}
