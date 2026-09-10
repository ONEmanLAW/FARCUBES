using UnityEngine;

public class Sheriff : MonoBehaviour
{
    [SerializeField] private SheriffStats stats;
    [SerializeField] private float startDelay;

    private float cooldown;

    private void Start()
    {
        if (stats == null)
        {
            Debug.LogError($"{name} : aucun SheriffStats assigne.");
            enabled = false;
            return;
        }

        cooldown = startDelay;
    }

    private void Update()
    {
        cooldown -= Time.deltaTime;
        if (cooldown > 0f)
            return;

        Fire();

        // evite une division par zero si fireRate reste a 0.
        cooldown = 1f / Mathf.Max(stats.FireRate, 0.01f);
    }

    public void Fire()
    {
        Bullet prefab = stats.GetRandomBullet();
        if (prefab == null)
            return;

        Instantiate(prefab, transform.position, Quaternion.identity);
    }
}