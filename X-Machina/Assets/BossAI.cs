using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;
public class BossAI : MonoBehaviour
{
    public AIPath aiPath;
    private int rand; //random action
    private float timebetweenaction;
    public float startTime;
    private Animator Anim;
    private float Speed;
    private int count=0;
    public int health;
    public GameObject Bullet;
    public Transform firePoint;
    private bool goingLeft  = true;
    // Start is called before the first frame update
    void Start()
    {
        Anim = GetComponent<Animator>();
        rand = Random.Range(0, 4);
        Speed = aiPath.speed;
    }

    // Update is called once per frame
    void Update()
    {
        Flip();
        action();  

    }

    void action()
    {
        rand = Random.Range(0, 3);
        if (timebetweenaction <= 0)
        {
            timebetweenaction = startTime;
            if (rand == 0)
            {
                Anim.SetBool("Fire", true);
                if (aiPath.desiredVelocity.x >= 0.01f)
                {
                    transform.localScale = new Vector3(1f, 1f, 1f);
                    //goingLeft = true;
                }
                else if (aiPath.desiredVelocity.x <= -0.01f)
                {
                    transform.localScale = new Vector3(-1f, 1f, 1f);
                   // goingLeft = false;
                }
            }
            else if (rand == 1)
            {

                Anim.SetBool("Moving", true);
                if (aiPath.desiredVelocity.x >= 0.01f)
                {
                    transform.localScale = new Vector3(1f, 1f, 1f);
                    //goingLeft = true;
                }
                else if (aiPath.desiredVelocity.x <= -0.01f)
                {
                    transform.localScale = new Vector3(-1f, 1f, 1f);
                   // goingLeft = false;

                }
            }
            else if (rand == 2)
            {
                Anim.SetBool("Jump", true);
                if (aiPath.desiredVelocity.x >= 0.01f)
                {
                    transform.localScale = new Vector3(1f, 1f, 1f);
                    //goingLeft = true;
                }
                else if (aiPath.desiredVelocity.x <= -0.01f)
                {
                    transform.localScale = new Vector3(-1f, 1f, 1f);
                    //goingLeft = false;
                }
            }
        }
        else if (timebetweenaction > 0)
        {
            
            if (aiPath.desiredVelocity.x >= 0.01f)
            {
                transform.localScale = new Vector3(1f, 1f, 1f);
                //goingLeft = true;
                timebetweenaction -= Time.deltaTime;
            }
            else if (aiPath.desiredVelocity.x <= -0.01f)
            {
                transform.localScale = new Vector3(-1f, 1f, 1f);
                //goingLeft = false;
                timebetweenaction -= Time.deltaTime;
            }
        }
    }
    private void Flip()
    {
        if(goingLeft==true)
            firePoint.transform.Rotate(0f,180f,0f);
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
            GetComponent<SpriteRenderer>().color = Color.red;
            Invoke("ResetMat", 0.05f);
        }

       
        void Shoot()
        {
            Instantiate(Bullet, firePoint.position, firePoint.rotation);
            //animator.SetBool("IsShooting", true);
        }
    }
}
