using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;

public class Enemy : MonoBehaviour
{
    public int health;
    public Rigidbody2D rb;
    public float speed;
    public AIPath aiPath;
    // Start is called before the first frame update
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
            transform.localScale = new Vector3(-3f, 3f, 3f);
        }
        else if (aiPath.desiredVelocity.x <= -0.01f)
        {
            transform.localScale = new Vector3(3f,3f, 3f);
        }
        if (health <= 0)
        {
            Destroy(gameObject);
        }
    }
    public void takeDamage(int damage)
    {
        health -= damage;
    }
}
