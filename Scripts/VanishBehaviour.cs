/* 
* Author: Chua Yi Xuan Rayner
* Date: 9/6/25 - 14/6/25
* Description: This script handles the vanishing & reappearing behaviour of gameObjects, 
objects in vanish have their collider turned off, when visible, the collider is turned on.
* The object will be visible for a set duration, then invisible for another set duration, and this cycle repeats.
*/

using UnityEngine; 

public class VanishBehaviour : MonoBehaviour
{
    public float visibleDuration = 2f;    // Time the block is visible (seconds)
    public float invisibleDuration = 2f;  // Time the block is invisible (seconds)

    private Renderer blockRenderer; // Reference to the object's Renderer component (controls visibility)
    private Collider blockCollider; // Reference to the object's Collider (controls interaction)
    private float timer; // Tracks countdown until visibility toggles
    private bool isVisible = true; // Tracks whether the object is currently visible or not

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        blockRenderer = GetComponent<Renderer>(); // Retrieve the object's Renderer component
        blockCollider = GetComponent<Collider>(); // Retrieve the object's Collider component
        timer = visibleDuration;  // Initialize the timer with the visible duration
    }

    // Update is called once per frame
    void Update()
    {
        timer -= Time.deltaTime; // Decrease the timer based on elapsed time
        if (isVisible && timer <= 0f) // If object is visible and timer expires
        {
            SetVisible(false); // Make the object invisible
            timer = invisibleDuration; // Reset timer to the invisible duration
        }
        else if (!isVisible && timer <= 0f) // If object is invisible and timer expires
        {
            SetVisible(true); // Make the object visible again
            timer = visibleDuration; // Reset timer to the visible duration
        }
    }
    
    // Toggles visibility and collider state
    void SetVisible(bool visible)
    {
        isVisible = visible;  // Update visibility status
        blockRenderer.enabled = visible; // Enable or disable rendering
        blockCollider.enabled = visible; // Enable or disable collision detection
    }
}
