using UnityEngine;

public class Spawner : MonoBehaviour
{
    [Header("Tir")]
    [SerializeField] private Bullet bulletPrefab;
    [SerializeField] private float fireRate = 1f;
    [SerializeField] private float startDelay;

    private float cooldown;

    private void Start()
    {
        cooldown = startDelay;
    }

    private void Update()
    {
        cooldown -= Time.deltaTime;
        if (cooldown > 0f)
            return;

        Fire();

        // Max evite une division par zero si fireRate reste a 0 dans l'Inspector.
        cooldown = 1f / Mathf.Max(fireRate, 0.01f);
    }

    public void Fire()
    {
        if (bulletPrefab == null)
        {
            Debug.LogError($"{name} : aucun bulletPrefab assigne.");
            return;
        }

        Instantiate(bulletPrefab, transform.position, Quaternion.identity);
    }
}