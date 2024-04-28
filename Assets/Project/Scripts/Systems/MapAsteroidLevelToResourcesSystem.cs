using Entitas;
using System.Collections.Generic;
using UnityEngine;

public class MapAsteroidLevelToResourcesSystem : ReactiveSystem<GameEntity>
{
    private Contexts _contexts;

    public MapAsteroidLevelToResourcesSystem(Contexts contexts) : base(contexts.game)
    {
        _contexts = contexts;
    }

    protected override ICollector<GameEntity> GetTrigger(IContext<GameEntity> context)
    {
        return context.CreateCollector(GameMatcher.Asteroid);
    }

    protected override bool Filter(GameEntity entity)
    {
        return entity.hasAsteroid;
    }

    protected override void Execute(List<GameEntity> entities)
    {
        var setup = _contexts.game.gameSetup.value;
        foreach (var entity in entities)
        {
            entity.AddResource(MapAsteroidLevelToResource(entity.asteroid.Level, setup));
            var speed = _contexts.game.gameSetup.value.AsteroidSpeed;

            var randomAngle = Random.Range(-2f, 2f);

            entity.AddAcceleration(new Vector3(
                speed * Mathf.Cos(randomAngle),
                speed * Mathf.Sin(randomAngle), 0f));
        }
    }

    private GameObject MapAsteroidLevelToResource(int level, GameSetup setup)
    {
        switch (level)
        {
            case 0:
                return setup.TinyMeteors[Random.Range(0, setup.TinyMeteors.Length)];
            case 1:
                return setup.SmallMeteors[Random.Range(0, setup.SmallMeteors.Length)];
            case 2:
                return setup.MediumMeteors[Random.Range(0, setup.MediumMeteors.Length)];
            default:
                return setup.BigMeteors[Random.Range(0, setup.BigMeteors.Length)];
        }
    }
}
