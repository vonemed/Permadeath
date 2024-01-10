using UnityEngine;
using UnityEngine.UI;
using TMPro;


public class PlayerUI : MonoBehaviour
{
    public Slider healthSlider;
    public Slider expSlider;
    public TextMeshProUGUI levelText;
    public TextMeshProUGUI timerText;  // Timer Text

    private float elapsedTime; // Timer counter

    public PlayerStats playerStats;

    void Update()
    {
        // Update Health Bar
        if (healthSlider != null)
        {
            healthSlider.value = playerStats.currentHealth;
        }

        // Update EXP Bar
        if (expSlider != null)
        {
            expSlider.value = playerStats.currentEXP;
        }

        // Update Level Text
        if (levelText != null)
        {
            levelText.text = "Level: " + playerStats.currentLevel.ToString();
        }

        // Update Timer
        UpdateTimer();
    }

    private void UpdateTimer()
    {
        elapsedTime += Time.deltaTime;

        // Convert the elapsed time to a timer format (minutes:seconds)
        int minutes = (int)elapsedTime / 60;
        int seconds = (int)elapsedTime % 60;
        timerText.text = string.Format("{0:00}:{1:00}", minutes, seconds);
    }
}