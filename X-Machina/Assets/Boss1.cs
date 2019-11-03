using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss1 : MonoBehaviour
{
    private Rigidbody2D rb;
    private Animator Anim;
    private Collider2D Coll;
    public LayerMask Ground;
    public Transform leftpoint, rightpoint;
    public float speed, jumpForce;
    public float leftx, rightx;
    private bool Faceleft = true;
    public GameObject deathEffect;
    public GameObject Bullet;
    public Transform firePoint;
    public float shootDistance;
    public int health;
    private int rand;
    private Transform player;
    
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>(); //get player position
        rb = GetComponent<Rigidbody2D>();
        Anim = GetComponent<Animator>();
        Coll = GetComponent<Collider2D>();

        transform.DetachChildren();
        leftx = leftpoint.position.x;
        rightx = rightpoint.position.x;
        Destroy(leftpoint.gameObject);
        Destroy(rightpoint.gameObject);
    }

    // Update is called once per frame
    void Update()
    {
        Action();
    }

    void Action()
    {
        Vector3 targetPos = player.position;
        targetPos.y = transform.position.y;
        //transform.LookAt(targetPos);
        
        float distance = Vector3.Distance(targetPos, transform.position);
    
        rand = Random.Range(0, 4);
        //if (health >7)
        //{
        //    if (rand == 0)
        //    {
        //        Instantiate(deathEffect, transform.position, Quaternion.identity);
        //        //else if (hitinfo.collider == true && hitinfo.transform.CompareTag("Player") && Faceleft != true)
        //        //{
        //        //    rb.velocity = new Vector2(speed, rb.velocity.y);
        //        //    transform.localScale = new Vector3(0.4f, 0.4f, 1);
        //        //    if (!hitinfo.transform.CompareTag("Player"))
        //        //    {
        //        //        Faceleft = true;
        //        //    }
        //        //}
        //    }
        //}
        if (Faceleft)// face to left
        {
            //if (Coll.IsTouchingLayers(Ground))
            //{
            //Anim.SetBool("Moving", true);
            rb.velocity = new Vector2(-speed, rb.velocity.y);
            //}
            if (transform.position.x < leftx)// pass leftpoing
            {
                Anim.SetBool("Fire", true);
                transform.localScale = new Vector3(0.4f, 0.4f, 1);
                Faceleft = false;
            }
        }
        else //face to right
        {
            //if (Coll.IsTouchingLayers(Ground))
            //{
            //   Anim.SetBool("Moving", true);
            rb.velocity = new Vector2(speed, jumpForce);
            // }
            if (transform.position.x > rightx)// pass leftpoing
            {
                Anim.SetBool("Fire", true);
                transform.localScale = new Vector3(-0.4f, 0.4f, 1);
                Faceleft = true;
            }
        }
        if (health <= 0)
        {
            Die();
        }
    }
    public void TakeDamage(int damage)
    {
        health -= damage;
    }
    void Die()
    {
        Instantiate(deathEffect, transform.position, Quaternion.identity);
        Destroy(gameObject);
    }

    void OnCollisionEnter2D(Collision2D coll)
    {
        //Debug.Log(gameObject.name);
        if (coll.gameObject.CompareTag("Player"))
        {
            HealthSystem health = coll.gameObject.GetComponent<HealthSystem>();
            if (health.ShieldHealth != 0)
            {
                health.ShieldHealth -= 1;
            }
            else if (health.ShieldHealth == 0)
            {
                health.playerHealth -= 1;
            }
        }
        if (coll.gameObject.CompareTag("Bullet"))
        {
            //Instantiate(DeathEffect, transform.position, Quaternion.identity);
            //Destroy(gameObject);
            GetComponent<SpriteRenderer>().color = Color.red;
            Invoke("ResetMat", 0.05f);
            // HealthSystem SN = coll.GetComponent<HealthSystem>();
            // SN.playerHealth -= 1;
        }
    }
    //void Shoot()
    //{
    //    Instantiate(Bullet, firePoint.position, firePoint.rotation);
    //    animator.SetBool("IsShooting", true);
    //}
}
