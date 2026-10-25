using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public float currentHealth;
    public float maximumHealth;
    public float healthWidth;
    public float healthHeight;
    [SerializeField] private RectTransform healthBar;
    [SerializeField] private TextMeshProUGUI healthDisplay;

    private float currentTP = 0.0f;
    private float maxTP = 100.0f;
    public float tpWidth;
    public float tpHeight;
    [SerializeField] private TextMeshProUGUI TPDisplay;
    [SerializeField] private Image TPBar;
    [SerializeField] private Slider slider;
    private void Start()
    {
        healthDisplay.SetText(maximumHealth + "/" + currentHealth);
        TPDisplay.SetText(currentTP + "  %");
        slider.maxValue = maxTP;
        slider.value = currentTP;
    }
    public void SetMaxHealth(float maxHealth)
    {
        maximumHealth = maxHealth;
    }
    public void SetHealth(float health)
    {
        currentHealth = health;
        float newWidth = (currentHealth / maximumHealth) * healthWidth;

        healthBar.sizeDelta = new Vector2(newWidth, healthHeight);
        healthDisplay.SetText(currentHealth + "/" + maximumHealth);
    }
    public void SetTP(float TPChange)
    {
        currentTP += TPChange;
        currentTP = Mathf.Clamp(currentTP, 0, maxTP);
        TPDisplay.SetText(currentTP + "  %");
        slider.value = currentTP;
    }    
}
