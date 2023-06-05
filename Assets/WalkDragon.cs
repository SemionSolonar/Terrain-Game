using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class WalkDragon : StateMachineBehaviour
{

  float timer;
    List<Transform> wayPoint = new List<Transform>();
    NavMeshAgent agent;
    Transform player;
    Animator animator;
    bool hasSeenPlayer = false; // Track if the player has been seen

    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        Debug.Log("WalkDragon");
        agent = animator.GetComponent<NavMeshAgent>();
        timer = 0;
        GameObject go = GameObject.FindGameObjectWithTag("WayPoints");
        foreach (Transform g in go.transform)
        {
            Debug.Log(g.name);
            wayPoint.Add(g);
        }

        player = GameObject.FindGameObjectWithTag("Player").transform;

        agent.SetDestination(wayPoint[Random.Range(0, wayPoint.Count)].position);
    }

    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        float distanceToPlayer = Vector3.Distance(animator.transform.position, player.position);

        if (!hasSeenPlayer && Physics.Raycast(animator.transform.position, animator.transform.TransformDirection(Vector3.forward), out RaycastHit hit, 8f))
        {
            
                Debug.Log("hit something");
                agent.speed = 3f;
               // animator.transform.LookAt(player);
                agent.SetDestination(player.position);

                if (distanceToPlayer < 3f)
                {
                    //animator.SetBool("Attack", true);
                }
                else
                {
                    animator.SetBool("IsPatrolling", true);
                }

                //hasSeenPlayer = true; // Player has been seen
            
        }
        else
        {
            Debug.Log("hit nothing");
            agent.speed = 1.5f;
            

        }


        if (agent.remainingDistance <= agent.stoppingDistance)
        {
            animator.SetBool("IsPatrolling", false);
        }
    }

    // OnStateExit is called when a transition ends and the state machine finishes evaluating this state
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
