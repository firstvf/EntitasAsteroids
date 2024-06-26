//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by Entitas.CodeGeneration.Plugins.ComponentEntityApiGenerator.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
public partial class GameEntity {

    public AsteroidComponent asteroid { get { return (AsteroidComponent)GetComponent(GameComponentsLookup.Asteroid); } }
    public bool hasAsteroid { get { return HasComponent(GameComponentsLookup.Asteroid); } }

    public void AddAsteroid(int newLevel) {
        var index = GameComponentsLookup.Asteroid;
        var component = (AsteroidComponent)CreateComponent(index, typeof(AsteroidComponent));
        component.Level = newLevel;
        AddComponent(index, component);
    }

    public void ReplaceAsteroid(int newLevel) {
        var index = GameComponentsLookup.Asteroid;
        var component = (AsteroidComponent)CreateComponent(index, typeof(AsteroidComponent));
        component.Level = newLevel;
        ReplaceComponent(index, component);
    }

    public void RemoveAsteroid() {
        RemoveComponent(GameComponentsLookup.Asteroid);
    }
}

//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by Entitas.CodeGeneration.Plugins.ComponentMatcherApiGenerator.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
public sealed partial class GameMatcher {

    static Entitas.IMatcher<GameEntity> _matcherAsteroid;

    public static Entitas.IMatcher<GameEntity> Asteroid {
        get {
            if (_matcherAsteroid == null) {
                var matcher = (Entitas.Matcher<GameEntity>)Entitas.Matcher<GameEntity>.AllOf(GameComponentsLookup.Asteroid);
                matcher.componentNames = GameComponentsLookup.componentNames;
                _matcherAsteroid = matcher;
            }

            return _matcherAsteroid;
        }
    }
}
