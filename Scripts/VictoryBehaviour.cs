
/* 
* Author: Chua Yi Xuan Rayner
* Date: 9/6/25 - 14/6/25
* Description: A simple script to handle victory token collection and score increment.
* When the player collects a victory token, their score is increased by a specified value.
*/

using UnityEngine;

public class VictoryBehaviour : MonoBehaviour
{
    [SerializeField] int tokenValue = 1000;

    public void Collect(PlayerBehaviour player)
    {
        player.ModifyScore(tokenValue);
        Debug.Log("Victory token collected!");
        Destroy(gameObject); // Destroy the victory token object
    }
}
