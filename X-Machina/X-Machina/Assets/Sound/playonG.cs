using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playonG : MonoBehaviour
{
	public AudioSource jp;
    GameObject gameObject;

	// Update is called once per frame

	void Update()
	{
        GameObject playa = GameObject.Find("Player");
        Weapon w = playa.GetComponent<Weapon>();

        if (Input.GetKeyDown(KeyCode.G) && w.grenadeCount != 0)
		{
			jp.Play();
		}
	}

}
