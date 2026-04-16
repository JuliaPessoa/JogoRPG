using UnityEngine;

public class Teleporte : MonoBehaviour
{
    public GerenteDeCena gerente;
    public string destino;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        gerente = FindAnyObjectByType<GerenteDeCena>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            gerente.AbrirCena(destino);
        }
    }
}
