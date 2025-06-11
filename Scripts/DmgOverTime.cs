using UnityEngine;
using System.Collections;

public class DmgOverTime : MonoBehaviour
{
    [SerializeField]
    int damageAmount = 5;

    [SerializeField]
    float damageInterval = 2f;

    private Coroutine damageCoroutine;

    private void OnTriggerEnter(Collider other)
    {
        PlayerBehaviour player = other.GetComponent<PlayerBehaviour>();
        if (player != null)
        {
            damageCoroutine = StartCoroutine(ApplyDamageOverTime(player));
        }
    }

    private void OnTriggerExit(Collider other)
    {
        PlayerBehaviour player = other.GetComponent<PlayerBehaviour>();
        if (player != null && damageCoroutine != null)
        {
            StopCoroutine(damageCoroutine);
            damageCoroutine = null;
        }
    }

    private IEnumerator ApplyDamageOverTime(PlayerBehaviour player)
    {
        while (true)
        {
            player.ModifyHealth(-damageAmount);
            yield return new WaitForSeconds(damageInterval);
        }
    }
}
