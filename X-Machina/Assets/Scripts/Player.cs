using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float Speed = 10f;
    public float jumpForce;

    bool IsJumping;
    bool facingRight = true;

    public Rigidbody2D body;

    public Animator anim;


    // Start is called before the first frame update
    void Start()
    {
        body = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        float move = Input.GetAxis("Horizontal");

        anim.SetFloat("Speed", Mathf.Abs(move));

        body.velocity = new Vector2(move * Speed, body.velocity.y);

            Jump();

        if (move > 0 && !facingRight)
        {
            
            Flip();
            
        }else if(move <0 && facingRight)
        {
           
            Flip();

          
        }
         
        
    }

    void Jump()
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {
            IsJumping = true;
            anim.SetBool("IsJumping", true);
            body.AddForce(new Vector2(body.velocity.x, jumpForce));
            Invoke("Delay", 0.2f);
        }
        else
        {
            anim.SetBool("IsJumping", false);
        }
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Ground"))
        {
            IsJumping = false;

            body.velocity = Vector2.zero;
        }
    }

    void Flip()
    {
        facingRight = !facingRight;
        Vector3 theScale = transform.localScale;
        theScale.x *= -1;
        transform.localScale = theScale;
    }
}
