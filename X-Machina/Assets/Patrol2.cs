using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Patrol2 : MonoBehaviour
{
    float speed = 1;
    public float distance;
    private bool goingRight = true;
    public Transform target;
    public Transform firePoint;
    public GameObject Bullet;
    public float shootDistance;
    private float timebetweenattack;
    public float startTime;
    public Animator animator;
    public int health;
    public GameObject deathEffect;
    public int damage = 1;
    // Start is called before the first frame update
    
    void Update()
    {
        RaycastHit2D hitinfo = Physics2D.Raycast(firePoint.position, Vector2.right, shootDistance);
        RaycastHit2D hitinfo2 = Physics2D.Raycast(firePoint.position, Vector2.left, shootDistance);
        if (hitinfo.collider == true && hitinfo.transform.CompareTag("Player") && goingRight == true)
        {
            if (timebetweenattack <= 0)
            {
                timebetweenattack = startTime;
            
                Shoot();
            }
            else
            {
                timebetweenattack -= Time.deltaTime;
            }

            speed = 1;
            if (!hitinfo2.transform.CompareTag("Player"))
            {
                speed = 1;
            }

        }
        else if (hitinfo2.collider == true && hitinfo2.transform.CompareTag("Player") && goingRight == false)
        {
            if (timebetweenattack <= 0)
            {
                timebetweenattack = startTime;
                Shoot();
            }
            else
            {
                timebetweenattack -= Time.deltaTime;
            }
            
            speed = 1;
            if (!hitinfo2.transform.CompareTag("Player"))
            {
                speed = 1;
            }
        }
        else
        {
            transform.Translate(Vector2.right * speed * Time.deltaTime);
            animator.SetBool("IsShooting", false);
        }
        
        RaycastHit2D groundInfo = Physics2D.Raycast(target.position, Vector2.down, distance);
        if (groundInfo.collider == false)
        {
            if (goingRight == true)
            {
                transform.eulerAngles = new Vector3(0, -180, 0);
                goingRight = false;
            }
            else
            {
                transform.eulerAngles = new Vector3(0, 0, 0);
                goingRight = true;
            }
        }

        if (health <= 0)
        {
            Die();
        }

        //RaycastHit2D wallinfo = Physics2D.Raycast(target.position, Vector2.left, distance);
        //if (wallinfo.collider == true && wallinfo.transform.gameObject.tag != "Player")
        //{
        //    if (goingRight == true)
        //    {
        //        transform.eulerAngles = new Vector3(0, -180, 0);
        //        goingRight = false;
        //    }
        //    else
        //    {
        //        transform.eulerAngles = new Vector3(0, 0, 0);
        //        goingRight = true;
        //    }
        //}


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

    void ResetMat()
    {
        GetComponent<SpriteRenderer>().color = Color.white;
    }
    void OnTriggerEnter2D(Collider2D coll)
    {
        //Debug.Log(gameObject.name);
        if (coll.CompareTag("Player"))
        {
            HealthSystem health = coll.GetComponent<HealthSystem>();

            health.playerHealth -= 1;
        }
        if (coll.CompareTag("Bullet"))
        {
            //Instantiate(DeathEffect, transform.position, Quaternion.identity);
            //Destroy(gameObject);
            GetComponent<SpriteRenderer>().color = Color.red;
            Invoke("ResetMat", 0.05f);
            // HealthSystem SN = coll.GetComponent<HealthSystem>();
            // SN.playerHealth -= 1;
        }

    }
    void Shoot()
    {
        Instantiate(Bullet, firePoint.position, firePoint.rotation);
        animator.SetBool("IsShooting", true);
    }
}
