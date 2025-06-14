/* 
* Author: Chua Yi Xuan Rayner
* Date: 9/6/25 - 14/6/25
* Description: This is a simple script for the instant death hazard zone.
*/

using UnityEngine;

public class InstantDeath : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        PlayerBehaviour player = other.GetComponent<PlayerBehaviour>();
        if (player != null)
        {
            // Instantly drop health to zero
            player.ModifyHealth(-player.maxHealth);
        }
    }
}
