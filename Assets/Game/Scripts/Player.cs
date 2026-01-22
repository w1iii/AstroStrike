using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    public GameObject destructionFX;
    public GameObject deathCanvas;

    [Header("Health Settings")]
    public int maxHealth = 100;
    private int currentHealth;

    [Header("UI (Optional)")]
    public Slider healthBar;
    public TMP_Text healthText;
    
    public static Player instance;

    private void Awake()
    {
        if (instance == null)
            instance = this;
            
        deathCanvas.SetActive(false);

        currentHealth = maxHealth;
        UpdateUI();
    }


    public void GetDamage(int damage)
    {
        currentHealth -= damage + 4;
        currentHealth = Mathf.Clamp(currentHealth, 0, maxHealth);
        UpdateUI();

        if (currentHealth <= 0)
        {
            Destruction();
        }
    }

    void UpdateUI()
    {
        if (healthBar != null)
            healthBar.value = currentHealth;

        if (healthText != null)
            healthText.text = $"HP: {currentHealth} / {maxHealth}";
    }
    void Destruction()
    {
        Instantiate(destructionFX, transform.position, Quaternion.identity);
        Destroy(gameObject);
        deathCanvas.SetActive(true);
    }
    
    public void RestartGame()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
