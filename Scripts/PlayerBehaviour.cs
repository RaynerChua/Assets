using System;
using UnityEngine;

public class PlayerBehaviour : MonoBehaviour
{
    private bool isInHazardZone = false;
    private float healthDrainTimer = 0f;
    public float healthDrainInterval = 5f; // Time interval for health drain in seconds
    // Player's maximum health
    int maxHealth = 100;
    // Player's current health
    int currentHealth = 100;
    // Player's current score
    public int currentScore = 0;
    // Flag to check if the player can interact with objects
    bool canInteract = false;
    // Stores the current coin object the player has detected
    CoinBehaviour currentCoin = null;

    DoorBehaviour currentDoor = null;

    [SerializeField]
    GameObject projectile;

    [SerializeField]    // The Interact callback for the Interact Input Action
    Transform spawnPoint;

    [SerializeField]
    public float firestrength = 0f;


    // The Interact callback for the Interact Input Action
    // This method is called when the player presses the interact button
    public void OnInteract()
    {
        // Check if the player can interact with objects
        if (canInteract)
        {
            // Check if the player has detected a coin or a door
            if (currentCoin != null)
            {
                Debug.Log("Interacting with coin");
                // Call the Collect method on the coin object
                // Pass the player object as an argument
                currentCoin.Collect(this);
            }
            else if (currentDoor != null)
            {
                Debug.Log("Interacting with door");
                // Call the Interact method on the door object
                // This allows the player to open or close the door
                currentDoor.Interact();
            }
        }
    }

    // Method to modify the player's score
    // This method takes an integer amount as a parameter
    // It adds the amount to the player's current score
    // The method is public so it can be accessed from other scripts
    public void ModifyScore(int amt)
    {
        // Increase currentScore by the amount passed as an argument
        currentScore += amt;
    }

    // Method to modify the player's health
    // This method takes an integer amount as a parameter
    // It adds the amount to the player's current health
    // The method is public so it can be accessed from other scripts
    public void ModifyHealth(int amount)
    {
        currentHealth += amount;

    if (currentHealth > maxHealth)
        currentHealth = maxHealth;
    
    if (currentHealth < 0)
        currentHealth = 0;
        Debug.Log("Current Health: " + currentHealth);
    }

    // Collision Callback for when the player collides with another object
    void OnCollisionStay(Collision collision)
    {
        // Check if the player collides with an object tagged as "HealingArea"
        // If it does, call the RecoverHealth method on the object
        // Pass the player object as an argument
        // This allows the player to recover health when in a healing area
        if (collision.gameObject.CompareTag("HealingArea"))
        {
            collision.gameObject.GetComponent<RecoveryBehaviour>().RecoverHealth(this);
        }
    }
    public void OnFire()
    {
        GameObject newProjectile = Instantiate(projectile, spawnPoint.position, spawnPoint.rotation);
        Vector3 fireForce = spawnPoint.forward * firestrength;
        newProjectile.GetComponent<Rigidbody>().AddForce(fireForce);
    }

    // Trigger Callback for when the player enters a trigger collider
    void OnTriggerEnter(Collider other)
    {
        Debug.Log(other.gameObject.name);
        // Check if the player detects a trigger collider tagged as "Collectible" or "Door"
        if (other.CompareTag("Collectible"))
        {
            // Set the canInteract flag to true
            // Get the CoinBehaviour component from the detected object
            canInteract = true;
            currentCoin = other.GetComponent<CoinBehaviour>();
        }
        else if (other.CompareTag("Door"))
        {
            // Set the canInteract flag to true
            // Get the DoorBehaviour component from the detected object
            canInteract = true;
            currentDoor = other.GetComponent<DoorBehaviour>();
        }
        else if (other.CompareTag("HazardZone"))
        {
            isInHazardZone = true;
            healthDrainTimer = 0f; // Reset the health drain timer
            Debug.Log("Entered Hazard Zone");
        }
    }

    // Trigger Callback for when the player exits a trigger collider
    void OnTriggerExit(Collider other)
    {
        // Check if the player has a detected coin or door
        if (currentCoin != null)
        {
            // If the object that exited the trigger is the same as the current coin
            if (other.gameObject == currentCoin.gameObject)
            {
                // Set the canInteract flag to false
                // Set the current coin to null
                // This prevents the player from interacting with the coin
                canInteract = false;
                currentCoin = null;
            }
            if (currentDoor != null && other.gameObject == currentDoor.gameObject)
            {
                canInteract = false;
                currentDoor = null; // Set the current door to null
            }
            if (other.CompareTag("HazardZone"))
            {
                isInHazardZone = false;
            }
        }
    }
    
    void Update()
    {
        Debug.Log("Hazard damage. Current health: " + currentHealth);

        if (isInHazardZone)
        {
            healthDrainTimer += Time.deltaTime;

            if (healthDrainTimer >= healthDrainInterval)
            {
                healthDrainTimer = 0f;
                ModifyHealth(-1);
                Debug.Log("Hazard damage. Current health: " + currentHealth);
            }
        }
    }
}