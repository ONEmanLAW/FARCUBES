using UnityEngine;

public class GameOverUI : MonoBehaviour
{
    [SerializeField] private GameObject panel;

    private void Awake()
    {
        // OnEnable serait trop tard parce que player peut mourir avant sinon
        Player.OnPlayerDied += Show;

        if (panel != null)
            panel.SetActive(false);
    }

    private void OnDestroy()
    {
        // DEAD
        Player.OnPlayerDied -= Show;
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
    public void Restart()
    {
        // Recharger la scene
        UnityEngine.SceneManagement.SceneManager.LoadScene(UnityEngine.SceneManagement.SceneManager.GetActiveScene().name);
    }
}
