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
        float temp = (cam.transform.position.x * (1 - parallaxEffect));
        float dist = (cam.transform.position.x * parallaxEffect);
        //float dist = (Input.GetAxis("Horizontal") * parallaxEffect);

        //startpos = cam.transform.position.x + Camera.main.orthographicSize;

        //transform.position = new Vector3(startpos, transform.position.y, transform.position.z);

        if ((transform.position.x ) < (cam.transform.position.x - Camera.main.orthographicSize * 3))
        {
            startpos = cam.transform.position.x + Camera.main.orthographicSize * 3;
        }

        else if ((transform.position.x) > (cam.transform.position.x + Camera.main.orthographicSize * 3))
        {
            startpos = cam.transform.position.x - Camera.main.orthographicSize * 3;
        }
        transform.position = new Vector3(startpos, transform.position.y, transform.position.z);

        //startpos = cam.transform.position.x;
        //if (temp < startpos - length)
        //{
        //    startpos = cam.transform.position.x;
        //}

    }
}
