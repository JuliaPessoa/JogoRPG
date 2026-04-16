using UnityEngine;

public class InteracaoAldeao : MonoBehaviour
{
    public GameObject promptInteracao; 

    public Transform player;

    Animator anim;

    public float velocidadeRotacao = 5f;

    private bool playerPerto = false;

    public AldeaoDialogo aldeao;

    public GameObject chamadaAtencao;
    
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
            chamadaAtencao.SetActive(true);
            playerPerto = true;
            player = outro.transform;
            if (promptInteracao != null)
                promptInteracao.SetActive(true);
            Debug.Log("Player entrou na área do NPC.");
            anim.SetBool("IsPlayer", true);
            anim.SetBool("isAngry", false);
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
            anim.SetBool("IsPlayer", false);

            if (aldeao.index < aldeao.falas.Length)
            {
                anim.SetBool("isAngry", true);
                print("afff");
            }
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
