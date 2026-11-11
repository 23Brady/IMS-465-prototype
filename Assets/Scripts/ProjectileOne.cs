using UnityEngine;

public class ProjectileOne : MonoBehaviour, IDamager
{
    [SerializeField] private float speed = 5f;
    private float damage = -1f;
    private float tpValue = 1f;
    private UIManager uiManager;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
        uiManager = GameObject.FindGameObjectWithTag("UIManager").GetComponent<UIManager>();
        //make singleton at some point
    }
    void Update()
    {
        if(Mathf.Abs(transform.position.x) >= 15 || Mathf.Abs(transform.position.y) >= 10 || Player.instance.isPlayerTurn == true)
        {
            Destroy(gameObject);
        }
    }
    // Update is called once per frame
    void FixedUpdate()
    {
        transform.Translate(Vector2.up * speed * Time.deltaTime, Space.Self);
    }

    public void DealDamage()
    {
        Player.instance.SetHealth(damage);
        Destroy(gameObject);
    }
    public void Damage()
    {
        DealDamage();
    }
    public void GainTP()
    {
        GiveTP();
    }
    private void GiveTP()
    {
        uiManager.SetTP(tpValue);
    }
}
