using UnityEngine;

public class InstantDeath : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        PlayerBehaviour player = other.GetComponent<PlayerBehaviour>();
        if (player != null)
        {
            // Instantly drop health to zero
            player.ModifyHealth(-player.maxHealth);
        }
    }
}
