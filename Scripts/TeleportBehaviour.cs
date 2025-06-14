/* 
* Author: Chua Yi Xuan Rayner
* Date: 9/6/25 - 14/6/25
* Description: A simple script to handle teleportation of the player when they enter a trigger zone.
*/

using UnityEngine;

public class TeleportBehaviour : MonoBehaviour
{
    [SerializeField] private Transform teleportTarget; // Destination where the player will be teleported

    private void OnTriggerEnter(Collider other) // Triggered when an object enters the teleport zone
    {
        if (other.CompareTag("Player") && teleportTarget != null) // Ensure the object is the player and a valid teleport target exists
        {
            CharacterController cc = other.GetComponent<CharacterController>(); // Get the player's CharacterController component
            if (cc != null) // Only proceed if the player has a CharacterController component
            {
                cc.enabled = false; // Temporarily disable to prevent physics issues during teleportation
                other.transform.position = teleportTarget.position; // Instantly move the player to the teleport destination
                cc.enabled = true; // Re-enable the CharacterController after teleporting
                Debug.Log("Player teleported!"); // Log the teleportation for debugging
            }
        }
    }
}
