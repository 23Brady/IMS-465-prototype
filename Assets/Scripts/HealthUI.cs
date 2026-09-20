using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class HealthUI : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public float currentHealth;
    public float maximumHealth;
    public float width;
    public float height;
    [SerializeField] private RectTransform healthBar;
    [SerializeField] private TextMeshProUGUI healthDisplay;
    private void Start()
    {
        healthDisplay.SetText(maximumHealth + "/" + currentHealth);
    }
    public void SetMaxHealth(float maxHealth)
    {
        maximumHealth = maxHealth;
    }
    public void SetHealth(float health)
    {
        currentHealth = health;
        float newWidth = (currentHealth / maximumHealth) * width;

        healthBar.sizeDelta = new Vector2(newWidth, height);
        healthDisplay.SetText(currentHealth + "/" + maximumHealth);
    }
}
