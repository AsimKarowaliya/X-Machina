using System.Collections;
using System.Collections.Generic;
using UnityEngine;


//bullet for enemy
public class BlueBullet : MonoBehaviour
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



    void OnTriggerEnter2D(Collider2D hitInfo)
    {

        if (hitInfo.CompareTag("Player"))
        {
            HealthSystem health = hitInfo.GetComponent<HealthSystem>();

            health.playerHealth -= 1;
        }
        Instantiate(impactEffect, transform.position, transform.rotation);
        Destroy(gameObject);
        Destroy(other);
    }

}
