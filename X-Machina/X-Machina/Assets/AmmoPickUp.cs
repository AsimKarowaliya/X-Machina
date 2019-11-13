using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AmmoPickUp : GrenadeAmmo
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Ammo"))
        {
            AmmoText.ammoAmount += 10;
            ammoAmount += 1;
          
            Destroy(collision.gameObject);
        }
    }
}

