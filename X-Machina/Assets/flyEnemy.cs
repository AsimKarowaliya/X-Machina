using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;

public class flyEnemy : MonoBehaviour
{
    public int health;
    public Rigidbody2D rb;
    public float speed;
    public AIPath aiPath;
    public GameObject deathEffect;
    public int Damage = 1;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        // rb.MovePosition(rb.position + Vector2.left *speed* Time.deltaTime);
        if (aiPath.desiredVelocity.x >= 0.01f)
        {
            transform.localScale = new Vector3(-2f, 2f, 2f);
        }
        else if (aiPath.desiredVelocity.x <= -0.01f)
        {
            transform.localScale = new Vector3(2f, 2f, 2f);
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
}
