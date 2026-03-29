using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float walkSpeed = 2.5f;
    public float runSpeed = 5f;
    public float rotationSpeed = 10f;
    public Transform cameraTransform;
    public Animator animator;
    public float animationSmooth = 0.08f;

    private Rigidbody rb;
    private Vector2 moveInput;
    private bool isSprinting;
    private float currentAnimX, currentAnimY;
    private float animXVelocity, animYVelocity;

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
        if (animator == null)
            animator = GetComponentInChildren<Animator>();
    }

    public void SetMoveInput(Vector2 input)
    {
        moveInput = input;
    }

    public void SetSprint(bool sprinting)
    {
        isSprinting = sprinting;
    }

    private void FixedUpdate()
    {
        MovePlayer();
        RotatePlayer();
    }

    private void Update()
    {
        UpdateAnimator();
    }

    private void MovePlayer()
    {
        Vector3 forward = cameraTransform != null ? cameraTransform.forward : Vector3.forward;
        Vector3 right = cameraTransform != null ? cameraTransform.right : Vector3.right;

        forward.y = 0f;
        right.y = 0f;
        forward.Normalize();
        right.Normalize();

        Vector3 move = forward * moveInput.y + right * moveInput.x;
        float currentSpeed = isSprinting ? runSpeed : walkSpeed;
        Vector3 velocity = new Vector3(
            move.x * currentSpeed, rb.linearVelocity.y, move.z * currentSpeed);
        rb.linearVelocity = velocity;
    }

    private void RotatePlayer()
    {
        Vector3 forward = cameraTransform != null ? cameraTransform.forward : Vector3.forward;
        Vector3 right = cameraTransform != null ? cameraTransform.right : Vector3.right;

        forward.y = 0f;
        right.y = 0f;
        forward.Normalize();
        right.Normalize();

        Vector3 move = forward * moveInput.y + right * moveInput.x;

        if (move.sqrMagnitude > 0.001f)
        {
            Quaternion targetRotation = Quaternion.LookRotation(move);
            Quaternion newRotation = Quaternion.Slerp(
                rb.rotation, targetRotation, rotationSpeed * Time.fixedDeltaTime);

            rb.MoveRotation(newRotation);
        }
    }

    private void UpdateAnimator()
    {
        if (animator == null) return;

        Vector2 animInput = Vector2.zero;

        if (moveInput.sqrMagnitude > 0.001f)
        {
            float locomotionAmount = isSprinting ? 1f : 0.5f;

            animInput.x = Mathf.Abs(moveInput.x) > 0.01f ? Mathf.Sign(moveInput.x) * locomotionAmount : 0f;
            animInput.y = Mathf.Abs(moveInput.y) > 0.01f ? Mathf.Sign(moveInput.y) * locomotionAmount : 0f;
        }

        currentAnimX = Mathf.SmoothDamp(
            currentAnimX, animInput.x, ref animXVelocity, animationSmooth);

        currentAnimY = Mathf.SmoothDamp(
            currentAnimY, animInput.y, ref animYVelocity, animationSmooth);

        animator.SetFloat("Horizontal", currentAnimX);
        animator.SetFloat("Vertical", currentAnimY);
    }
}
