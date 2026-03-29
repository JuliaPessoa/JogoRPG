using UnityEngine;

public class PlayerCombat : MonoBehaviour
{
    public Animator animator;  
    public void Attack()
    {
        if (animator == null)
        {
            Debug.LogError("Animator NULL no PlayerCombat");
            return;
        }

        animator.SetTrigger("Attack");
    }
}
