using Entitas.CodeGeneration.Attributes;
using UnityEngine;

[CreateAssetMenu]
[Game, Unique]
public class GameSetup : ScriptableObject
{
    public GameObject Player;
    public float RotationSpeed = 180f;
    public float MovementSpeed = 5f;
}