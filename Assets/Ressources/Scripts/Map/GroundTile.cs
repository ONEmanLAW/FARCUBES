using UnityEngine;

public class GroundTile : MonoBehaviour
{
    [SerializeField] private WorldStats stats;

    private void Start()
    {
        if (stats == null)
        {
            Debug.LogError($"{name} : aucun WorldStats assigne.");
            enabled = false;
        }
    }

    private void Update()
    {
        transform.position += stats.Velocity * Time.deltaTime;
    }
}