using UnityEngine;

[CreateAssetMenu(fileName = "WorldStats", menuName = "World/World Stats")]
public class WorldStats : ScriptableObject
{
    [SerializeField] private float speed = 5f;
    [SerializeField] private Vector3 direction = Vector3.left;

    public float Speed => speed;
    public Vector3 Direction => direction.normalized;

    // Direction et vitesse combinees : les objets n'ont plus
    // qu'a multiplier par Time.deltaTime.
    public Vector3 Velocity => Direction * speed;
}