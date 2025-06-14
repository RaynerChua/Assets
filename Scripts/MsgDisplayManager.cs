/* 
* Author: Chua Yi Xuan Rayner
* Date: 9/6/25 - 14/6/25
* Description: This script is meant to call a message from the UI when a specific gameObject is destroyed, its linked to the hiddenPath script.
*/

using System.Collections; // Enables use of Coroutines (IEnumerator and WaitForSeconds)
using TMPro; // Allows interaction with TextMeshProUGUI components
using UnityEngine; 

public class MessageDisplayManager : MonoBehaviour
{
    public static MessageDisplayManager Instance; // Singleton instance for global access

    private void Awake()
    {
        // Ensure only one instance exists; if a duplicate is found, destroy it
        if (Instance == null)
            Instance = this;
        else
            Destroy(gameObject);
    }

    // Public method to trigger a temporary UI message
    // Takes a TextMeshProUGUI component and how long it should stay visible
    public void ShowMessage(TextMeshProUGUI message, float duration)
    {
        StartCoroutine(HideAfterDelay(message, duration)); // Start coroutine to manage visibility timing
    }
    
     // Coroutine that shows the message, waits, and then hides it
    private IEnumerator HideAfterDelay(TextMeshProUGUI message, float delay)
    {
        message.gameObject.SetActive(true); // Make the message visible
        yield return new WaitForSeconds(delay); // Wait for the specified duration
        message.gameObject.SetActive(false); // Hide the message
        Debug.Log("Message hidden via MessageDisplayManager."); // Log for debugging purposes
    }
}
