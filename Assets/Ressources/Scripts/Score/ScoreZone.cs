using UnityEngine;

public class ScoreZone : MonoBehaviour
{
    [SerializeField] private int pointsPerBullet = 1;

    private void OnTriggerEnter(Collider other)
    {
        // Debug temporaire : a retirer une fois que la zone fonctionne.
        Debug.Log($"zone touchee par {other.name}");

        if (!other.TryGetComponent(out Bullet bullet))
        {
            Debug.Log($"{other.name} n'a pas de composant Bullet");
            return;
        }

        if (ScoreManager.Instance == null)
        {
            Debug.LogError($"{name} : aucun ScoreManager dans la scene.");
            return;
        }

        ScoreManager.Instance.AddScore(pointsPerBullet);
        Destroy(bullet.gameObject);
    }
}