/* 
* Author: Chua Yi Xuan Rayner
* Date: 9/6/25 - 14/6/25
* Description: This script is to facilitate the vertical movement of blocks in the game using Mathf.PingPong to create an up & down motion.
*/

using UnityEngine;

public class MovingBlockBehaviour : MonoBehaviour
{
    public float moveHeight = 2f;
    public float moveSpeed = 1f;
    private Vector3 startPosition;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        if (CompareTag("MovingBlock"))
        {
            startPosition = transform.position;
        }
    }

    // Update is called once per frame
    void Update()
    {
         if (CompareTag("MovingBlock"))
        {
            float newY = Mathf.PingPong(Time.time * moveSpeed, moveHeight);
            transform.position = new Vector3(startPosition.x, startPosition.y + newY, startPosition.z);
        }
    }
}
