using UnityEngine;

[CreateAssetMenu(fileName = "BulletStats", menuName = "Bullets/Bullet Stats")]
public class BulletStats : ScriptableObject
{
    [SerializeField] private float speed = 5f;
    [SerializeField] private int damage = 1;

    public float Speed => speed;
    public int Damage => damage;
}