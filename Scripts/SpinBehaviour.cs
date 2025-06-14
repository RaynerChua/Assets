/* 
* Author: Chua Yi Xuan Rayner
* Date: 9/6/25 - 14/6/25
* Description: A simple script to make any GameObject spin continuously.
*/

using UnityEngine;

public class SpinBehaviour : MonoBehaviour
{
    [SerializeField]
    // Allows modification of the rotation speed from the Inspector
    private Vector3 rotationSpeed = new Vector3(0, 100, 0); // Defines rotation speed (default spins around Y-axis)

    void Update() // Called once per frame
    {
        transform.Rotate(rotationSpeed * Time.deltaTime); // Rotates the object smoothly over time
    }
}
