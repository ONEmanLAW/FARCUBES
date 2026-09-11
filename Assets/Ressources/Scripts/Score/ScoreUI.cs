using TMPro;
using UnityEngine;

public class ScoreUI : MonoBehaviour
{
    [SerializeField] private TMP_Text label;
    [SerializeField] private string format = "Score : {0}";

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
        if (ScoreManager.Instance != null)
            ScoreManager.Instance.OnScoreChanged -= UpdateLabel;
    }

    private void UpdateLabel(int score)
    {
        if (label != null)
            label.text = string.Format(format, score);
    }
}