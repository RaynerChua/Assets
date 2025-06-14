
/* 
* Author: Chua Yi Xuan Rayner
* Date: 9/6/25 - 14/6/25
* Description: This script is to facilitate the damage over time effect for the toxic hazard gameObject.
*/

using UnityEngine;
using System.Collections;

public class DmgOverTime : MonoBehaviour
{
    [SerializeField]
    int damageAmount = 5; // Amount of damage to apply each interval

    [SerializeField]
    float damageInterval = 2f; // Time interval between damage applications

    private Coroutine damageCoroutine; // Keeps a reference to the running Coroutine so it can be stopped later

    private void OnTriggerEnter(Collider other) //Called when another collider enters this object's trigger zone
    {
        // Tries to get player behaviour from object & proceed if collider belongs to player
        //Starts damaging player over set time interval
        PlayerBehaviour player = other.GetComponent<PlayerBehaviour>();
        if (player != null)
        {
            damageCoroutine = StartCoroutine(ApplyDamageOverTime(player));
        }
    }
    
    // Called when another collider exits the object's trigger zone
    private void OnTriggerExit(Collider other)
    {
        //Try to get playerbehaviour again, if its the player & couroutine is running stop damage loop,
        // and reset the coroutine reference
        PlayerBehaviour player = other.GetComponent<PlayerBehaviour>();
        if (player != null && damageCoroutine != null)
        {
            StopCoroutine(damageCoroutine); // Stops the Coroutine that applies damage
            damageCoroutine = null; // Resets the Coroutine reference
        }
    }
    
    // Coroutine that applies damage repeatedly at specified intervals
    private IEnumerator ApplyDamageOverTime(PlayerBehaviour player)
    {
        while (true) // Infinite loop to keep applying damage until stopped manually
        {
            player.ModifyHealth(-damageAmount); //Applies negative health to player
            yield return new WaitForSeconds(damageInterval); //Waits for the specified interval before applying damage again
        }
    }
}
