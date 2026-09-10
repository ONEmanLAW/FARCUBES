using UnityEngine;

// Balle lente, trajectoire droite.
public class BlueBullet : Bullet
{
    protected override Vector3 GetPosition(float time)
    {
        return GetForwardPosition(time);
    }
}