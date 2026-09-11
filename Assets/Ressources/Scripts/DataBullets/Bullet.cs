using UnityEngine;

public abstract class Bullet : MonoBehaviour
{
    [SerializeField] protected BulletStats stats;
    [SerializeField] protected WorldStats worldStats;
    [SerializeField] protected Vector3 direction = Vector3.left;

    protected Vector3 origin;
    protected Vector3 velocity;
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

        // La balle herite de la vitesse de la map, comme le sherif qui l'a tiree.
        // Sans ca, une balle a la vitesse de la map reste collee au canon.
        Vector3 mapVelocity = worldStats != null ? worldStats.Velocity : Vector3.zero;

        velocity = direction.normalized * stats.Speed + mapVelocity;
    }

    protected virtual void Update()
    {
        elapsed += Time.deltaTime;
        transform.position = GetPosition(elapsed);
    }

    // Position absolue recalculee depuis l'origine, jamais accumulee.
    // Indispensable pour le zigzag a venir : une position accumulee derive.
    protected abstract Vector3 GetPosition(float time);

    protected Vector3 GetForwardPosition(float time)
    {
        return origin + velocity * time;
    }

    private void OnTriggerEnter(Collider other)
    {
        HandleHit(other.gameObject);
    }

    protected virtual void HandleHit(GameObject other)
    {
        if (!other.TryGetComponent(out Player player))
            return;

        player.Die();
        Destroy(gameObject);
    }
}