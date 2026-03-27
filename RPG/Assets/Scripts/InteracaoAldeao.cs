using UnityEngine;

public class InteracaoAldeao : MonoBehaviour
{
    public GameObject promptInteracao; // ex.: texto "Pressione E para interagir"

    public Transform player;

    Animator anim;

    public float velocidadeRotacao = 5f;

    private bool playerPerto = false;
    
    private void Start()
    {
        anim = GetComponent<Animator>();
        if (promptInteracao != null)
            promptInteracao.SetActive(false);
    }

    private void OnTriggerEnter(Collider outro)
    {
        if (outro.CompareTag("Player"))
        {
            playerPerto = true;
            player = outro.transform;
            if (promptInteracao != null)
                promptInteracao.SetActive(true);
            Debug.Log("Player entrou na área do NPC.");
            anim.SetBool("isPlayer", true);
        }
    }
    
    private void OnTriggerExit(Collider outro)
    {
        if (outro.CompareTag("Player"))
        {
            playerPerto = false;
            player = null;
            if (promptInteracao != null)
                promptInteracao.SetActive(false);
            Debug.Log("Player saiu da área do NPC."); 
            anim.SetBool("isPlayer", false);
        }
            
            
        
    }
        
    
    private void Update()
    {
        if (playerPerto && player != null)
        {
            // Faz o NPC olhar para o player
            Vector3 direcao = player.position - transform.position;
            direcao.y = 0f;
            if (direcao != Vector3.zero)
            {
                Quaternion targetRotation = Quaternion.LookRotation(direcao);
                transform.rotation = Quaternion.Slerp(
                            transform.rotation,
                            targetRotation,
                            velocidadeRotacao * Time.deltaTime);
            }
    
    
        }
            
    }
    
}
