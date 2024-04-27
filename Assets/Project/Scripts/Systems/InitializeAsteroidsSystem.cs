using Entitas;
using UnityEngine;

public class InitializeAsteroidsSystem : IInitializeSystem
{
    private Contexts _contexts;

    public InitializeAsteroidsSystem(Contexts contexts)
    {
        _contexts = contexts;
    }

    public void Initialize()
    {
        for (int i = 0; i < 4; i++)
        {
            var entity = _contexts.game.CreateEntity();
            var speed = _contexts.game.gameSetup.value.AsteroidSpeed;

            entity.AddAsteroid(3);
            entity.AddInitialPosition(new Vector3(Random.Range(-3f, 3f),
                Random.Range(-3f, 3f), 0f));

            var randomAngle = Random.Range(-2f, 2f);

            entity.AddAcceleration(new Vector3(
                speed * Mathf.Cos(randomAngle),
                speed * Mathf.Sin(randomAngle), 0f));
        }
    }
}