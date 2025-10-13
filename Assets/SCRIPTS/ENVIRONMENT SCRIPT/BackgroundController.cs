using UnityEngine;

public class BackgroundController : MonoBehaviour
{
    private float startPos;
    public GameObject cam;
    public float parallaxEffect; //speed which bg should move relative to cam

    private void Start()
    {
        startPos = transform.position.x;
    }

    private void Update()
    {
        //calculate distance of bg based on cam movement
        float distance = cam.transform.position.x * parallaxEffect; // 0 = move with cam || 1 = wont move
    
        transform.position = new Vector3 (startPos + distance, transform.position.y, transform.position.z);
    }

}
