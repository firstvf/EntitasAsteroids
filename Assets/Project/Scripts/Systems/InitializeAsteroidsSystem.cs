using Entitas;

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
           // entity.ad
        }
    }
}