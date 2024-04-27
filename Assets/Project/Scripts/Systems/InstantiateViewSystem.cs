using Entitas;
using Entitas.Unity;
using System.Collections.Generic;
using UnityEngine;

public class InstantiateViewSystem : ReactiveSystem<GameEntity>
{
    private Contexts _contexts;

    public InstantiateViewSystem(Contexts contexts) : base(contexts.game)
    {
        _contexts = contexts;
    }

    protected override ICollector<GameEntity> GetTrigger(IContext<GameEntity> context)
    {
        return context.CreateCollector(GameMatcher.Resource);
    }

    protected override bool Filter(GameEntity entity)
    {
        return entity.hasResource;
    }

    protected override void Execute(List<GameEntity> entities)
    {
        foreach (var entity in entities)
        {
            var gameObject = Object.Instantiate(entity.resource.Prefab);
            entity.AddView(gameObject);
            gameObject.Link(entity);

            if (entity.hasInitialPosition)
                gameObject.transform.position = entity.initialPosition.Value;
        }
    }
}