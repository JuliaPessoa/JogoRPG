using UnityEngine;
using TMPro;
using System.Collections;

public class AldeaoDialogo : MonoBehaviour
{
    public string npcName = "Aldeão";
    
    Animator anim;
    
    [TextArea] public string[] falas;

    public TextMeshProUGUI texto;
    public TextMeshProUGUI nome;
    public GameObject caixaDialogo;
    public GameObject nextButton;
    public GameObject endButton;
    
    public int index = 0;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Interagir()
    {
        anim.SetBool("isTalking", true);
        caixaDialogo.SetActive(true);

        if (falas.Length == 0 || index == -1)
        {
            texto.text ="Já conversamos demais, você deveria ir ao vilarejo";
            nextButton.SetActive(false);
            endButton.SetActive(true);

            return;
        }

        nome.text = npcName;
        ProximaFala();

    }

    public void ProximaFala()
    {        
        texto.text =  falas[index];
        Debug.Log(npcName + ": " + falas[index]);
        index++;
        if (index >= falas.Length)
        {
            index = -1;
            nextButton.SetActive(false);
            endButton.SetActive(true);            
        }
    }

    public void EncerrarDialogo()
    {
        anim.SetBool("isTalking", false);
        caixaDialogo.SetActive(false);
    }
}
