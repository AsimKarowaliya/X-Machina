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
        transform.Rotate(0f,180f, 0f);
        rb.velocity = transform.right * speed;
        other = GameObject.FindGameObjectWithTag("Flash");

    }
    void OnBecameInvisible()
    {
        Destroy(gameObject);
    }

    // use this to kill the Player
    //void OnTriggerEnter2D(Collider2D hitInfo)
    //{
    //    Player PLAYER = hitInfo.GetComponent<Player>();
    //    if (PLAYER != null)
    //    {
    //        PLAYER.TakeDamage(Damage);
    //    }
    //    Instantiate(impactEffect, transform.position, transform.rotation);
    //    Destroy(gameObject);
    //    Destroy(other);
    //}

}
