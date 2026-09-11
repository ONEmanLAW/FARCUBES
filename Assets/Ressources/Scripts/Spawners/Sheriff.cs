using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class Sheriff : MonoBehaviour
{
    [SerializeField] private SheriffStats stats;

    // Decoche quand un SheriffGroup pilote ce sherif :
    // sinon les deux logiques de tir se cumulent.
    [SerializeField] private bool autoFire = true;
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
        if (!autoFire)
            return;

        cooldown -= Time.deltaTime;
        if (cooldown > 0f)
            return;

        Fire();

        // Max evite une division par zero si fireRate reste a 0.
        cooldown = 1f / Mathf.Max(stats.FireRate, 0.01f);
    }

    public void Fire()
    {
        if (stats == null)
            return;

        Bullet prefab = stats.GetRandomBullet();
        if (prefab == null)
            return;

        Instantiate(prefab, transform.position, Quaternion.identity);

        // PlayOneShot plutot que Play : les tirs se superposent
        // au lieu de se couper les uns les autres.
        AudioClip clip = stats.GetRandomFireSound();
        if (clip != null)
            audioSource.PlayOneShot(clip);
    }
}