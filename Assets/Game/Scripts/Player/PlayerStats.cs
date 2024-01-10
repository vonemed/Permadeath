using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStats : MonoBehaviour
{
    // Health Properties
    public int maxHealth = 100;
    public int currentHealth;

    // Experience Properties
    public int maxEXP = 100; // The EXP needed for the next level
    public int currentEXP;

    // Level Properties
    public int currentLevel = 1;

    void Start()
    {
        currentHealth = maxHealth;
        currentEXP = 0;
    }

    // Health Methods
    public void TakeDamage(int damage)
    {
        currentHealth -= damage;
        currentHealth = Mathf.Clamp(currentHealth, 0, maxHealth);
        // Update health UI here if needed
    }

    public void Heal(int amount)
    {
        currentHealth += amount;
        currentHealth = Mathf.Clamp(currentHealth, 0, maxHealth);
        // Update health UI here if needed
    }

    // Experience Methods
    public void GainEXP(int amount)
    {
        currentEXP += amount;

        // Check for level up
        if (currentEXP >= maxEXP)
        {
            LevelUp();
        }

        // Update EXP UI here if needed
    }

    // Level Up Method
    private void LevelUp()
    {
        currentLevel++;
        currentEXP -= maxEXP; // Reset EXP or carry over extra EXP to next level
        maxEXP = CalculateNextLevelEXP(); // Calculate new EXP threshold for next level

        // Implement additional level up logic (e.g., increase health, stats, etc.)

        // Update UI here if needed
    }

    // Calculate EXP for Next Level
    // Modify this method according to your leveling system
    private int CalculateNextLevelEXP()
    {
        // Example: Simple incremental increase
        return maxEXP + 50; // Or any other formula you want for EXP increment
    }
}