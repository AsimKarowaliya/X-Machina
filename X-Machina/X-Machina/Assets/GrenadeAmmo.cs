using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GrenadeAmmo : MonoBehaviour
{
    public Text text1;
    public static int ammoAmount = 5;
    // Update is called once per frame
    void Update()
    {

        if (ammoAmount > 0)
        {
            text1.text = ("X " + ammoAmount);
        }
        else
        {
            text1.text = ("Out of Grenade!");
        }
    }
}
