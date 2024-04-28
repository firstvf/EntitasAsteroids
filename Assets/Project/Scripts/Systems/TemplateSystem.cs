using Entitas;
using UnityEngine;

public class TemplateSystem : IInitializeSystem
{
    private Contexts _contexts;

    public TemplateSystem(Contexts contexts)
    {
        _contexts = contexts;
    }

    public void Initialize()
    {
        Debug.Log("Template system");
    }
}
