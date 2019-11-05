using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;
public class BossAI : MonoBehaviour
{
    public AIPath aiPath;
    private int rand; //random action
    private float movespeed;
    private float timebetweenaction;
    public float startTime;
    private Animator Anim;
    private float Speed;
    private int count=0;
    public int health;
    public int healthCopy;
    public GameObject Bullet;
    public Transform fire;
    private bool goingLeft  = true;
    public Rigidbody2D rb;
    private Transform playerPos; //posiation
    private Transform boss;
    public float distance;
    public float high;
    public GameObject deathEffect;
    private int number=0;
    BossBoom boom;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        Anim = GetComponent<Animator>();
        healthCopy = health;
        playerPos = GameObject.FindGameObjectWithTag("Player").transform;
        boss = GameObject.FindGameObjectWithTag("Boss1").transform;
    }

    // Update is called once per frame
    void Update()
    {
        //if(System.Math.Abs(distance)<15f)
        action();
        if (health <= 0)
        {
            
            Die();
        }
    }

    void action()
    {
        
        //Debug.Log(a.distance);
        distance = boss.position.x - playerPos.position.x;
        high = playerPos.position.y - boss.position.y;
        if (distance <= -0.01f)
                {
            if (goingLeft == false)
                fire.transform.Rotate(0f, 180f, 0f);
            goingLeft = true;

            transform.localScale = new Vector3(1f, 1f, 1f);
            
            //goingLeft = true;
        }
        else if (distance >= 0.01f)
        {
            if (goingLeft==true)
                fire.transform.Rotate(0f, 180f, 0f);
            goingLeft = false;
            transform.localScale = new Vector3(-1f, 1f, 1f);
           
            // goingLeft = false;
        }
        



    }
    void Die()
    {
        if (distance <= -0.01f)
        {
            deathEffect.transform.localScale = new Vector3(2.4f, 2.4f, 1f);
           
        }
        else if (distance >= 0.01f)
        {
            deathEffect.transform.localScale = new Vector3(-2.4f, 2.4f, 1f);
        }
        Instantiate(deathEffect, transform.position, Quaternion.identity);
        Destroy(gameObject);
    }
    public void TakeDamage(int damage)
    {
        health -= damage;
    }
    private void Flip()
    {
        if(goingLeft==true)
            fire.transform.Rotate(0f,180f,0f);
    }
    void OnCollisionEnter2D(Collision2D coll)
    {
        rand = Random.Range(0, 2);
        movespeed= Random.Range(2, 6);
        int jumphigh = Random.Range(3, 12);
        
        if (health > 0.7 * healthCopy)
        {
            if (rand == 0)
            {
                if (high > 2)
                {
                    if (distance <= -0.01f)
                    {
                        Anim.SetBool("Jump", true);
                        rb.velocity = new Vector2(movespeed, 12);

                    }
                    else if (distance >= 0.01f)
                    {
                        Anim.SetBool("Jump", true);
                        rb.velocity = new Vector2(-movespeed, 12);

                    }
                }
            }
            else if (rand == 1)
            {
                if (System.Math.Abs(distance) > 1)
                {
                    if (distance <= -0.01f)
                    {
                        Anim.SetBool("runing", true);
                        rb.velocity = new Vector2(5f, rb.velocity.y);
                        //Anim.SetBool("runing", false);
                    }
                    else if (distance >= 0.01f)
                    {
                        Anim.SetBool("runing", true);
                        rb.velocity = new Vector2(-5f, rb.velocity.y);
                        //Anim.SetBool("runing", false);
                    }
                }
            }
        }
        else if (health <= 0.7 * healthCopy)
        {

            if (number == 0)
            {
                Anim.SetBool("boss70%", true);
                number++;
            }
            else if (number == 1 && health <= 0.3 * healthCopy)
            {
                Anim.SetBool("boss30%", true);
            }

          
            if (Anim.GetCurrentAnimatorStateInfo(0).IsName("BossMove 0")&& System.Math.Abs(distance) > 4)
            {
                Shoot();
            }

            if (Anim.GetBool("boss30%"))
            {
                //boom.speed = Random.Range(8, 15);
                Shoot();
         
                if (distance <= -0.01f)
                {
                    Anim.SetBool("Jump", true);
                    rb.velocity = new Vector2(movespeed, jumphigh);

                }
                else if (distance >= 0.01f)
                {
                    Anim.SetBool("Jump", true);
                    rb.velocity = new Vector2(-movespeed, jumphigh);

                }
            }
            else if (rand == 0)
            {
                if (high > 2)
                {
                    if (distance <= -0.01f)
                    {
                        Anim.SetBool("Jump", true);
                        rb.velocity = new Vector2(movespeed, 12);

                    }
                    else if (distance >= 0.01f)
                    {
                        Anim.SetBool("Jump", true);
                        rb.velocity = new Vector2(-movespeed, 12);

                    }
                }
            }
            else if (rand == 1)
            {
                if (System.Math.Abs(distance) > 2)
                {
                    if (distance <= -0.01f)
                    {
                        Anim.SetBool("runing", true);
                        rb.velocity = new Vector2(7f, rb.velocity.y);
                        //Anim.SetBool("runing", false);
                    }
                    else if (distance >= 0.01f)
                    {
                        Anim.SetBool("runing", true);
                        rb.velocity = new Vector2(-7f, rb.velocity.y);
                        //Anim.SetBool("runing", false);
                    }
                }
               
            }
        }

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
            GetComponent<SpriteRenderer>().color = Color.red;
            Invoke("ResetMat", 0.05f);
        }

       
        
    }
    void Shoot()
    {
        Instantiate(Bullet, fire.position, fire.rotation);
        //animator.SetBool("IsShooting", true);
    }
}
