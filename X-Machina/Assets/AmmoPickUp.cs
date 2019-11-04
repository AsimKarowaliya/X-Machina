using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AmmoPickUp : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Ammo"))
        {
            AmmoText.ammoAmount += 10;
            GrenadeAmmo.ammoAmount += 1;
           var des = GameObject.FindWithTag("Ammo");

            Destroy(des);
        }
    }
}

