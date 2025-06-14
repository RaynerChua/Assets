/* 
* Author: Chua Yi Xuan Rayner
* Date: 9/6/25 - 14/6/25
* Description: A simple script to handle teleportation of the player when they enter a trigger zone.
*/

using UnityEngine;

public class TeleportBehaviour : MonoBehaviour
{
    [SerializeField] private Transform teleportTarget;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") && teleportTarget != null)
        {
            CharacterController cc = other.GetComponent<CharacterController>();
            if (cc != null)
            {
                cc.enabled = false; // Temporarily disable to safely move
                other.transform.position = teleportTarget.position;
                cc.enabled = true;
                Debug.Log("Player teleported!");
            }
        }
    }
}
