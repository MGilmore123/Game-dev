using UnityEngine;
using UnityEngine.UI; // To access UI elements

public class HUDManager : MonoBehaviour
{
    public Text healthText; // Reference to the health text UI element
    public Text scoreText;  // Reference to the score text UI element
    public Image healthBar; // Reference to the health bar UI image (if you want to use a health bar)

    private int health = 100; // Player's initial health
    private int score = 0;    // Player's score

    // Update the health UI element (text and/or bar)
    void UpdateHealth()
    {
        healthText.text = "Health: " + health.ToString(); // Update health text

        if (healthBar != null)
        {
            // Update the health bar based on the player's health
            healthBar.fillAmount = health / 100f; // Assuming health ranges from 0 to 100
        }
    }

    // Update the score UI element
    void UpdateScore()
    {
        scoreText.text = "Score: " + score.ToString(); // Update score text
    }

    // Function to reduce health (for example, when the player takes damage)
    public void TakeDamage(int damage)
    {
        health -= damage;
        if (health < 0) health = 0;
        UpdateHealth(); // Update health after taking damage
    }

    // Function to add to the score (for example, when the player scores points)
    public void AddScore(int points)
    {
        score += points;
        UpdateScore(); // Update score after adding points
    }

    // Example: Call this method to simulate damage or scoring (you could connect it to actual game events)
    public void SimulateGameEvents()
    {
        // Simulate damage and score change
        TakeDamage(10); // Take 10 damage
        AddScore(50); // Gain 50 points
    }

    // Start is called before the first frame update
    void Start()
    {
        UpdateHealth(); // Initial health setup
        UpdateScore();  // Initial score setup
    }

    // Update is called once per frame
    void Update()
    {
        // For testing purposes, let's simulate game events
        if (Input.GetKeyDown(KeyCode.D)) // Press 'D' to simulate damage
        {
            SimulateGameEvents();
        }
    }
}
