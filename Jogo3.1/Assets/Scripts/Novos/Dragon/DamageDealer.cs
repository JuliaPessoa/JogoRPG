using UnityEngine;

public class DamageDealer : MonoBehaviour
{
    public int damage = 10;
    public string targetTag = "Player";
    private Transform ownerRoot;

    private void Awake()
    {
        ownerRoot = transform.root;
    }

    private void OnTriggerEnter(Collider other)
    {
        Transform targetRoot = other.transform.root;
        Debug.Log("Hitbox tocou em: " + other.name + " | Root: " + targetRoot.name);
        // Não acertar a si mesmo
        if (targetRoot == ownerRoot)
            return;
        // Só acertar o alvo desejado
        if (!targetRoot.CompareTag(targetTag))
            return;
        
        PlayerHealth targetHealth = targetRoot.GetComponent<PlayerHealth>();

        if (targetHealth != null)
        {
            Debug.Log("Dragon acertou o Player! Aplicando dano.");
            targetHealth.TakeDamage(damage);
        }
        else
        {
            Debug.LogWarning("Objeto com tag correta, mas sem Health no root: " + targetRoot.name);
        }
    }
}