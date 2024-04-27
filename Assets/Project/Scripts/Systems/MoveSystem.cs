using Entitas;
using UnityEngine;

public class MoveSystem : IExecuteSystem
{
    private Contexts _contexts;
    private IGroup<GameEntity> _group;

    public MoveSystem(Contexts contexts)
    {
        _contexts = contexts;
        _group = _contexts.game.GetGroup(GameMatcher
            .AllOf(GameMatcher.Acceleration, GameMatcher.View));
    }

    public void Execute()
    {
        foreach (var entity in _group)
        {
            var view = entity.view.Value;
            var acceleration = entity.acceleration.Value;

            Vector3 position = view.transform.position;
            position += acceleration * Time.deltaTime;

            view.transform.position = position;
        }
    }
}