using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class MusicManager : MonoBehaviour
{
    [SerializeField] private AudioClip music;

    private AudioSource audioSource;

    private void Awake()
    {
        audioSource = GetComponent<AudioSource>();

        // Awake et pas Start : le joueur pourrait mourir ou gagner avant sinon.
        Player.OnPlayerDied += StopMusic;
        Player.OnPlayerWon += StopMusic;
    }

    private void OnDestroy()
    {
        Player.OnPlayerDied -= StopMusic;
        Player.OnPlayerWon -= StopMusic;
    }

    private void Start()
    {
        if (music == null)
        {
            Debug.LogWarning($"{name} n'a pas de musique assignee");
            return;
        }

        audioSource.clip = music;
        audioSource.loop = true;

        // Play plutot que PlayOneShot : on veut pouvoir l'arreter plus tard.
        audioSource.Play();
    }

    private void StopMusic()
    {
        audioSource.Stop();
    }
}
