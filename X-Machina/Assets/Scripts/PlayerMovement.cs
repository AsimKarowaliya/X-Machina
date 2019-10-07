using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    public CharacterController2D controller;

    public float runSpeed = 40f;
    //public float runfast = 40f;

    public Animator animator;

    float horizontalMove = 0f;
    //float horizontalfastMove = 0f;


    bool jump = false;

    //bool crouch = false;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.LeftShift))
        {
            horizontalMove = Input.GetAxisRaw("Horizontal") * runSpeed * 2;
        }
        else
        {
            horizontalMove = Input.GetAxisRaw("Horizontal") * runSpeed;
        }

        animator.SetFloat("Speed", Mathf.Abs(horizontalMove));

        if (Input.GetButtonDown("Jump"))
        {
            jump = true;
            animator.SetBool("IsJumping", true);
        }


        /**
         if(Input.GetButtonDown("Crouch"))
            {
                crouch = true;
             } else if (Input.GetButtonUp("crouch")({
                crouch = false;
            }
        **/
    }

    public void OnLanding()
    {
        animator.SetBool("IsJumping", false);
    }
    void FixedUpdate()
    {
        controller.Move(horizontalMove * Time.fixedDeltaTime, false, jump);
        jump = false;
    }

}