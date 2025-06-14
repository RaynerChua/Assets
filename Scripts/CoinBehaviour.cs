
/* 
* Author: Chua Yi Xuan Rayner
* Date: 9/6/25 - 14/6/25
* Description: This script is to facilitate the collection of coins in the game.
*/ 


using UnityEngine;

public class CoinBehaviour : MonoBehaviour
{
    // Coin value that will be added to the player's score
    [SerializeField]
    int coinValue = 1;

    // Method to collect the coin on player interaction
    // Adds the coin's value to player score while updating coin count
    public void Collect(PlayerBehaviour player)
    {
        // Logic for collecting the coin
        Debug.Log("Coin collected!");

        player.ModifyScore(coinValue); //Adds to player score
        player.IncrementCoinCount(); // Updates coin counter

        Destroy(gameObject); // Destroy the coin object
    }
}
