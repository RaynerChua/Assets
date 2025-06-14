/* 
* Author: Chua Yi Xuan Rayner
* Date: 9/6/25 - 14/6/25
* Description: This is a simple script for the instant death hazard zone.
*/

using UnityEngine;

public class InstantDeath : MonoBehaviour
{
    private void OnTriggerEnter(Collider other) // Triggered when another collider enters the hazard's trigger zone
    {
        PlayerBehaviour player = other.GetComponent<PlayerBehaviour>(); // Attempt to get the PlayerBehaviour component
        if (player != null) // Proceed only if the colliding object is the player
        {
            // Instantly drop health to zero
            player.ModifyHealth(-player.maxHealth);
        }
    }
}
