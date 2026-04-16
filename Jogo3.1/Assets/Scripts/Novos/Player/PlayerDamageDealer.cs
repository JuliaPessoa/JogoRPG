using UnityEngine;

public class PlayerDamageDealer : MonoBehaviour
{
    public int damage = 10;
    private Transform ownerRoot;

    private void Awake()
    {
        ownerRoot = transform.root;
    }

    private void OnTriggerEnter(Collider other)
    {
        Transform targetRoot = other.transform.root;

        if (targetRoot == ownerRoot)
            return;

        if (!targetRoot.CompareTag("Dragon"))
            return;

        Health target = targetRoot.GetComponent<Health>();

        if (target != null)
        {
            Debug.Log("-----> Player acertou Dragon");
            target.TakeDamage(damage);
        }
    }
}