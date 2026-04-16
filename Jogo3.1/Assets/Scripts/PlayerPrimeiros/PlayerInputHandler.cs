using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerInputHandler : MonoBehaviour
{
    public InputAction interagir;
    private InteracaoPlayer interacao;

    private void Awake()
    {
        interacao = GetComponent<InteracaoPlayer>();
    }
    private void OnEnable()
    {
        interagir.Enable();
        interagir.performed += OnInteract;
    }
    private void OnDisable()
    {
        interagir.performed -= OnInteract;
        interagir.Disable();
    }

    private void OnInteract(InputAction.CallbackContext context)
    {
        if (interacao.atualNPC != null)
        {
            interacao.atualNPC.Interagir();
        }

        else
        {

            Debug.Log("Nenhum NPC por perto");

        }
    }


}
