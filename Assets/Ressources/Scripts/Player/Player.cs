using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private float speed = 5f;
    [SerializeField] private Rigidbody body;

    private bool isDead;

    public bool IsDead => isDead;

    private void Reset()
    {
        body = GetComponent<Rigidbody>();
    }

    public void Move(float moveZ)
    {
        if (isDead)
            return;

        Vector3 velocity = body.linearVelocity;
        body.linearVelocity = new Vector3(velocity.x, velocity.y, moveZ * speed);
    }

    public void Die()
    {
        if (isDead)
            return;

        isDead = true;
        body.linearVelocity = Vector3.zero;

        Debug.Log("Player mort");

        // TODO : ecran de game over, animation, son
    }
}