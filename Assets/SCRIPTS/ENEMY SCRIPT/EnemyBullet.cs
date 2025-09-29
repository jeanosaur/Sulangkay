using UnityEngine;

public class EnemyBullet : MonoBehaviour
{
    private GameObject Player;
    private Rigidbody2D rb;
    [SerializeField] public float bulletForce;
    public int damage = 1;
    private float timer;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        Player = GameObject.FindGameObjectWithTag("Player");
        
        Vector3 direction = Player.transform.position - transform.position;
        rb.linearVelocity = new Vector2(direction.x, direction.y).normalized * bulletForce;
    }

    void Update()
    {
        timer += Time.deltaTime;
        if (timer >= 10)
        {
            Destroy(gameObject);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Destroy(gameObject);
        }
    }
}
