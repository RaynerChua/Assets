using UnityEngine;

public class ConveyorBelt : MonoBehaviour
{
    [SerializeField] private Vector3 direction = Vector3.forward; // Direction of the conveyor belt
    [SerializeField] private float speed = 5f; // Speed of the conveyor belt
    

    private void OnTriggerStay(Collider other)
    {
        Rigidbody rb = other.attachedRigidbody;
        if (rb != null)
        {
            Vector3 movement = speed * Time.deltaTime * direction.normalized;
            rb.MovePosition(rb.position + movement);
        }
    }
}

