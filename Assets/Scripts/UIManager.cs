using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public static UIManager instance { get; private set; }
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

    //party stuff
    [SerializeField] private RectTransform kTophalf;
    [SerializeField] private GameObject kBorder;
    [SerializeField] private Button kFight;
    [SerializeField] private RectTransform sTopHalf;
    [SerializeField] private GameObject sBorder;
    [SerializeField] private Button sFight;
    [SerializeField] private RectTransform rTopHalf;
    [SerializeField] private GameObject rBorder;
    [SerializeField] private Button rFight;
    public bool choice = false;



    private void Awake()
    {
        if (instance != null && instance != this)
        {
            Destroy(gameObject);
            return;
        }
        instance = this;
    }
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
    public void KTurn()
    {
        EventSystem.current.SetSelectedGameObject(null);
        EventSystem.current.SetSelectedGameObject(kFight.gameObject);
        kTophalf.offsetMin = new Vector2(2, 93);
        kTophalf.offsetMax = new Vector2(-2, 83);
        kBorder.SetActive(true);
        kFight.onClick.AddListener(Choice);
    }
    public void STurn()
    {
        kTophalf.offsetMin = new Vector2(2, 2);
        kTophalf.offsetMax = new Vector2(-2, -2);
        kBorder.SetActive(false);
        EventSystem.current.SetSelectedGameObject(null);
        EventSystem.current.SetSelectedGameObject(sFight.gameObject);
        sTopHalf.offsetMin = new Vector2(2, 93);
        sTopHalf.offsetMax = new Vector2(-2, 83);
        sBorder.SetActive(true);
        sFight.onClick.AddListener(Choice);

    }
    public void RTurn()
    {
        sTopHalf.offsetMin = new Vector2(2, 2);
        sTopHalf.offsetMax = new Vector2(-2, -2);
        sBorder.SetActive(false);
        EventSystem.current.SetSelectedGameObject(null);
        EventSystem.current.SetSelectedGameObject(rFight.gameObject);
        rTopHalf.offsetMin = new Vector2(2, 93);
        rTopHalf.offsetMax = new Vector2(-2, 83);
        rBorder.SetActive(true);
        rFight.onClick.AddListener(Choice);
    }
    public void ResetR()
    {
        rTopHalf.offsetMin = new Vector2(2, 2);
        rTopHalf.offsetMax = new Vector2(-2, -2);
        rBorder.SetActive(false);
    }
    public void Choice()
    {
        choice = true;
        kFight.onClick.RemoveListener(Choice);
        sFight.onClick.RemoveListener(Choice);
        rFight.onClick.RemoveListener(Choice);
    }
    
    
}
