using System.Collections;
using TMPro;
using UnityEngine;

public class RevealPathToken : MonoBehaviour
{
    [SerializeField] GameObject hiddenPath;
    [SerializeField] TextMeshProUGUI revealMsgText;

    public void Collect()
    {
        if (hiddenPath != null)
        {
            hiddenPath.SetActive(true); // Reveal the path
            Debug.Log("Hidden path revealed!");
        }
        if (revealMsgText != null)
        {
            revealMsgText.gameObject.SetActive(true); // Show the message UI
            StartCoroutine(HideMsg());
        }

    }

    public IEnumerator HideMsg()
    {
        yield return new WaitForSeconds(3f); // Wait for 5 seconds
        if (revealMsgText != null)
        {
            revealMsgText.gameObject.SetActive(false); // Hide the message UI
        }
        Debug.Log("Message hidden after 2 seconds.");
        Destroy(gameObject); // Remove the token after use
    }
}
