using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;

public class EnemyMech : MonoBehaviour
{
    public int health;
    public Rigidbody2D rb1;
    public float speed;
    public AIPath aiPath1;
    public GameObject deathEffect;
    public int Damage = 1;
    public Transform firePoint;
    public GameObject Bullet;
    private float InstantiationTimer = 2f;
    // Start is called before the first frame update
    void Start()
    {
        rb1 = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {

        // rb.MovePosition(rb.position + Vector2.left *speed* Time.deltaTime);
        if (aiPath1.desiredVelocity.x >= 0.01f && aiPath1.desiredVelocity.x<5f)
        {
            transform.localScale = new Vector3(-2f, 2f, 2f);
            
            Shoot();
        }
        else if (aiPath1.desiredVelocity.x <= -0.01f && aiPath1.desiredVelocity.x > -5f)
        {
            transform.localScale = new Vector3(2f, 2f, 2f);
            Shoot();
        }
        
        if (health <= 0)
        {
            Die();
        }
    }
    void Shoot()
    {
        InstantiationTimer -= Time.deltaTime;
        RaycastHit2D hitinfo = Physics2D.Raycast(firePoint.position, firePoint.right);

        if (hitinfo)
        {
            Player player = hitinfo.transform.GetComponent<Player>();
            if (player != null)
            {
                //player.TakeDamage();
            }
            if(InstantiationTimer <= 0)
            {
                Instantiate(Bullet, firePoint.position, firePoint.rotation);
                InstantiationTimer = 2f;
            }
           
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

    void ResetMat()
    {
        GetComponent<SpriteRenderer>().color = Color.white;
    }
    void OnTriggerEnter2D(Collider2D coll)
    {
        //Debug.Log(gameObject.name);

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
}
