using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AmmoPickUp : GrenadeAmmo
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        GameObject playa = GameObject.Find("Player");
        Weapon w = playa.GetComponent<Weapon>();

        if (collision.CompareTag("Ammo"))
        {
            AmmoText.ammoAmount += 10;
            GrenadeAmmo.ammoAmount += 1;
            w.grenadeCount += 1;
          
            Destroy(collision.gameObject);
        }
    }
}

