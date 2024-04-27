using Entitas;
using UnityEngine;

public class RotatePlayerSystem : IExecuteSystem
{
    private Contexts _contexts;

    public RotatePlayerSystem(Contexts contexts)
    {
        _contexts = contexts;
    }

    public void Execute()
    {
        if (!_contexts.game.playerEntity.hasView)
        {
            Debug.Log("Player does not have view");
            return;
        }        

        var input = _contexts.game.input.Value.x;
        var playerTransform = _contexts.game.playerEntity.view.Value.transform;

        var playerRotation = playerTransform.rotation.eulerAngles;

        playerRotation.z -= input * _contexts.game.gameSetup.value.RotationSpeed * Time.deltaTime;            
        playerTransform.rotation = Quaternion.Euler(playerRotation);
    }
}