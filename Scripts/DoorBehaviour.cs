/* 
* Author: Chua Yi Xuan Rayner
* Date: 9/6/25 - 14/6/25
* Description: This script is to facilitate the opening & losing of the doors in the game as well as playing the door opening sound effect.
*/

using UnityEngine;
using UnityEngine.Rendering;

public class DoorBehaviour : MonoBehaviour
{
    AudioSource doorAudioSource;
    private bool isOpen = false;

    void Start()
    {
        doorAudioSource = GetComponent<AudioSource>();
        if (doorAudioSource == null)
        {
            Debug.LogError("AudioSource component is missing on the door object.");
        }
    }

    public void Interact()
    {
        Vector3 doorRotation = transform.eulerAngles;
        if (doorRotation.y == 0f)
        {
            doorRotation.y += 90f;
            transform.eulerAngles = doorRotation;
            isOpen = true;
        }
        else if (doorRotation.y == 90f)
        {
            doorRotation.y = 0f;
            transform.eulerAngles = doorRotation;
            isOpen = false;
        }

        // Only play sound when door is opening
        if (isOpen && doorAudioSource != null)
        {
            doorAudioSource.Play();
        }
    }
}
