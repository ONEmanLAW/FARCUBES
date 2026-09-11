using UnityEngine;

public class WinZone : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        // Debug temporaire : a retirer une fois que la zone fonctionne.
        Debug.Log($"zone de victoire touchee par {other.name}");

        // GetComponentInParent et pas TryGetComponent : le collider peut
        // etre sur un enfant du joueur (le modele par exemple).
        Player player = other.GetComponentInParent<Player>();

        if (player == null)
        {
            Debug.Log($"{other.name} n'est pas le joueur");
            return;
        }

        player.Win();
    }
}
