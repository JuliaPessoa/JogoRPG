using UnityEngine;

public class PlayerCombat : MonoBehaviour
{
 [Header("Referências")]
    public Animator animator;
    public PlayerMovement movement;

    [Header("Combate")]
    public float lightCooldown = 0.45f;
    public float heavyCooldown = 0.8f;
    public bool lockMovementDuringAttack = true;

    private bool isAttacking = false;
    private float lastAttackTime = -10f;

    private void Awake()
    {
        if (animator == null)
            animator = GetComponentInChildren<Animator>();
        
        if (movement == null)
            movement = GetComponent<PlayerMovement>();
    }

    public void LightAttack()
    {
        if (!CanAttack(lightCooldown)) return;

        StartAttack("LightAttack");
    }

    public void HeavyAttack()
    {
        if (!CanAttack(heavyCooldown)) return;

        StartAttack("HeavyAttack");
    }

    private bool CanAttack(float cooldown)
    {
        if (animator == null) return false;
        if (isAttacking) return false;
        if (Time.time < lastAttackTime + cooldown) return false;

        return true;
    }

    private void StartAttack(string triggerName)
    {
        isAttacking = true;
        lastAttackTime = Time.time;

        animator.SetBool("IsAttacking", true);
        animator.ResetTrigger("LightAttack");
        animator.ResetTrigger("HeavyAttack");
        animator.SetTrigger(triggerName);

        if (lockMovementDuringAttack && movement != null){

            movement.SetMovementEnabled(false);

        }
            
    }

    // Chamar por Animation Event no fim do golpe
    public void EndAttack()
    {
        isAttacking = false;

        if (animator != null)
            animator.SetBool("IsAttacking", false);

        if (lockMovementDuringAttack && movement != null){

            movement.SetMovementEnabled(true);

        }
            
    }

    public bool IsAttacking()
    {
        return isAttacking;
    }
}
