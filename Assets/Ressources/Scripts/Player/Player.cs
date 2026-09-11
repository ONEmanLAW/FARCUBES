using System;
using UnityEngine;

public class Player : MonoBehaviour
{
    // Event statique : l'UI peut s'abonner avant meme que le joueur existe.
    public static event Action OnPlayerDied;

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

        // On preserve x et y : la gravite continue de s'appliquer
        // pendant le deplacement lateral.
        Vector3 velocity = body.linearVelocity;
        body.linearVelocity = new Vector3(velocity.x, velocity.y, moveZ * speed);
    }

    public void Die()
    {
        if (isDead)
            return;

        isDead = true;
        body.linearVelocity = Vector3.zero;

        // ?. : ne declenche rien si personne n'est abonne.
        OnPlayerDied?.Invoke();
    }
}