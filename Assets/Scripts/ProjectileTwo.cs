using UnityEngine;

public class ProjectileTwo : MonoBehaviour, IDamager
{
    [SerializeField] private float speed = 3f;
    private float damage = -3f;
    private Player player;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        player = GameObject.Find("Player").GetComponent<Player>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Mathf.Abs(transform.position.x) >= 15)
        {
            Destroy(gameObject);
        }
        if (Mathf.Abs(transform.position.y) >= 7)
        {
            Destroy(gameObject);
        }
    }
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
