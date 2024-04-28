using Entitas;
using System.Collections.Generic;
using UnityEngine;

public class HitAsteroidSystem : ReactiveSystem<GameEntity>
{
    private Contexts _contexts;

    public HitAsteroidSystem(Contexts contexts) : base(contexts.game)
    {
        _contexts = contexts;
    }

    protected override ICollector<GameEntity> GetTrigger(IContext<GameEntity> context)
    {
        return context.CreateCollector(GameMatcher.Collision);
    }

    protected override bool Filter(GameEntity entity)
    {
        return entity.hasCollision;
    }

    protected override void Execute(List<GameEntity> entities)
    {
        foreach (var entity in entities)
        {
            var first = entity.collision.First;
            var second = entity.collision.Second;

            var firstEntity = _contexts.game.GetEntitiesWithView(first).SingleEntity();
            var secondEntity = _contexts.game.GetEntitiesWithView(second).SingleEntity();

            if (secondEntity.hasAsteroid && secondEntity.asteroid.Level > 0)
                for (int i = 0; i < 2; i++)
                {
                    var newEntity = _contexts.game.CreateEntity();
                    newEntity.AddAsteroid(secondEntity.asteroid.Level - 1);

                    newEntity.AddInitialPosition(second.transform.position +
                        new Vector3(Random.Range(-.1f, .1f), Random.Range(-.1f, .1f), 0));
                }

            firstEntity.isDestroy = true;
            secondEntity.isDestroy = true;
        }
    }
}