using Entitas;
using UnityEngine;

public class ReplaceAccelerationSystem : IExecuteSystem
{
    private Contexts _contexts;

    public ReplaceAccelerationSystem(Contexts contexts)
    {
        _contexts = contexts;
    }

    public void Execute()
    {
        if (!_contexts.game.playerEntity.hasAcceleration)
            return;

        var input = _contexts.game.input.Value.y;
        var player = _contexts.game.playerEntity;
        var playerTransform = player.view.Value.transform;
        var forward = playerTransform.up;
        var movementSpeed = _contexts.game.gameSetup.value.MovementSpeed;

        var acceleration = player.acceleration.Value;

        player.ReplaceAcceleration(acceleration + input * forward * movementSpeed * Time.deltaTime);
    }
}