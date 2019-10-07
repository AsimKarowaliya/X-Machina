using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParallaxCloud : MonoBehaviour
{
    private float length, startpos;
    private Transform mainCameraPosition;
    public GameObject cam;
    public float parallaxEffect;

    // Start is called before the first frame update
    void Start()
    {
        startpos = transform.position.x;
        length = GetComponent<SpriteRenderer>().bounds.size.x;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        float dist = (cam.transform.position.x * parallaxEffect);


        if ((transform.position.x) < (cam.transform.position.x - Camera.main.orthographicSize * 3))
        {
            transform.position = new Vector3(cam.transform.position.x + Camera.main.orthographicSize * 3, transform.position.y, transform.position.z);
            return;
        }

        else if ((transform.position.x) > (cam.transform.position.x + Camera.main.orthographicSize * 3))
        {
            transform.position = new Vector3(cam.transform.position.x - Camera.main.orthographicSize * 3, transform.position.y, transform.position.z);
            return;
        }
        //else transform.position = new Vector3(startpos + dist, transform.position.y, transform.position.z);
    }
}
