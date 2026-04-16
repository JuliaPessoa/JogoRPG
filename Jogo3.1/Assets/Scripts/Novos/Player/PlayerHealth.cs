using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
    public int maxHealth = 100;
    public int currentHealth;

    public Image barrinhaVida;
    public GameObject telaDerrota;


    private void Awake()
    {
        currentHealth = maxHealth;
    }

    public void TakeDamage(int damage)
    {
        currentHealth -= damage;
        barrinhaVida.fillAmount = currentHealth / 100f;

        Debug.Log(gameObject.name + " recebeu dano: " + damage +
                  " | Vida restante: " + currentHealth);

        if (currentHealth <= 0)
        {
            Die();
        }
    }

    private void Die()
    {
        Debug.Log(gameObject.name + " morreu!");

        gameObject.SetActive(false);
        telaDerrota.SetActive(true);
    }
}