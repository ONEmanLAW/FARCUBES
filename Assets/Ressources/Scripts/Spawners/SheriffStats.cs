using UnityEngine;

[CreateAssetMenu(fileName = "SheriffStats", menuName = "Sheriff/Sheriff Stats")]
public class SheriffStats : ScriptableObject
{
    [SerializeField] private Bullet[] bulletPrefabs;
    [SerializeField] private float fireRate = 1f;

    public float FireRate => fireRate;

    public Bullet GetRandomBullet()
    {
        if (bulletPrefabs == null || bulletPrefabs.Length == 0)
        {
            Debug.LogError($"SheriffStats '{name}' : aucun prefab assigne.");
            return null;
        }

        Bullet prefab = bulletPrefabs[Random.Range(0, bulletPrefabs.Length)];

        if (prefab == null)
            Debug.LogError($"SheriffStats '{name}' : case vide dans bulletPrefabs.");

        return prefab;
    }
}