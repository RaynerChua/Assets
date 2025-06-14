/* 
* Author: Chua Yi Xuan Rayner
* Date: 9/6/25 - 14/6/25
* Description: This script is to facilitate the opening & losing of the doors in the game as well as playing the door opening sound effect.
*/

using UnityEngine;
using UnityEngine.Rendering;

public class DoorBehaviour : MonoBehaviour
{
    AudioSource doorAudioSource; // Reference to the AudioSource component for playing sound effects
    private bool isOpen = false; // Track whether the door is currently open or closed

    void Start()
    {
        // Attempt to get the AudioSource component attached to the door object
        // If the component is not found, log an error message
        doorAudioSource = GetComponent<AudioSource>();
        if (doorAudioSource == null)
        {
            Debug.LogError("AudioSource component is missing on the door object.");
        }
    }

    //called when the player interacts with the door
    public void Interact()
    {
        //get the current rotation of the door (indegrees)
        Vector3 doorRotation = transform.eulerAngles;
        if (doorRotation.y == 0f)// if door is closed (def rotation)
        {
            doorRotation.y += 90f; // rotate the door 90 degrees on Y to open it
            transform.eulerAngles = doorRotation; // apply the new rotation to the door
            isOpen = true; //update the door state to open
        }
        else if (doorRotation.y == 90f) // if door is open (90 degrees rotation)
        {
            doorRotation.y = 0f; //reset the door rotation back to 0 degrees to close it
            transform.eulerAngles = doorRotation; //apply closed rotation
            isOpen = false; //update the door state to closed
        }

        // Only play sound when door is opening & audio source is available
        if (isOpen && doorAudioSource != null)
        {
            doorAudioSource.Play();
        }
    }
}
