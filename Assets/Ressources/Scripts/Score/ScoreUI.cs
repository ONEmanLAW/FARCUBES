using TMPro;
using UnityEngine;

public class ScoreUI : MonoBehaviour
{
    [SerializeField] private TMP_Text label;
    [SerializeField] private string format = "Score : {0}";

    private void Awake()
    {
        // Awake et pas Start : le joueur pourrait mourir avant le Start.
        Player.OnPlayerDied += Hide;
    }

    private void Start()
    {
        if (ScoreManager.Instance == null)
        {
            Debug.LogError($"{name} : aucun ScoreManager dans la scene.");
            enabled = false;
            return;
        }

        ScoreManager.Instance.OnScoreChanged += UpdateLabel;

        UpdateLabel(ScoreManager.Instance.Score);
    }

    private void OnDestroy()
    {
        Player.OnPlayerDied -= Hide;

        if (ScoreManager.Instance != null)
            ScoreManager.Instance.OnScoreChanged -= UpdateLabel;
    }

    private void UpdateLabel(int score)
    {
        if (label != null)
            label.text = string.Format(format, score);
    }

    private void Hide()
    {
        GameObject panel = GetPanel();

        if (panel != null)
            panel.SetActive(false);
    }

    // Le texte est enfant du ScorePanel. On cache le parent pour enlever
    // le fond en meme temps que le texte, pas seulement les chiffres.
    private GameObject GetPanel()
    {
        if (label == null)
            return null;

        Transform parent = label.transform.parent;

        return parent != null ? parent.gameObject : label.gameObject;
    }
}
