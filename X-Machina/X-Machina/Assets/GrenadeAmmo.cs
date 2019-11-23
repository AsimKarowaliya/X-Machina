using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GrenadeAmmo : MonoBehaviour
{
    public Text text1;

    // Update is called once per frame
    void Update()
    {
        GameObject playa = GameObject.Find("Player");
        Weapon w = playa.GetComponent<Weapon>();

        if (w.grenadeCount > 0)
        {
            text1.text = ("X " + w.grenadeCount);
        }
        else
        {
            text1.text = ("Out of Grenade!");
        }
    }
}
