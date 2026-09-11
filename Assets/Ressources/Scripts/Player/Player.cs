using System;
using UnityEngine;

public class Player : MonoBehaviour
{
    // Event statique : l'UI peut s'abonner avant meme que le joueur existe.
    public static event Action OnPlayerDied;
    public static event Action OnPlayerWon;

    [SerializeField] private float speed = 5f;
    [SerializeField] private Rigidbody body;

    private bool isDead;
    private bool hasWon;

    public bool IsDead => isDead;
    public bool HasWon => hasWon;

    private void Reset()
    {
        body = GetComponent<Rigidbody>();
    }

    public void Move(float moveZ)
    {
        // Une partie terminee, gagnee ou perdue, bloque le deplacement.
        if (isDead || hasWon)
            return;

        // On preserve x et y : la gravite continue de s'appliquer
        // pendant le deplacement lateral.
        Vector3 velocity = body.linearVelocity;
        body.linearVelocity = new Vector3(velocity.x, velocity.y, moveZ * speed);
    }

    public void Die()
    {
        // On ne meurt plus une fois la partie gagnee.
        if (isDead || hasWon)
            return;

        isDead = true;
        body.linearVelocity = Vector3.zero;

        // ?. : ne declenche rien si personne n'est abonne.
        OnPlayerDied?.Invoke();
    }

    public void Win()
    {
        if (hasWon || isDead)
            return;

        hasWon = true;
        body.linearVelocity = Vector3.zero;

        OnPlayerWon?.Invoke();
    }
}
