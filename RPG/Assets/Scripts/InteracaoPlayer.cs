using UnityEngine;

public class InteracaoPlayer : MonoBehaviour
{
    public AldeaoDialogo atualNPC;

    // O trigger de colisão dispara este método que configura o atualNPC como o Aldeão if (npc != null)
    private void OnTriggerEnter(Collider outro)
    {
        AldeaoDialogo npc = outro.GetComponent<AldeaoDialogo>();
        atualNPC = npc;
    }

    private void OnTriggerExit(Collider outro)
    {
        AldeaoDialogo npc = outro.GetComponent<AldeaoDialogo>();
        // Quando o Player afasta-se do Aldeão, libera outras interações com o player if (npc != null && npc == atualNPC)
        {
            atualNPC = null;
        }

    }
}
