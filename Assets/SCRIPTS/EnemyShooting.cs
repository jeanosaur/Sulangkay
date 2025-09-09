using UnityEngine;
public class EnemyShooting : MonoBehaviour
{
    public GameObject Bullet;
    public Transform BulletPosition;

    private float timer; // controls the frequency of the bullet spawning

    void Update()
    {
        timer += Time.deltaTime;
        if (timer >= 2)
        {
            timer = 0;
            shoot();
        }
    }

    void shoot()
    {
        Instantiate(Bullet, BulletPosition.position, Quaternion.identity);
    }
}
