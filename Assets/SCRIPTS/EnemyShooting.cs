using UnityEngine;
public class EnemyShooting : MonoBehaviour
{
    public GameObject Bullet;
    public Transform BulletPosition;
    private GameObject player;
    
    private float timer; // controls the frequency of the bullet spawning

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }
    void Update()
    {
        float distance = Vector2.Distance(transform.position,  player.transform.position);
        Debug.Log(distance);

        if (distance < 50)
        {
            timer += Time.deltaTime;
            
            if (timer >= 2)
            {
                timer = 0;
                shoot();
            }
        }
    }

    void shoot()
    {
        Instantiate(Bullet, BulletPosition.position, Quaternion.identity);
    }
}
