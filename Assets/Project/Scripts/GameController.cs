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

        //var entity = contexts.game.CreateEntity();
        //entity.AddGameSetup(_gameSetup);

        _systems = CreateSystems(contexts);
        _systems.Initialize();
    }

    private Systems CreateSystems(Contexts contexts)
    {
        return new Feature("Game")
            .Add(new HelloWorldSystem())
            .Add(new InitializePlayerSystem(contexts));
    }
}