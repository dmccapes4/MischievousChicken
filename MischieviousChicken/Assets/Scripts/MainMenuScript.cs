using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenuScript : MonoBehaviour
{
    // Reference to the retry button
    public GameObject playButton;

    // Reference to the quit button
    public GameObject quitButton;

    void Start()
    {
        // Add a listener to the retry button
        playButton.GetComponent<Button>().onClick.AddListener(RetryGame);

        // Add a listener to the quit button
        quitButton.GetComponent<Button>().onClick.AddListener(QuitGame);
    }

    // Method to retry the game
    void RetryGame()
    {
        print("Play");
        // Load the Overworld scene
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