using System;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using Microsoft.Unity.VisualStudio.Editor;
using System.Collections;

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
    public Transform spawnPoint;

    [SerializeField]
    TextMeshProUGUI scoreText;

    [SerializeField]
    TextMeshProUGUI healthText;

    [SerializeField]

    GameObject deathMsgUI;

    [SerializeField]

    GameObject congratsTextUI;

    void Start()
    {
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
        currentHealth = maxHealth;

        if (currentHealth <= 0)
        {
            currentHealth = 0;
            Debug.Log("Player is dead!");

            if (deathMsgUI != null)
            // If the death message UI is assigned, activate it
                deathMsgUI.SetActive(true);

            StartCoroutine(HideDeathMsg());

            Respawn();
       }

    healthText.text = "HEALTH: " + currentHealth.ToString();
    }

    IEnumerator HideDeathMsg() {
        yield return new WaitForSeconds(2f);
        if (deathMsgUI != null)
        {
            deathMsgUI.SetActive(false);
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
            other.GetComponent<VictoryBehaviour>()?.Collect(this);
            Debug.Log("Congratulations! You have completed the game!");
        }
    }

    IEnumerator HideCongratsMsg()
    {
        yield return new WaitForSeconds(6f);
        if (congratsTextUI != null)
        {
            congratsTextUI.SetActive(false);
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

    if (spawnPoint != null)
    {
        transform.position = spawnPoint.position;
        Debug.Log("Teleporting to: " + spawnPoint.position);

        if (rb != null)
        {
            rb.linearVelocity = Vector3.zero;
            rb.angularVelocity = Vector3.zero;
            rb.Sleep(); // Pause physics motion to prevent jitter
        }

        // Optionally force Unity to immediately recognize the position change
        Physics.SyncTransforms();
    }
    else
    {
        Debug.LogWarning("Spawn point not assigned!");
    }

    currentHealth = maxHealth;
    healthText.text = "HEALTH: " + currentHealth.ToString();
    Debug.Log("Player respawned and health reset.");
    }


}