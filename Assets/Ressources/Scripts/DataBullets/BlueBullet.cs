using UnityEngine;

public class BlueBullet : MonoBehaviour
{
    [SerializeField] private float speed = 5f;
    [SerializeField] private Vector3 direction = Vector3.down;

    private void Update()
    {
        transform.position += direction.normalized * (speed * Time.deltaTime);
    }
}