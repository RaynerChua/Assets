/* 
* Author: Chua Yi Xuan Rayner
* Date: 9/6/25 - 14/6/25
* Description: A simple script to make any GameObject spin continuously.
*/

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
