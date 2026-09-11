using UnityEngine;

public class MapScroller : MonoBehaviour
{
    public static MapScroller Instance { get; private set; }

    [SerializeField] private float speed = 5f;
    [SerializeField] private Vector3 direction = Vector3.left;

    public Vector3 Velocity => direction.normalized * speed;

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;
    }

    private void OnDestroy()
    {
        if (Instance == this)
            Instance = null;
    }
}