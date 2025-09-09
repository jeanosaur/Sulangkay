using UnityEngine;

public class EnemyBullet : MonoBehaviour
{
    private GameObject Player;
    private Rigidbody2D rb;
    [SerializeField] public float bulletForce;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        Player = GameObject.FindGameObjectWithTag("Player");
        
        Vector3 direction = Player.transform.position - transform.position;
        rb.linearVelocity = new Vector2(direction.x, direction.y).normalized * bulletForce;
    }


}
