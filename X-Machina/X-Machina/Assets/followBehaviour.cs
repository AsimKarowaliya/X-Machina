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
    BossAI boss1;
    private int rand;
    private int number = 0;
    public float timebetweenattack=0;
    public float durTime=1;
   // public GameObject VS;
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        playerPos = GameObject.FindGameObjectWithTag("Player").transform;
        boss = GameObject.FindGameObjectWithTag("Player").transform;

        // System.Console.WriteLine("hi");

    }

    //OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        distance = System.Math.Abs(animator.transform.position.x - playerPos.position.x);
        high = playerPos.position.y - animator.transform.position.y;
        //if(distance<15f)
        //194
        if (playerPos.position.x > 194 && number == 0 && !animator.GetBool("boss70%"))
        {
            //playerPos.position = new Vector2(160, -35);
           
           //Time.timeScale = 0.5f;
           // VS.SetActive(true);
           // timebetweenattack += Time.deltaTime;
            number++;
        }
        if ( number > 0)
        {
            timebetweenattack += Time.deltaTime;
            if (timebetweenattack > durTime)
            {
              //  VS.SetActive(false);
               // Time.timeScale = 1;
            }
            animator.transform.position = Vector2.MoveTowards(animator.transform.position, playerPos.position, speed * Time.deltaTime);
            number++;
        }
        //System.Console.WriteLine(playerPos.position.x);
        if (distance < 2 && high < 2)
            animator.SetBool("atk", true);
        //Debug.Log(distance);
        rand = Random.Range(0, 2);


    }

    //OnStateExit is called when a transition ends and the state machine finishes evaluating this state
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {

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
