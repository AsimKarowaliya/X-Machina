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
		if (Input.GetKeyDown(KeyCode.G) && GrenadeAmmo.ammoAmount != 0)
		{
			jp.Play();
		}
	}

}
