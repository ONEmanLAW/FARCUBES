using UnityEngine;

public class Player : MonoBehaviour
{
    
    public float speed = 1;
    public Rigidbody Rb;


    // Update is called once per frame
    
    public void Move(float moveX)
    {
        Rb.linearVelocity = new Vector3(moveX * speed, Rb.linearVelocity.y, Rb.linearVelocity.z);
    }
}
