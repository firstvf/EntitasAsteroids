using Entitas;
using UnityEngine;

public class HelloWorldSystem : IInitializeSystem
{
    public void Initialize()
    {
        Debug.Log("Init hello_world_system");
    }
}