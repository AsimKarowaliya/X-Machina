using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grenade : MeleeScript
{
    public int damage;
    public float radius;
    public float force;
    float timer = 3;
    float countdown;
    public GameObject explosionParticle;

    public bool suicide = false;
    public Rigidbody2D grenadeBody;
    
    // Start is called before the first frame update
    void Start()
    {
        grenadeBody.velocity = transform.right * force;
        suicide = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (suicide)
        {
            transform.position += Vector3.right * Time.deltaTime * speed;
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
       
        if (collision.gameObject.tag == "Player")
        {
            Physics2D.IgnoreCollision(GetComponent<Collider2D>(), collision.collider);
        }
        if (collision.gameObject.CompareTag("Enemy"))
        {
            Explode();
            Die();
            Destroy(collision.gameObject);
          
            //grenadeCollider.enabled = false;
            //spriteRenderer.enabled = false;
        }
    }

    void Explode()
    {
        GameObject explosion = Instantiate(explosionParticle, transform.position, transform.rotation);
        Destroy(explosion, 1);
        GameObject des = GameObject.FindWithTag("Grenade");
        Destroy(des);
        Collider2D collider = Physics2D.OverlapCircle(transform.position, radius);
        //collider.GetComponent<MeleeScript>().TakeDamage(damage);
        //foreach (Collider2D nearbyObject in collider)
        //{
        //    nearbyObject.GetComponent<MeleeScript>().TakeDamage(damage);
        //}


        Enemy enemy = collider.GetComponent<Enemy>();
        Patrol2 enemyMech = collider.GetComponent<Patrol2>();
        MeleeScript enemyMelee = collider.GetComponent<MeleeScript>();
        flyEnemy enemyfly = collider.GetComponent<flyEnemy>();
        GroundMechScript groundMech = collider.GetComponent<GroundMechScript>();
        BossAI boss = collider.GetComponent<BossAI>();
        if (enemy != null)
        {
            enemy.TakeDamage(damage);

        }
        else if (enemyMech != null)
        {
            enemyMech.TakeDamage(damage);
        }
        else if (enemyMelee != null)
        {
            enemyMelee.TakeDamage(damage);
        }
        else if (enemyfly != null)
        {
            enemyfly.TakeDamage(damage);
        }
        else if (groundMech != null)
        {
            groundMech.TakeDamage(damage);
        }
        else if (boss != null)
        {
            boss.TakeDamage(damage);
        }
        //Destroy(gameObject);
    }

    public void SuicideBombing()
    {
        suicide = true;
    }
}
