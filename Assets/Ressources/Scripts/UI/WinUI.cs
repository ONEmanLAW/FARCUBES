using UnityEngine;

public class WinUI : MonoBehaviour
{
    [SerializeField] private GameObject panel;

    private void Awake()
    {
        // Awake et pas OnEnable : le joueur pourrait gagner avant sinon.
        Player.OnPlayerWon += Show;

        if (panel != null)
            panel.SetActive(false);
    }

    private void OnDestroy()
    {
        Player.OnPlayerWon -= Show;
    }

    private void Show()
    {
        if (panel != null)
            panel.SetActive(true);

        // Fige tout : map, sherifs, balles. Aucun script a modifier.
        Time.timeScale = 0f;
    }

    private void Start()
    {
        // Securite : si une partie precedente a laisse le jeu fige.
        Time.timeScale = 1f;
    }
}
