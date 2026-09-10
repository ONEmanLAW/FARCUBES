using UnityEngine;

public class InputControllerPlayer : MonoBehaviour
{
    //public float speed = 1;
    public Player player;

    // Update is called once per frame
    void Update()
    {
        //float moveX = 0f;

        if(Input.GetKey(KeyCode.RightArrow))
        {
            player.Move(1f);
        }
        else if(Input.GetKey(KeyCode.LeftArrow))
        {
            player.Move(-1f);
        }

        
    }
}
