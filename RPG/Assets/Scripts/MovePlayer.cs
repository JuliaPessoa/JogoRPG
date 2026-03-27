using UnityEngine;
using UnityEngine.InputSystem;

public class MovePlayer : MonoBehaviour
{
    public float velocidade = 5f;
    private Vector2 moveInput;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 movimento = new Vector3(moveInput.x, 0f, moveInput.y);
        transform.Translate(movimento * velocidade * Time.deltaTime, Space.World);
    }

    public void OnMove(InputValue valor)
    {
        moveInput = valor.Get<Vector2>();
    }
}
