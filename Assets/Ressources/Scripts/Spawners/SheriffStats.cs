using UnityEngine;

[CreateAssetMenu(fileName = "SheriffStats", menuName = "Sheriff/Sheriff Stats")]
public class SheriffStats : ScriptableObject
{
    [SerializeField] private Bullet[] bulletPrefabs;
    [SerializeField] private float fireRate = 1f;

    [Header("Audio")]
    [SerializeField] private AudioClip[] fireSounds;
    [SerializeField] private float volume = 1f;

    // Pitch aleatoire : deux tirs identiques sonnent repetitif.
    // Une legere variation suffit a casser l'effet.
    [SerializeField] private Vector2 pitchRange = new Vector2(0.95f, 1.05f);

    public float FireRate => fireRate;
    public float Volume => volume;

    public Bullet GetRandomBullet()
    {
        if (bulletPrefabs == null || bulletPrefabs.Length == 0)
        {
            Debug.LogError($"SheriffStats '{name}' : aucun prefab assigne.");
            return null;
        }

        // Range(int, int) exclut la borne haute, donc Length est correct.
        Bullet prefab = bulletPrefabs[Random.Range(0, bulletPrefabs.Length)];

        if (prefab == null)
            Debug.LogError($"SheriffStats '{name}' : case vide dans bulletPrefabs.");

        return prefab;
    }

    public AudioClip GetRandomFireSound()
    {
        if (fireSounds == null || fireSounds.Length == 0)
            return null;

        return fireSounds[Random.Range(0, fireSounds.Length)];
    }

    public float GetRandomPitch()
    {
        return Random.Range(pitchRange.x, pitchRange.y);
    }
}