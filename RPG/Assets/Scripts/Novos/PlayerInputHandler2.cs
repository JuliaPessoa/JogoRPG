using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerInputHandler2 : MonoBehaviour
{
    private PlayerMovement movement;
    private PlayerInteraction interaction;
    public PlayerCombat combat;

    private void Awake()
    {
        movement = GetComponent<PlayerMovement>();
        interaction = GetComponent<PlayerInteraction>();
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
            //interaction.TryInteract();
        }
    }

    public void OnAttack(InputAction.CallbackContext context)
    {
        if (combat == null) return;

        if (context.performed)
        {
            combat.Attack();
        }
    }
}
