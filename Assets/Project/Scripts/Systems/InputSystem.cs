using Entitas;
using UnityEngine;

public class InputSystem : IExecuteSystem
{
    private Contexts _contexts;

    public InputSystem(Contexts contexts)
    {
        _contexts = contexts;
    }

    public void Execute()
    {
        var horizontalInput = Input.GetAxisRaw("Horizontal");
        var verticalInput = Input.GetAxisRaw("Vertical");
        var fireInput = Input.GetAxisRaw("Jump");

        _contexts.game.ReplaceInput(new Vector3(horizontalInput, verticalInput, 0));

        if (horizontalInput != 0)
            Debug.Log("Horizontal input");

        if (verticalInput != 0)
            Debug.Log("Vertical input");

        if (fireInput != 0)
            Debug.Log("Fire input");
    }
}