using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grenade : MonoBehaviour
{
    public int damage = 5;
    public float radius = 3;
    public float force = 0.3f;
    float timer = 3;
    float countdown;
    public GameObject explosionParticle;

    private bool suicide;
    public Rigidbody2D grenadeBody;
    // Start is called before the first frame update
    void Start()
    {
        grenadeBody.velocity = transform.right * force;
    }

    // Update is called once per frame
    void Update()
    {
        //GetComponent<Rigidbody2D>().velocity = new Vector3(2, 0, 0);
        if (Input.GetKeyDown(KeyCode.T))
        {
            //GetComponent<Rigidbody2D>().velocity = transform.forward;
            //transform.Translate(transform.right * 10 * Time.smoothDeltaTime);
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
            Destroy(this.gameObject);
        }
    }

    void Explode()
    {
        GameObject explosion = Instantiate(explosionParticle, transform.position, transform.rotation);
        Destroy(explosion, 1);

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
    }

    public void SuicideBombing()
    {
        suicide = true;
    }
}
