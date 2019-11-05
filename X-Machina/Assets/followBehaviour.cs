using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Text;


public class followBehaviour : StateMachineBehaviour
{
    private Transform playerPos; //posiation
    private Transform boss;
    public float speed;
    public float jumpPower;
    public float distance;
    public float high;
    private BossAI boss1;
    private int rand;
    private int number = 0;
    private int number1 = 0;
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        playerPos = GameObject.FindGameObjectWithTag("Player").transform;
        boss= GameObject.FindGameObjectWithTag("Player").transform;
        
        // System.Console.WriteLine("hi");

    }

    //OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        distance = System.Math.Abs(animator.transform.position.x - playerPos.position.x);
        high = playerPos.position.y- animator.transform.position.y ;
        //if(distance<15f)
       
            animator.transform.position = Vector2.MoveTowards(animator.transform.position, playerPos.position, speed * Time.deltaTime);

        //rand = Random.Range(0,3);

        


    }

    //OnStateExit is called when a transition ends and the state machine finishes evaluating this state
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
       
           // animator.SetBool("runing", true);
    }

    // OnStateMove is called right after Animator.OnAnimatorMove()
    //override public void OnStateMove(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    //{
    //    // Implement code that processes and affects root motion
    //}

    // OnStateIK is called right after Animator.OnAnimatorIK()
    //override public void OnStateIK(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    //{
    //    // Implement code that sets up animation IK (inverse kinematics)
    //}
}
