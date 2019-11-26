using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playONj : MonoBehaviour
{

    public AudioSource jp;
    int ammo;
    // Update is called once per frame

    void Update()
    {
        ammo = AmmoText.ammoAmount;
        if (Input.GetKeyDown(KeyCode.J) && ammo > 0)
        {
            jp.Play();
        }
    }
}
