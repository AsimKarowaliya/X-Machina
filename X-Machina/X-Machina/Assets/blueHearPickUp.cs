using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class blueHearPickUp : MonoBehaviour
{

    HealthSystem healthPickup;
    Player player;
    void Awake()
    {
        healthPickup = FindObjectOfType<HealthSystem>();
        player = FindObjectOfType<Player>();
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            if (healthPickup.ShieldHealth < 3)
            {
                Destroy(gameObject);
                healthPickup.ShieldHealth += 1;
            }
        }
    }
}
