
/* 
* Author: Chua Yi Xuan Rayner
* Date: 9/6/25 - 14/6/25
* Description: This script covers a majority of actions the player can do in the game, most of player UI controls are handled here, 
allows interaction with gameObjects by pressing E, health & score modification can be done here as well, collision triggers onEnter/exit,
collectible counter is handled here as well, respawning the player when they die, and displaying the death message UI.
*/

using System;
using UnityEngine;
using TMPro; // For working with TextMeshProUGUI components
using UnityEngine.UI; // Enables usage of Unity UI components (e.g., GameObject, Button)
using Microsoft.Unity.VisualStudio.Editor; 
using System.Collections; // Required to run Coroutines (like IEnumerator and WaitForSeconds)

public class PlayerBehaviour : MonoBehaviour
{
    // Max health cap for the player
    public int maxHealth = 100;
    // Current health status
    public int currentHealth = 100;
    // Player's current score value
    public int currentScore = 0;

    // Flag to check if the player can interact with objects
    bool canInteract = false;

    // references to the current coin and door the player is interacting with
    CoinBehaviour currentCoin = null;
    DoorBehaviour currentDoor = null;


    [SerializeField]
    // Point where the player respawns on death
    public Transform spawnPoint;

    [SerializeField]
    // UI element that displays the player's score
    TextMeshProUGUI scoreText;

    [SerializeField]
    // UI element that displays the player's health
    TextMeshProUGUI healthText;

    [SerializeField]
    // UI GameObject to show when the player dies
    GameObject deathMsgUI;

    [SerializeField]
    // UI GameObject shown when the player wins
    GameObject congratsTextUI;

    [SerializeField]
    // UI text for the coin counter
    private TextMeshProUGUI coinCountText;

    [SerializeField]
    // Total coins required to win or finish the level
    private int totalCoins = 10;
    // Number of coins the player has collected so far
    private int collectedCoins = 0;

    void Start()
    {
        // Initialize score and health UI with the player's starting values
        scoreText.text = "SCORE:" + currentScore.ToString();
        healthText.text = "HEALTH: " + currentHealth.ToString();

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
        currentHealth += amount;

        if (currentHealth > maxHealth)
            currentHealth = maxHealth; // Cap health at max

        if (currentHealth <= 0)
        {
            currentHealth = 0;
            Debug.Log("Player is dead!");

            if (deathMsgUI != null)
                // If the death message UI is assigned, activate it
                deathMsgUI.SetActive(true);

            StartCoroutine(HideDeathMsg()); // Begin timer to hide death message

            Respawn(); // Reset player's position and health
        }

        healthText.text = "HEALTH: " + currentHealth.ToString(); // Update health UI
    }

    IEnumerator HideDeathMsg()
    {
        yield return new WaitForSeconds(2f); // Wait 2 seconds
        if (deathMsgUI != null)
        {
            deathMsgUI.SetActive(false); // Hide death message
        }
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
        if (other.CompareTag("HealingArea"))
        {
            // Call the RecoverHealth method on the HealingArea object
            // Pass the player object as an argument
            other.GetComponent<RecoveryBehaviour>().RecoverHealth(this);
        }
        else if (other.CompareTag("VictoryToken"))
        {
            if (congratsTextUI != null)
            {
                // If the victory token is detected, activate the congrats text UI
                congratsTextUI.SetActive(true);
                StartCoroutine(HideCongratsMsg());
            }
            other.GetComponent<VictoryBehaviour>().Collect(this); // Call token collection logic
            Debug.Log("Congratulations! You have completed the game!");
        }
        else if (other.CompareTag("RevealToken"))
        {
            other.GetComponent<RevealPathToken>().Collect(); // Reveal hidden path or feature
        }
    }

    IEnumerator HideCongratsMsg()
    {
        yield return new WaitForSeconds(10f); // Show victory message for 10 seconds
        if (congratsTextUI != null)
        {
            congratsTextUI.SetActive(false); // Then hide it
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
        Rigidbody rb = GetComponent<Rigidbody>(); // Access Rigidbody for velocity resets

        if (spawnPoint != null)
        {
            transform.position = spawnPoint.position; // Teleport player to spawn location
            Debug.Log("Teleporting to: " + spawnPoint.position);

            if (rb != null)
            {
                rb.linearVelocity = Vector3.zero; // Stop current motion
                rb.angularVelocity = Vector3.zero; // Stop rotation
                rb.Sleep(); // Pause & stabilize physics motion to prevent jitter
            }

            // Ensure physics reflects the new position
            Physics.SyncTransforms();
        }
        else
        {
            Debug.LogWarning("Spawn point not assigned!");
        }

        currentHealth = maxHealth; // Reset health to max on respawn
        healthText.text = "HEALTH: " + currentHealth.ToString(); // Update health UI
        Debug.Log("Player respawned and health reset.");
    }

    public void IncrementCoinCount()
    {
        collectedCoins++; // Count collected coin
        coinCountText.text = $"Coins: {collectedCoins}/{totalCoins}"; // Update UI
    }


}