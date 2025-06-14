/* 
* Author: Chua Yi Xuan Rayner
* Date: 9/6/25 - 14/6/25
* Description: This script is to facilitate the vertical movement of blocks in the game using Mathf.PingPong to create an up & down motion.
*/

using UnityEngine;

public class MovingBlockBehaviour : MonoBehaviour
{
    public float moveHeight = 2f; // Maximum vertical distance the block will move
    public float moveSpeed = 1f; // Speed at which the block moves
    private Vector3 startPosition; // Stores the initial position of the block

    // Called once when the script starts, before the first frame update
    void Start()
    {
        // Ensures this logic only runs on GameObjects tagged "MovingBlock"
        if (CompareTag("MovingBlock"))
        {
            startPosition = transform.position; // Record the starting position of the block
        }
    }

    // Update is called once per frame
    void Update()
    {
        // Only apply movement if the GameObject is tagged "MovingBlock"
         if (CompareTag("MovingBlock"))
        {
            // Calculate a new Y position using Mathf.PingPong to create a smooth up-down motion
            float newY = Mathf.PingPong(Time.time * moveSpeed, moveHeight);

            // Update the block's position by modifying only the Y-axis
            transform.position = new Vector3(startPosition.x, startPosition.y + newY, startPosition.z);
        }
    }
}
