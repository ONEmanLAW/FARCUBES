using UnityEngine;

public abstract class Bullet : MonoBehaviour
{
    [SerializeField] protected BulletStats stats;
    [SerializeField] protected Vector3 direction = Vector3.right;

    protected Vector3 origin;
    protected float elapsed;

    protected virtual void Start()
    {
        if (stats == null)
        {
            Debug.LogError($"{name} : aucun BulletStats assigne.");
            enabled = false;
            return;
        }

        origin = transform.position;
        elapsed = 0f;
    }

    protected virtual void Update()
    {
        elapsed += Time.deltaTime;
        transform.position = GetPosition(elapsed);
    }

    // Indispensable pour le zigzag si on le fait
    protected abstract Vector3 GetPosition(float time);

    protected Vector3 GetForwardPosition(float time)
    {
        return origin + direction.normalized * (stats.Speed * time);
    }

    private void OnTriggerEnter(Collider other)
    {
        HandleHit(other.gameObject);
    }

    protected virtual void HandleHit(GameObject other)
    {
        // TryGetComponent plutot qu'un tag car askip ca verifie par le compilateur,
        if (!other.TryGetComponent(out Player player))
            return;

        player.Die();
        Destroy(gameObject);
    }
}