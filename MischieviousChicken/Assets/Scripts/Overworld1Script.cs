using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Overworld1Script : MonoBehaviour
{
    public GameObject tutorialButton;
    
    // Reference to the Level1 button
    public GameObject level1Button;

    // Reference to the Level2 button
    public GameObject level2Button;

    public GameObject level3Button;

    void Start()
    {
        tutorialButton.GetComponent<Button>().onClick.AddListener(LoadTutorialLevel);
        
        // Add a listener to the Level1 button
        level1Button.GetComponent<Button>().onClick.AddListener(LoadLevel1);

        // Add a listener to the Level2 button
        level2Button.GetComponent<Button>().onClick.AddListener(LoadLevel2);

        level3Button.GetComponent<Button>().onClick.AddListener(LoadLevel3);
    }
    
    void LoadTutorialLevel()
    {
        print("Loading Level0");
        // Load the Level0 scene
        SceneManager.LoadScene("Level0");
    }

    // Method to load Level1 scene
    void LoadLevel1()
    {
        print("Loading Level1");
        // Load the Level1 scene
        SceneManager.LoadScene("Level1");
    }

    // Method to load Level2 scene
    void LoadLevel2()
    {
        print("Loading Level2");
        // Load the Level2 scene
        SceneManager.LoadScene("Level2");
    }

    void LoadLevel3()
    {
        print("Loading Level3");
        // Load the Level3 scene
        SceneManager.LoadScene("Level3");
    }
}