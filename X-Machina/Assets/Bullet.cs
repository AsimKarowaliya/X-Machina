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
    
    // use this to kill the AI
    void OnTriggerEnter2D(Collider2D hitInfo)
    {
        Enemy enemy = hitInfo.GetComponent<Enemy>();
        EnemyMech enemyMech= hitInfo.GetComponent<EnemyMech>();
        if (enemy !=null)
        {
            enemy.TakeDamage(Damage);
            
        }
        else if(enemyMech != null)
        {
            enemyMech.TakeDamage(Damage);
        }
        Instantiate(impactEffect, transform.position, transform.rotation);
        Destroy(gameObject);
        Destroy(other);
    }
    
}
