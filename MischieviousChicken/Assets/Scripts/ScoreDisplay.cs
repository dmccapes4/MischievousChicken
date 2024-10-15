using UnityEngine;
using TMPro;

public class PlayerHUD : MonoBehaviour
{
    public TMP_Text coinsText; // Reference to the Coins text element
    public TMP_Text keysText; // Reference to the Keys text element
    private PlayerProgressScript playerProgress; // Reference to the PlayerProgressScript instance

    void Start()
    {
        // Get the PlayerProgressScript instance
        playerProgress = PlayerProgressScript.instance;

        // Initialize text elements with default values
        UpdateText();
    }

    void Update()
    {
        // Update text elements with current player values
        UpdateText();
    }

    // Update the text elements with the current player values
    private void UpdateText()
    {
        coinsText.text = "Coins: " + playerProgress.coins;
        keysText.text = "Keys: " + playerProgress.keys;
    }
}