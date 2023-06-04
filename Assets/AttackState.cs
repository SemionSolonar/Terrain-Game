using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class AttackState : StateMachineBehaviour
{
    
    Animator animator;
    Transform player;

    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        this.animator = animator;
        player = GameObject.FindGameObjectWithTag("Player").transform;
    }

    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        animator.transform.LookAt(player);
        float distanceToPlayer = Vector3.Distance(player.position, animator.transform.position);
        if (distanceToPlayer > 3f)
        {
            animator.SetBool("Attack", false);
        }
        // if (Physics.Raycast(animator.transform.position, animator.transform.TransformDirection(Vector3.forward), out RaycastHit hit, 3f))

        // {
        //     Debug.Log("hit something");
        //     animator.SetBool("Attack", true);
        // }
        // else
        // {
        //     Debug.Log("hit nothing");
        //     animator.SetBool("Attack", false);
        // }
    }

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
