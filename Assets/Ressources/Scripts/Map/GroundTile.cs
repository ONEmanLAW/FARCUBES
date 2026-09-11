using UnityEngine;

public class GroundTile : MonoBehaviour
{
    private void Update()
    {
        if (MapScroller.Instance == null)
            return;

        transform.position += MapScroller.Instance.Velocity * Time.deltaTime;
    }
}