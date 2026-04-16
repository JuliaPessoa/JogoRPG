using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerInputHandler2 : MonoBehaviour
{
    private PlayerMovement movement;
    private InteracaoPlayer interaction;
    public PlayerCombat combat;

    private void Awake()
    {
        movement = GetComponent<PlayerMovement>();
        interaction = GetComponent<InteracaoPlayer>();
        combat = GetComponent<PlayerCombat>();
    }



    public void OnMove(InputAction.CallbackContext context)
    {
        if (movement != null)
        {
            movement.SetMoveInput(context.ReadValue<Vector2>());
        }
    }

    public void OnSprint(InputAction.CallbackContext context)
    {
        if (movement != null)
        {
            if (context.performed)
            {
                movement.SetSprint(true);
            }
            else if (context.canceled)
            {
                movement.SetSprint(false);
            }
        }
    }

    public void OnInteract(InputAction.CallbackContext context)
    {
        if (context.performed && interaction != null)
        {
            if (interaction.atualNPC != null)
            {
                interaction.atualNPC.Interagir();
            }
        }
    }

    public void OnAttack(InputAction.CallbackContext context)
    {
        if (context.performed && combat != null)
            combat.LightAttack();
    }

    public void OnHeavyAttack(InputAction.CallbackContext context)
    {
        if (context.performed && combat != null)
            combat.HeavyAttack();
    }
}
