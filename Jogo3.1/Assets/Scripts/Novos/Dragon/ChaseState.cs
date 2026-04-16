using UnityEngine;
using UnityEngine.AI;

public class ChaseState : StateMachineBehaviour
{
    NavMeshAgent agent;
    public Transform player;

    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        agent = animator.GetComponent<NavMeshAgent>();
        GameObject playerObj = GameObject.FindGameObjectWithTag("Player");
        if (playerObj != null)
            player = playerObj.transform;
    }

    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        if (player == null)
        {
            animator.SetBool("IsChasing", false);
            animator.SetBool("IsAttacking", false);
            return;
        }
        if (!player.gameObject.activeInHierarchy)
        {
            animator.SetBool("IsChasing", false);
            animator.SetBool("IsAttacking", false);
            agent.isStopped = true;
            return;
        }
        agent.isStopped = false;
        agent.SetDestination(player.position);
        float distance = Vector3.Distance(player.position, animator.transform.position);
        if (distance > 30f)
            animator.SetBool("IsChasing", false);
        if (distance < 4.5f)
            animator.SetBool("IsAttacking", true);
        else
            animator.SetBool("IsAttacking", false);
    }
}