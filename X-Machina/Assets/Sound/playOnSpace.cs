using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playOnSpace : MonoBehaviour
{

    public AudioSource jp;

    // Update is called once per frame

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            jp.Play();
        }
    }
}
