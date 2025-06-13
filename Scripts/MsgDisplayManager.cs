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
