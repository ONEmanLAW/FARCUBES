using UnityEngine;

public class SheriffGroup : MonoBehaviour
{
    [SerializeField] private Sheriff[] sheriffs;

    [Header("Cadence")]
    [SerializeField] private float fireRate = 1f;
    [SerializeField] private float startDelay = 1f;

    [SerializeField] private bool avoidRepeat = true;

    private int lastIndex = -1;
    private float cooldown;

    private void Reset()
    {
        sheriffs = GetComponentsInChildren<Sheriff>();
    }

    private void Start()
    {
        if (sheriffs == null || sheriffs.Length == 0)
        {
            Debug.LogError($"{name} : aucun sherif dans le tableau.");
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

        FireRandomSheriff();

        cooldown = 1f / Mathf.Max(fireRate, 0.01f);
    }

    private void FireRandomSheriff()
    {
        int index = PickIndex();

        Sheriff sheriff = sheriffs[index];
        if (sheriff == null)
        {
            Debug.LogError($"{name} : case vide dans le tableau.");
            return;
        }

        sheriff.Fire();
        lastIndex = index;
    }

    private int PickIndex()
    {
        if (!avoidRepeat || sheriffs.Length < 2)
            return Random.Range(0, sheriffs.Length);

        int index = Random.Range(0, sheriffs.Length - 1);
        if (index >= lastIndex)
            index++;

        return index;
    }
}