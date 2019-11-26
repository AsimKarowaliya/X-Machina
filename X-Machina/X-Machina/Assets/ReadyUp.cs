using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReadyUp : MonoBehaviour
{
    Transform player;
    Vector3 originalPos;
    float timer;
    bool started;

    // Start is called before the first frame update
    void Start()
    {
        started = false;
        timer = 6;
        originalPos = transform.position;
        gameObject.GetComponent<MeleeScript>().speed = 0;
        player = GameObject.FindGameObjectWithTag("Player").transform;
    }

    // Update is called once per frame
    void Update()
    {
        float dist = Vector3.Distance(originalPos, player.position);
        if (dist <= 20)
        {
            gameObject.GetComponent<MeleeScript>().speed = 8;
            started = true;
        }
        if(started) timer -= Time.deltaTime;
        if (timer <= 0) Destroy(gameObject);
    }
}
