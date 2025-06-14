/* 
* Author: Chua Yi Xuan Rayner
* Date: 9/6/25 - 14/6/25
* Description: This script is meant to call a message from the UI when a specific gameObject is destroyed, its linked to the hiddenPath script.
*/

using System.Collections;
using TMPro;
using UnityEngine;

public class MessageDisplayManager : MonoBehaviour
{
    public static MessageDisplayManager Instance;

    private void Awake()
    {
        if (Instance == null)
            Instance = this;
        else
            Destroy(gameObject);
    }

    public void ShowMessage(TextMeshProUGUI message, float duration)
    {
        StartCoroutine(HideAfterDelay(message, duration));
    }

    private IEnumerator HideAfterDelay(TextMeshProUGUI message, float delay)
    {
        message.gameObject.SetActive(true);
        yield return new WaitForSeconds(delay);
        message.gameObject.SetActive(false);
        Debug.Log("Message hidden via MessageDisplayManager.");
    }
}
