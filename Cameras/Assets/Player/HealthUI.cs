using UnityEngine;
using UnityEngine.UI;

public class HealthUI : MonoBehaviour
{
    public Movement2 movement2;  // Reference to the Movement2 script
    public Text healthText;      // Reference to the UI Text component

    void Start()
    {
        // Ensure the Movement2 script is attached to the same GameObject
        if (movement2 == null)
        {
            Debug.LogError("Movement2 script not assigned to UIController.");
            return;
        }

        // Ensure the Text component is assigned
        if (healthText == null)
        {
            Debug.LogError("Text component not assigned to UIController.");
            return;
        }

        // Set the initial health text
        UpdateHealthText();
    }

    void Update()
    {
        // Update the health text each frame
        UpdateHealthText();
    }

    void UpdateHealthText()
    {
        // Update the UI Text component with the health value from Movement2
        healthText.text = "Health: " + movement2.Player2Health.ToString();
    }
}
