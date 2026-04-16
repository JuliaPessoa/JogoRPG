using UnityEngine;
using UnityEngine.AI;

public class AttackState : StateMachineBehaviour
{
    Transform player;
    private NavMeshAgent agent;
    public float rotationSpeed = 8f;
    public bool playerDead;

    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        agent = animator.GetComponent<NavMeshAgent>();
        playerDead = animator.GetBool("PlayerDead");

        player = GameObject.FindGameObjectWithTag("Player").transform;
        if(agent!=null)
        {
            agent.isStopped = true;
            agent.ResetPath();
            agent.velocity = Vector3.zero;
        }
    }

    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        NavMeshAgent agent = animator.GetComponent<NavMeshAgent>();

        Vector3 target = player.position;
        target.y = animator.transform.position.y;
        animator.transform.LookAt(target);
        // ▼ Distância
        float distance = Vector3.Distance(player.position, animator.transform.position);
        // ▼ DESACELERAÇÃO PROGRESSIVA
        if (agent != null)
        {
            float attackRange = 4.1f; // ajuste conforme seu jogo

            if (distance <= attackRange)
            {
                // Para completamente
                agent.velocity = Vector3.Lerp(agent.velocity, Vector3.zero, Time.deltaTime * 10f);
                agent.isStopped = true;
                agent.ResetPath();
            }
            else
            {
                // Vai desacelerando ao se aproximar
                float slowFactor = Mathf.Clamp01(distance / attackRange);
                agent.velocity *= slowFactor;
            }
        }
        
        if (player == null || !player.gameObject.activeInHierarchy)
        {
            animator.SetBool("IsAttacking", false);
            animator.SetBool("IsChasing", false);
            agent.isStopped = false;
            animator.SetBool("IsPatrolling", false);
            animator.SetBool("PlayerDead", true);
            return;
        }

        // Sai do ataque se estiver longe
        if (distance > 25)
            animator.SetBool("IsAttacking", false);
    }

    // OnStateExit is called when a transition ends and the state machine finishes evaluating this state
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        if (agent != null)
        {
            agent.isStopped = false;
        }
    }
}