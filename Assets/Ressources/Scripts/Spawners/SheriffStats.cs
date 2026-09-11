using UnityEngine;

[CreateAssetMenu(fileName = "SheriffStats", menuName = "Sheriff/Sheriff Stats")]
public class SheriffStats : ScriptableObject
{
    [SerializeField] private Bullet[] bulletPrefabs;
    [SerializeField] private float fireRate = 1f;
    [SerializeField] private AudioClip[] fireSounds;

    public float FireRate => fireRate;

    public Bullet GetRandomBullet()
    {
        if (bulletPrefabs == null || bulletPrefabs.Length == 0)
        {
            Debug.LogError($"SheriffStats '{name}' : aucun prefab assigne.");
            return null;
        }

        // Range(int, int) exclut la borne haute, donc Length est correct.
        return bulletPrefabs[Random.Range(0, bulletPrefabs.Length)];
    }

    public AudioClip GetRandomFireSound()
    {
        if (fireSounds == null || fireSounds.Length == 0)
            return null;

        return fireSounds[Random.Range(0, fireSounds.Length)];
    }
}