using System.Threading;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;

public class Player : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    [SerializeField]private float moveSpeed = 120.0f;

    [SerializeField] private HealthUI healthBar;
    private Rigidbody2D rb;

    private Vector2 moveInput;

    private InputAction test;

    public float maxHealth = 20f;
    public float currentHealth = 20f;
    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        healthBar.SetMaxHealth(maxHealth);
        healthBar.currentHealth = maxHealth;
    }
    private void Start()
    {
        
    }
    private void Update()
    {
        
    }
    // Update is called once per frame
    void FixedUpdate()
    {
        rb.linearVelocity = moveInput.normalized * moveSpeed * Time.deltaTime;
    }

    public void Move(InputAction.CallbackContext context)
    {
        moveInput = context.ReadValue<Vector2>();
    }
    
    public void SetHealth(float healthChange)
    {
        currentHealth += healthChange;
        currentHealth = Mathf.Clamp(currentHealth, 0, maxHealth);
        healthBar.SetHealth(currentHealth);
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.TryGetComponent<IDamager>(out var damager))
        {
            damager.Damage();
        }
    }
}
