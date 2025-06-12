using UnityEngine;

public class VictoryBehaviour : MonoBehaviour
{
    [SerializeField] int tokenValue = 1000;

    public void Collect(PlayerBehaviour player)
    {
        player.ModifyScore(tokenValue);
        Debug.Log("Victory token collected!");
        Destroy(gameObject); // Destroy the victory token object
    }
}
