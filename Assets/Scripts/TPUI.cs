using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class TPUI : MonoBehaviour
{
    private float currentTP = 0.0f;
    private float maxTP = 100.0f;
    public float width;
    public float height;
    [SerializeField] private TextMeshProUGUI TPDisplay;
    [SerializeField] private RectTransform TPBar;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        TPDisplay.SetText(currentTP + "  %");
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void SetTP(float TPChange)
    {
        currentTP += TPChange;
        currentTP= Mathf.Clamp(currentTP, 0, maxTP);
        TPDisplay.SetText(currentTP + "  %");
        float newHeight= (currentTP / maxTP) * height;

        TPBar.sizeDelta = new Vector2(width, newHeight);
        
    }
}
