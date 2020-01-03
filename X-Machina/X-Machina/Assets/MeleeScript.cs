using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeleeScript : MonoBehaviour
{
    public float speed;
    public float distance;
    private bool goingRight = true;
    public Transform target;
    public int health;
    public int damage;
    public GameObject deathEffect;
    private Rigidbody2D rb;
    private Color originColor;
    // Start is called before the first frame update
    private void Start()
    {
        originColor = GetComponent<SpriteRenderer>().color;
    }
    // Update is called once per frame
    void FixedUpdate()
    {
        transform.Translate(Vector2.right * speed * Time.deltaTime);
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

        RaycastHit2D wallinfo = Physics2D.Raycast(target.position, Vector2.left, distance);
        if (wallinfo.collider == true && wallinfo.transform.gameObject.tag != "Player")
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
    }
    public void TakeDamage(int damage)
    {
        health -= damage;
    }
    public void Die()
    {
        Instantiate(deathEffect, transform.position, Quaternion.identity);
        Destroy(gameObject);
    }

    void ResetMat()
    {
        GetComponent<SpriteRenderer>().color = originColor;
    }
    void OnCollisionEnter2D(Collision2D coll)
    {
        //Debug.Log(gameObject.name);
        if (coll.gameObject.CompareTag("Player"))
        {
            HealthSystem health = coll.gameObject.GetComponent<HealthSystem>();
            if(health.ShieldHealth != 0)
            {
                health.ShieldHealth -= damage;
            }else if (health.ShieldHealth == 0)
            {
                health.playerHealth -= damage;
            }
        }
        if (coll.gameObject.CompareTag("BlueBullet"))
        {
            //Instantiate(DeathEffect, transform.position, Quaternion.identity);
            //Destroy(gameObject);
            GetComponent<SpriteRenderer>().color = Color.red;
            Invoke("ResetMat", 0.5f);
            // HealthSystem SN = coll.GetComponent<HealthSystem>();
            // SN.playerHealth -= 1;
        }
    }
}
