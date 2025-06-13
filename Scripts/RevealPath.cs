using TMPro;
using UnityEngine;

public class RevealPathToken : MonoBehaviour
{
    [SerializeField] private GameObject hiddenPath;
    [SerializeField] private TextMeshProUGUI revealMsgText;

    public void Collect()
    {
        if (hiddenPath != null)
        {
            hiddenPath.SetActive(true);
            Debug.Log("Hidden path revealed!");
        }

        if (revealMsgText != null && MessageDisplayManager.Instance != null)
        {
            MessageDisplayManager.Instance.ShowMessage(revealMsgText, 3f);
        }

        Destroy(gameObject); // Destroy token immediately
    }
}
