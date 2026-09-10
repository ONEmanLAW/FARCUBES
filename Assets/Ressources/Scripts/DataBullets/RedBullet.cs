using UnityEngine;

// Balle rapide, trajectoire droite.
// Identique a BlueBullet pour l'instant : seule la vitesse change,
// et elle vient du ScriptableObject. La classe existe pour accueillir
public class RedBullet : Bullet
{
    protected override Vector3 GetPosition(float time)
    {
        return GetForwardPosition(time);
    }
}