using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Invunerability : MonoBehaviour
{
    Renderer rend;
    HealthSystem health;
    Color C;

    void Start()
    {
        rend = GetComponent<Renderer>();
        C = rend.material.color;
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            StartCoroutine("GetInvulnerable");
        }
    }

    IEnumerator GetInvulnerable()
    {
        Physics2D.IgnoreLayerCollision(8, 9, true);
        C.a = 0.5f;
        rend.material.color = C;
        health.ShieldHealth -= 0;
        yield return new WaitForSeconds(1f);
        
        Physics2D.IgnoreLayerCollision(8, 9, false);
        C.a = 1f;
        rend.material.color = C;
    }

}
