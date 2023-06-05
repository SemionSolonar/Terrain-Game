using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;


public class WalkingState : StateMachineBehaviour
{
    float timer;
    List<Transform> WayPoints = new List<Transform>();
    NavMeshAgent agent;
    Transform player;
    Animator animator;
    GameObject Remy;

    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        agent = animator.GetComponent<NavMeshAgent>();
        Remy = GameObject.FindGameObjectWithTag("Remy");
        timer = 0;
        GameObject go = GameObject.FindGameObjectWithTag("WayPoints");
        foreach (Transform g in go.transform)
        {
            WayPoints.Add(g);
        }

        player = GameObject.FindGameObjectWithTag("Player").transform;

        agent.SetDestination(WayPoints[Random.Range(0, WayPoints.Count)].position);
    }

    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        float distanceToPlayer = Vector3.Distance(animator.transform.position, player.position);

        if (Physics.Raycast(animator.transform.position, animator.transform.TransformDirection(Vector3.forward), out RaycastHit hit, 13f))
        {
            //Debug.Log("hit something");
            agent.speed = 3f;
            //animator.transform.LookAt(player);
            agent.SetDestination(player.position);
            animator.transform.LookAt(player);
           
            if (distanceToPlayer < 3f)
            {
                animator.SetBool("Attack", true);
                Remy.GetComponent<RemyScript>().TakeDamage(100f);
            

            }
          
           
        }
        else
        {
           // Debug.Log("hit nothing");
            agent.speed = 1.5f;
            

        }

        if (agent.remainingDistance <= agent.stoppingDistance)
        {
            animator.SetBool("IsWalking", false);
        }
    }

    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        agent.SetDestination(agent.transform.position);
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
