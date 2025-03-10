using UnityEngine;
using UnityEngine.SceneManagement; // For scene management
using UnityEngine.UI; // For button functionality

public class MainMenu : MonoBehaviour
{
    public GameObject mainMenuPanel; // The panel for the main menu
    public GameObject optionsMenuPanel; // The panel for the options menu (optional)
    
    // Called when the Start Game button is pressed
    public void StartGame()
    {
        // Load the first scene of your game (adjust the scene name to match your setup)
        SceneManager.LoadScene("GameScene"); // Replace "GameScene" with the actual name of your game scene
    }

    // Called when the Options button is pressed
    public void OpenOptions()
    {
        // Hide the main menu and show the options menu
        mainMenuPanel.SetActive(false);
        optionsMenuPanel.SetActive(true);
    }

    // Called when the Exit button is pressed
    public void ExitGame()
    {
        // Exit the game (works in a build, not in the editor)
        #if UNITY_EDITOR
            UnityEditor.EditorApplication.isPlaying = false; // Stop play mode in the editor
        #else
            Application.Quit(); // Quit the game when built
        #endif
    }

    // Called when the Back button in the options menu is pressed
    public void BackToMainMenu()
    {
        // Hide the options menu and show the main menu
        optionsMenuPanel.SetActive(false);
        mainMenuPanel.SetActive(true);
    }
}
