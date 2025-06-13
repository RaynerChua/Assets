using UnityEngine;

public class RevealPathToken : MonoBehaviour
{
    [SerializeField] GameObject hiddenPath;

    public void Collect()
    {
        if (hiddenPath != null)
        {
            hiddenPath.SetActive(true); // Reveal the path
            Debug.Log("Hidden path revealed!");
        }

        Destroy(gameObject); // Remove the token after use
    }
}
