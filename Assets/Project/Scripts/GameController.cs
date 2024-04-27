using Entitas;
using UnityEngine;

public class GameController : MonoBehaviour
{
    [SerializeField] private GameSetup _gameSetup;
    private Systems _systems;

    private void Start()
    {
        var contexts = Contexts.sharedInstance;

        contexts.game.SetGameSetup(_gameSetup);

        _systems = CreateSystems(contexts);
        _systems.Initialize();
    }

    private void Update()
    {
        _systems.Execute();
        _systems.Cleanup();
    }

    private Systems CreateSystems(Contexts contexts)
    {
        return new Feature("Game")
            .Add(new HelloWorldSystem())
            .Add(new InputSystem(contexts))
            .Add(new ShootSystem(contexts))

            .Add(new InitializePlayerSystem(contexts))
            .Add(new InstantiateViewSystem(contexts))

            .Add(new RotatePlayerSystem(contexts))
            .Add(new ReplaceAccelerationSystem(contexts))

            .Add(new MoveSystem(contexts))
            ;
    }
}