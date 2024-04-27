using Entitas;
using UnityEngine;

public class ShootSystem : IExecuteSystem
{
    private Contexts _contexts;

    public ShootSystem(Contexts contexts)
    {
        _contexts = contexts;
    }

    public void Execute()
    {
        if (Input.GetButtonDown("Jump"))
        {
            var entity = _contexts.game.CreateEntity();
            var setup = _contexts.game.gameSetup.value;
            entity.AddResource(setup.Laser);
            var playerTransform = _contexts.game.playerEntity.view.Value.transform;
            var playerForward = playerTransform.up;
            entity.AddAcceleration(playerForward * setup.LaserSpeed);
            entity.AddInitialPosition(playerTransform.position);
        }
    }
}
