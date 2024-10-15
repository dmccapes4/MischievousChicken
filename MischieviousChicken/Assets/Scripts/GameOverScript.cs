using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameOverHandler : MonoBehaviour
{
    // Reference to the retry button
    public GameObject retryButton;

    // Reference to the quit button
    public GameObject quitButton;

    void Start()
    {
        // Add a listener to the retry button
        retryButton.GetComponent<Button>().onClick.AddListener(RetryGame);

        // Add a listener to the quit button
        quitButton.GetComponent<Button>().onClick.AddListener(QuitGame);
    }

    // Method to retry the game
    void RetryGame()
    {
        print("Retry");
        // Load the Level1 scene
        SceneManager.LoadScene("Overworld1");
    }

    // Method to quit the game
    void QuitGame()
    {
        print("Quit");
        // Quit the game
        Application.Quit();
    }
}