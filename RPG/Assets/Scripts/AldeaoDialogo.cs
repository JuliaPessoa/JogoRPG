using UnityEngine;

public class AldeaoDialogo : MonoBehaviour
{
    public string npcName = "Aldeão";
    
    Animator anim;
    
    [TextArea] public string[] falas;
    
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
        if (falas.Length == 0)
        {
            anim.SetBool("isTalking", false);
            return;
        }

        anim.SetBool("isTalking", true);
        Debug.Log(npcName + ": " + falas[index]);
        index++;
        if (index >= falas.Length)
        {
            index = 0;
            anim.SetBool("isTalking", false);
        }

    }
}
