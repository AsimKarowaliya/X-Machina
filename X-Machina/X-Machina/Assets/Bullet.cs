using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float speed = 20f;
    private GameObject other;
    public Rigidbody2D rb;
    public int Damage;
    public GameObject impactEffect;

    // Start is called before the first frame update
    void Start()
    {
        rb.velocity = transform.right * speed;
        other = GameObject.FindGameObjectWithTag("Flash");

    }
    void OnBecameInvisible()
    {
        Destroy(gameObject);
    }

    void ResetMat()
    {
        GetComponent<SpriteRenderer>().color = Color.white;
    }

    //void OnTriggerEnter2D(Collider2D hitInfo)
    //{


    //    if (hitInfo.CompareTag("Player"))
    //    {
    //        HealthSystem health = hitInfo.gameObject.GetComponent<HealthSystem>();
    //        if (health.ShieldHealth != 0)
    //        {
    //            health.ShieldHealth -= 1;
    //        }
    //        else if (health.ShieldHealth == 0)
    //        {
    //            health.playerHealth -= 1;
    //        }
    //    }
    //    Instantiate(impactEffect, transform.position, transform.rotation);
    //    Destroy(gameObject);
    //    Destroy(other);
    //}

    void OnCollisionEnter2D(Collision2D hitInfo)
    {


        if (hitInfo.gameObject.tag == "Player")
        {
            HealthSystem health = hitInfo.gameObject.GetComponent<HealthSystem>();
            if (health.ShieldHealth != 0)
            {
                health.ShieldHealth -= Damage;
            }
            else if (health.ShieldHealth == 0)
            {
                health.playerHealth -= Damage;
            }
        }
        Instantiate(impactEffect, transform.position, transform.rotation);
        Destroy(gameObject);
        Destroy(other);
    }
}
