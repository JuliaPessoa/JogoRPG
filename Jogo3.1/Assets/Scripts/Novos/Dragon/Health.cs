using UnityEngine;
using UnityEngine.UI;

public class Health : MonoBehaviour
{
    public int maxHealth = 100;
    public int currentHealth;

    public Image barrinhaVida;
    public GameObject telaVitoria;
    void Start()
    {
        currentHealth = maxHealth;
    }

    public void TakeDamage(int amount)
    {
        currentHealth -= amount;

        barrinhaVida.fillAmount = currentHealth / 100f;

        Debug.Log(gameObject.name + " tomou dano: " + amount);

        if (currentHealth <= 0)
        {
            Die();
        }
    }

    void Die()
    {
        Debug.Log(gameObject.name + " morreu");
        telaVitoria.SetActive(true);

        // Aqui você pode:
        // - tocar animação
        // - destruir objeto
        // - desativar AI
        Destroy(gameObject);
    }
}