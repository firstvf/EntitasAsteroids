using Entitas.CodeGeneration.Attributes;
using UnityEngine;

[CreateAssetMenu]
[Game, Unique]
public class GameSetup : ScriptableObject
{
    public GameObject Player;
    public GameObject Laser;
    public float RotationSpeed = 180f;
    public float MovementSpeed = 5f;
    public float LaserSpeed = 10f;

    public float AsteroidSpeed = 0.3f;

    public GameObject[] BigMeteors;
    public GameObject[] MediumMeteors;
    public GameObject[] SmallMeteors;
    public GameObject[] TinyMeteors;
}