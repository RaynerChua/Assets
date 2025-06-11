using UnityEngine;

public class InstantDeath : MonoBehaviour
{
    [System.Obsolete]
    private void OnTriggerEnter(Collider other)
    {
        PlayerBehaviour player = other.GetComponent<PlayerBehaviour>();
        if (player != null)
        {
            // Inflict massive damage to guarantee death
            player.ModifyHealth(-9999);

            // Use reflection of health state (if implemented)
            // OR manually check if player is "dead" and teleport
            var spawn = player.GetType()
                              .GetField("spawnPoint", System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Instance)
                              ?.GetValue(player) as Transform;

            if (spawn != null)
            {
                other.transform.position = spawn.position;

                // Reset velocity if Rigidbody exists
                Rigidbody rb = other.GetComponent<Rigidbody>();
                if (rb != null)
                    rb.velocity = Vector3.zero;
            }
        }
    }
}
