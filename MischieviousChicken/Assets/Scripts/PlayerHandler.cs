using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement; // Add this namespace

public class PlayerHandler : MonoBehaviour
{
    private PlayerController playerController;
    private PlayerProgressScript playerProgressScript; // Add this reference

    void Start()
    {
        playerController = GetComponent<PlayerController>();
        playerProgressScript = GameObject.FindObjectOfType<PlayerProgressScript>(); // Initialize the reference
    }

    void Update()
    {
        // Check if the player's y position is below -10
        if (transform.position.y < -10)
        {
            ResetPlayerProgress();
            // Load the game over scene
            SceneManager.LoadScene("GameOverScene");
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            Debug.Log("DEATH!");
            ResetPlayerProgress();
            // Load the game over scene
            SceneManager.LoadScene("GameOverScene");
        }
        else if (collision.gameObject.tag == "Finish")
        {
            Debug.Log("Finish");
            playerProgressScript.DefeatLevel();
            SceneManager.LoadScene("Overworld1");
        }
        else if (collision.gameObject.tag == "Chest")
        {
            if (playerProgressScript.GetKeys() >= 1)
            {
                for (int i = 0; i < 10; i++)
                {
                    playerProgressScript.AddCoins(1);
                }
                playerProgressScript.AddKeys(-1); // Remove one key
                Debug.Log("Chest collected!");
                Destroy(collision.gameObject);
            }
            else
            {
                Debug.Log("You don't have a key to open the chest!");
            }
        }
    }
    
    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag == "Coin")
        {
            Destroy(col.gameObject);
            playerProgressScript.AddCoins(1); // Update the coins in the PlayerProgressScript
            Debug.Log("Coin collected!");
        }
        else if (col.gameObject.tag == "Key")
        {
            Destroy(col.gameObject);
            playerProgressScript.AddKeys(1); // Update the keys in the PlayerProgressScript
            Debug.Log("Key collected!");
        }
    }

    private void ResetPlayerProgress()
    {
        // Create a new instance of PlayerProgressScript
        PlayerProgressScript newInstance = new GameObject("PlayerProgress").AddComponent<PlayerProgressScript>();
        // Set the new instance as the instance
        PlayerProgressScript.instance = newInstance;

        // Reset the values
        newInstance.coins = 0;
        newInstance.keys = 0;
        newInstance.levelsDefeated = 0;
        newInstance.SaveData();
    }
}