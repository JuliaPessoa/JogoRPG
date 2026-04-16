using UnityEngine;
using UnityEngine.SceneManagement;

public class GerenteDeCena : MonoBehaviour
{
    public float t;
    public string cenaAtual;
    public int duracaoAbertura = 30;
    public int duracaoCreditos = 30;
    public void Start()
    {
        t = 0;
        cenaAtual = SceneManager.GetActiveScene().name;
    }
    void Update()
    {
        
        t += Time.deltaTime;
        
        if (t > duracaoAbertura) //tempo em segundos do áudio de abertura
        {
            if(cenaAtual == "Abertura")
            {
                SceneManager.LoadScene("Despertar");
            }
            if (cenaAtual == "Creditos")
            {
                SceneManager.LoadScene("MenuPrincipal");
            }            
            
        }



    }
    public void AbrirCena(string nome)
    {
        SceneManager.LoadScene(nome); //Abre a cena 
    }
    public void ReiniciarJogo()
    {        
        SceneManager.LoadScene(SceneManager.GetActiveScene().name); //Reinicia o jogo
    }

    public void Sair()
    {
        print("Saiu");
        Application.Quit(); //Sai do jogo, mas não funciona nos testes na unity
    }
}
