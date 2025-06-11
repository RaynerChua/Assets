using System;
using UnityEngine;
using TMPro;

public class PlayerBehaviour : MonoBehaviour
{

    // Player's maximum health
    public int maxHealth = 100;
    // Player's current health
    public int currentHealth = 100;
    // Player's current score
    public int currentScore = 0;
    // Flag to check if the player can interact with objects
    bool canInteract = false;
    // Stores the current coin object the player has detected
    CoinBehaviour currentCoin = null;
    DoorBehaviour currentDoor = null;

    [SerializeField]
    GameObject projectile;

    [SerializeField]
    public Transform spawnPoint;

    [SerializeField]
    public float firestrength = 0f;

    [SerializeField]
    TextMeshProUGUI scoreText;

    void Start()
    {
        scoreText.text = "SCORE:" + currentScore.ToString();
    }

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
         scoreText.text = "SCORE:" + currentScore.ToString();
    }

    // Method to modify the player's health
    // This method takes an integer amount as a parameter
    // It adds the amount to the player's current health
    // The method is public so it can be accessed from other scripts
    public void ModifyHealth(int amount)
    {
        int previousHealth = currentHealth;
        currentHealth += amount;

        if (currentHealth > maxHealth)
            currentHealth = maxHealth;

        if (currentHealth <= 0)
        {
            currentHealth = 0;
            Debug.Log("Player is dead!");
            // Optionally, you can call a method to handle player death
            // For example, respawn the player or end the game
            Respawn();
        }
        else if (currentHealth < previousHealth)
        {
            Debug.Log("Damage taken: " + (previousHealth - currentHealth) + " HP | Current Health: " + currentHealth);
        }

        int recoveredAmount = currentHealth - previousHealth;
        Debug.Log("Recovered: " + recoveredAmount + " HP | Current Health: " + currentHealth);
    }

    // Collision Callback for when the player collides with another object
    public void OnCollisionStay(Collision collision)
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

    }

    // Trigger Callback for when the player exits a trigger collider
    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Collectible") && currentCoin != null && other.gameObject == currentCoin.gameObject)
        {
            // Set the canInteract flag to false
            // Clear the currentCoin reference
            canInteract = false;
            currentCoin = null;
        }
        if (other.CompareTag("Door") && currentDoor != null && other.gameObject == currentDoor.gameObject)
        {
            // Set the canInteract flag to false
            // Clear the currentDoor reference
            canInteract = false;
            currentDoor = null;
        }
    }

    public void Respawn()
    {
        Rigidbody rb = GetComponent<Rigidbody>();

        if (rb != null)
        {
            rb.Sleep(); // Reset motion safely
        }

        if (spawnPoint != null)
        {
            transform.position = spawnPoint.position;
        }
        else
        {
            Debug.LogWarning("Spawn point not assigned!");
        }

        currentHealth = maxHealth; 

    }

}