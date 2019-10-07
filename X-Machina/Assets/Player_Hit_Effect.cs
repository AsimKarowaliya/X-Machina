using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Hit_Effect : MonoBehaviour
{
    void ResetMat()
    {
        GetComponent<SpriteRenderer>().color = Color.white;
    }

    void OnTriggerEnter2D(Collider2D coll)
    {
       
        if (coll.CompareTag("BlueBullet") || coll.CompareTag("Enemy"))
        {
            //Instantiate(DeathEffect, transform.position, Quaternion.identity);
            //Destroy(gameObject);
            GetComponent<SpriteRenderer>().color = Color.red;
            Invoke("ResetMat", 0.05f);
            // HealthSystem SN = coll.GetComponent<HealthSystem>();
            // SN.playerHealth -= 1;
        }

    }
}
