using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playonG : MonoBehaviour
{
	public AudioSource jp;
    GameObject playa;
    Weapon w;

    // Update is called once per frame
    private void Start()
    {
        playa = GameObject.Find("Player");
        w = playa.GetComponent<Weapon>();
    }
    void Update()
	{
        if (Input.GetKeyDown(KeyCode.G) && w.grenadeCount != 0)
		{
			jp.Play();
		}
	}

}
