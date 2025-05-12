// This Unity C# script suite provides all necessary components to meet the UI2 Project Submission requirements.

using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class UIManager : MonoBehaviour
{
    // Menus
    public GameObject mainMenu;
    public GameObject pauseMenu;
    public GameObject levelSelectMenu;
    public GameObject settingsMenu;

    // HUD Components
    public Slider healthBar;
    public TextMeshProUGUI scoreText;
    public RectTransform miniMap;

    // Settings Components
    public TMP_Dropdown resolutionDropdown;
    public Toggle fullscreenToggle;
    public Slider volumeSlider;

    // Accessibility
    public GameObject tooltip;
    public TMP_Text[] adjustableTexts;
    public int textSize = 14;

    // Feedback
    public AudioSource clickSound;
    public GameObject successMessage;
    public GameObject errorMessage;

    private int score = 0;
    private float health = 100f;

    void Start()
    {
        ShowMainMenu();
        ApplySettings();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape)) TogglePauseMenu();
        UpdateHUD();
    }

    public void ShowMainMenu()
    {
        mainMenu.SetActive(true);
        pauseMenu.SetActive(false);
        levelSelectMenu.SetActive(false);
        settingsMenu.SetActive(false);
    }

    public void ShowLevelSelectMenu()
    {
        mainMenu.SetActive(false);
        levelSelectMenu.SetActive(true);
    }

    public void TogglePauseMenu()
    {
        pauseMenu.SetActive(!pauseMenu.activeSelf);
        Time.timeScale = pauseMenu.activeSelf ? 0 : 1;
    }

    public void OpenSettings()
    {
        settingsMenu.SetActive(true);
    }

    public void CloseSettings()
    {
        settingsMenu.SetActive(false);
    }

    public void ApplySettings()
    {
        Screen.fullScreen = fullscreenToggle.isOn;
        AudioListener.volume = volumeSlider.value;
        Resolution res = Screen.resolutions[resolutionDropdown.value];
        Screen.SetResolution(res.width, res.height, Screen.fullScreen);
    }

    public void AdjustTextSize(int size)
    {
        textSize = size;
        foreach (var t in adjustableTexts) t.fontSize = textSize;
    }

    public void ShowTooltip(string message)
    {
        tooltip.SetActive(true);
        tooltip.GetComponentInChildren<TMP_Text>().text = message;
    }

    public void HideTooltip()
    {
        tooltip.SetActive(false);
    }

    public void PlayClickSound()
    {
        clickSound.Play();
    }

    public void ShowSuccessMessage(string msg)
    {
        successMessage.SetActive(true);
        successMessage.GetComponentInChildren<TMP_Text>().text = msg;
    }

    public void ShowErrorMessage(string msg)
    {
        errorMessage.SetActive(true);
        errorMessage.GetComponentInChildren<TMP_Text>().text = msg;
    }

    public void UpdateHUD()
    {
        healthBar.value = health;
        scoreText.text = "Score: " + score;
        // Mini-map updates here (example logic)
        miniMap.anchoredPosition = new Vector2(transform.position.x, transform.position.z);
    }

    public void UpdateScore(int increment)
    {
        score += increment;
        UpdateHUD();
    }

    public void UpdateHealth(float value)
    {
        health = Mathf.Clamp(health + value, 0, 100);
        UpdateHUD();
    }

    public void LoadLevel(string levelName)
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(levelName);
    }
}

// Additional scripts for button animations, transitions, etc., would be added using Unity’s Animator or DOTween for fade/scale/slide effects.
