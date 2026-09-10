using UnityEngine;

public class InputControllerPlayer : MonoBehaviour
{
    [SerializeField] private Player player;

    private void Awake()
    {
        if (player == null)
            player = GetComponent<Player>();

        if (player == null)
            Debug.LogError($"{name} : aucun Player assigne.");
    }

    private void Update()
    {
        if (player == null)
            return;

        float moveZ = 0f;

        if (Input.GetKey(KeyCode.RightArrow))
            moveZ = 1f;
        else if (Input.GetKey(KeyCode.LeftArrow))
            moveZ = -1f;

        player.Move(moveZ);
    }
}