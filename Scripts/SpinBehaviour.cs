using UnityEngine;

public class SpinBehaviour : MonoBehaviour
{
    [SerializeField]
    private Vector3 rotationSpeed = new Vector3(0, 100, 0); // Spins around Y-axis by default

    void Update()
    {
        transform.Rotate(rotationSpeed * Time.deltaTime);
    }
}
