using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class Sheriff : MonoBehaviour
{
    [SerializeField] private SheriffStats stats;

    // Reste dans le composant, pas dans le SO : sinon tous les sherifs
    // partageant le meme asset tireraient sur la meme frame.
    [SerializeField] private float startDelay;

    private AudioSource audioSource;
    private float cooldown;

    private void Awake()
    {
        audioSource = GetComponent<AudioSource>();
    }

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

        // Max evite une division par zero si fireRate reste a 0.
        cooldown = 1f / Mathf.Max(stats.FireRate, 0.01f);
    }

    public void Fire()
    {
        Bullet prefab = stats.GetRandomBullet();
        if (prefab == null)
            return;

        Instantiate(prefab, transform.position, Quaternion.identity);
        PlayFireSound();
    }

    private void PlayFireSound()
    {
        AudioClip clip = stats.GetRandomFireSound();
        if (clip == null)
            return;

        // PlayOneShot plutot que Play : les tirs se superposent
        // au lieu de se couper les uns les autres.
        audioSource.pitch = stats.GetRandomPitch();
        audioSource.PlayOneShot(clip, stats.Volume);
    }
}