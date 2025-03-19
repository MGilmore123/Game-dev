using UnityEngine;

public class CharacterController3D : MonoBehaviour
{
    public Animator animator;
    public float walkSpeed = 2f;
    public float runSpeed = 5f;
    public float jumpForce = 5f;
    public float crouchSpeed = 1f;
    public float turnSpeed = 200f;
    private Rigidbody rb;
    private bool isGrounded;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    
    void FixedUpdate()
{
    // Apply physics-based movement here if needed
    if (rb != null)
    {
        Vector3 movement = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical")).normalized;
        float speed = isRunning ? runSpeed : (isCrouching ? crouchSpeed : walkSpeed);

        // Move the rigidbody using physics
        rb.MovePosition(rb.position + movement * speed * Time.fixedDeltaTime);
    }
}

    {
        Move();
        HandleAnimations();
    }

    void Move()
    {
        float moveX = Input.GetAxis("Horizontal"); // A, D
        float moveZ = Input.GetAxis("Vertical"); // W, S
        bool isRunning = Input.GetKey(KeyCode.LeftShift);
        bool isCrouching = Input.GetKey(KeyCode.LeftControl);
        
        float speed = isRunning ? runSpeed : (isCrouching ? crouchSpeed : walkSpeed);
        Vector3 movement = new Vector3(moveX, 0, moveZ).normalized * speed * Time.deltaTime;
        transform.Translate(movement, Space.Self);

        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            isGrounded = false;
        }
    }

    void HandleAnimations()
    {
        animator.SetFloat("Speed", new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical")).magnitude);
        animator.SetBool("IsRunning", Input.GetKey(KeyCode.LeftShift));
        animator.SetBool("IsCrouching", Input.GetKey(KeyCode.LeftControl));
        animator.SetBool("IsJumping", !isGrounded);
        
        if (Input.GetKeyDown(KeyCode.F))
            animator.SetTrigger("Punch");
        
        if (Input.GetKey(KeyCode.R))
            animator.SetBool("FightingStance", true);
        else
            animator.SetBool("FightingStance", false);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
            isGrounded = true;
    }
}
