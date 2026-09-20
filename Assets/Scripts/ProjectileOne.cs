using UnityEngine;

public class ProjectileOne : MonoBehaviour, IDamager
{
    [SerializeField] private float speed = 5f;
    private float damage = -1f;
    private Player player;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        player = GameObject.Find("Player").GetComponent<Player>();
    }
    void Update()
    {
        if(Mathf.Abs(transform.position.x) >= 15)
        {
            Destroy(gameObject);
        }
        if(Mathf.Abs(transform.position.y) >= 7)
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
        player.SetHealth(damage);
        Destroy(gameObject);
    }
    public void Damage()
    {
        DealDamage();
    }
}
