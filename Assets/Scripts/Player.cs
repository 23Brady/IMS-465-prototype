using System.Threading;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;

public class Player : MonoBehaviour
{
    public static Player instance { get; private set; }
    [SerializeField]private float moveSpeed = 120.0f;

    [SerializeField] private UIManager uiManager;
    private Rigidbody2D rb;

    private Vector2 moveInput;

    private InputAction test;

    public float maxHealth = 20f;
    public float currentHealth = 20f;

    private Transform battleBox;
    public bool isPlayerTurn;
    
    private void Awake()
    {
        if(instance != null && instance != this)
        {
            Destroy(gameObject);
            return;
        }
        instance = this;
        rb = GetComponent<Rigidbody2D>();
        uiManager.SetMaxHealth(maxHealth);
        uiManager.currentHealth = maxHealth;
    }
    private void Start()
    {
        battleBox = GameManager.instance.battleBox.transform;
    }
    private void Update()
    {
        
    }
    // Update is called once per frame
    void FixedUpdate()
    {
        if (!isPlayerTurn)
        {
            rb.linearVelocity = moveInput.normalized * moveSpeed * Time.deltaTime;
        }
        else
        {
            rb.linearVelocity = new Vector2 (0,0);
        }
        
    }

    public void Move(InputAction.CallbackContext context)
    {
        moveInput = context.ReadValue<Vector2>();
    }
    
    public void SetHealth(float healthChange)
    {
        currentHealth += healthChange;
        currentHealth = Mathf.Clamp(currentHealth, 0, maxHealth);
        uiManager.SetHealth(currentHealth);
    }
    public void PlayerTurn()
    {
        //change this to Kris' position later and turn the sprite renderer off
        transform.position = new Vector3(-15, -15, 0);
        //I want to eventually make a state machine for this rather than just a bool, not part of this sprint though
        isPlayerTurn = true;
    }
    public void EnemyTurn()
    {
        transform.position = battleBox.TransformPoint(0, 0, 0);
        isPlayerTurn = false;
    }
}
