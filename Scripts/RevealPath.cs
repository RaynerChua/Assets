/* 
* Author: Chua Yi Xuan Rayner
* Date: 9/6/25 - 14/6/25
* Description: A simple script to reveal a hidden path when a special token is collected.
*/

using TMPro; // Enables use of TextMeshPro for UI text display
using UnityEngine;

public class RevealPathToken : MonoBehaviour
{
    [SerializeField] private GameObject hiddenPath; // Reference to the hidden path GameObject to be revealed
    [SerializeField] private TextMeshProUGUI revealMsgText; // UI message displayed when the path is revealed

    public void Collect() // Called when the player collects the special token
    {
        if (hiddenPath != null) // Check if a hidden path has been assigned
        {
            hiddenPath.SetActive(true); // Reveal the hidden path by activating its GameObject
            Debug.Log("Hidden path revealed!"); // Log feedback for debugging
        }
        // If a UI message is assigned and the MessageDisplayManager instance exists
        if (revealMsgText != null && MessageDisplayManager.Instance != null)
        {
            MessageDisplayManager.Instance.ShowMessage(revealMsgText, 3f); // Display the message for 3 seconds
        }

        Destroy(gameObject); // Destroy token immediately after collection
    }
}
