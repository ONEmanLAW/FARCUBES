using UnityEngine;

public class Player : MonoBehaviour
{
    public static Player Instance { get; private set; }

    [SerializeField] private float speed = 5f;
    [SerializeField] private Rigidbody body;

    private bool isDead;

    public bool IsDead => isDead;

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Debug.LogWarning($"{name} : un Player existe deja, celui-ci est detruit.");
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

    private void Reset()
    {
        body = GetComponent<Rigidbody>();
    }

    public void Move(float moveZ)
    {
        if (isDead)
            return;

        Vector3 velocity = body.linearVelocity;
        body.linearVelocity = new Vector3(velocity.x, velocity.y, moveZ * speed);
    }

    public void Die()
    {
        if (isDead)
            return;

        isDead = true;
        body.linearVelocity = Vector3.zero;

        Debug.Log("Player mort");

        // TODO : ecran de game over, animation, son
    }
}