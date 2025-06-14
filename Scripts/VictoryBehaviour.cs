
/* 
* Author: Chua Yi Xuan Rayner
* Date: 9/6/25 - 14/6/25
* Description: A simple script to handle victory token collection and score increment.
* When the player collects a victory token, their score is increased by a specified value.
*/

using UnityEngine;

public class VictoryBehaviour : MonoBehaviour
{
    [SerializeField] int tokenValue = 1000; // Defines the score value (1k) awarded upon collecting the token

    public void Collect(PlayerBehaviour player) // Method called when the player collects the victory token
    {
        {
            player.ModifyScore(tokenValue); // Increases the player's score by the token's value
            Debug.Log("Victory token collected!"); // Logs confirmation of the collection event
            Destroy(gameObject); // Destroy the victory token object from scene
        }
    }
}
