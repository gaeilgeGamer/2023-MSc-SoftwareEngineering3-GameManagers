using UnityEngine;

public class characterMovement : MonoBehaviour
{
    public float walkSpeed = 2.0f;
    public float jumpForce = 5.0f;

    private Animator animator;
    private Rigidbody rb;
    private Vector3 movement;
    private bool isGrounded;

    void Start()
    {
        // Get the Animator and Rigidbody components
        animator = GetComponent<Animator>();
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        // Get input from keyboard for walking
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");
        movement = new Vector3(horizontal, 0, vertical).normalized;

        // Update the Animator's Speed parameter
        animator.SetFloat("Speed", movement.magnitude);

        // Rotate the character to face the direction of movement
        if (movement.magnitude > 0)
        {
            Quaternion toRotation = Quaternion.LookRotation(movement, Vector3.up);
            transform.rotation = Quaternion.RotateTowards(transform.rotation, toRotation, walkSpeed * Time.deltaTime * 100);
        }

        // Jumping logic
        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            animator.SetBool("IsJumping", true);
            
            isGrounded = false;
        }
    }

    void FixedUpdate()
    {
        // Move the character
       
            rb.MovePosition(rb.position + movement * walkSpeed * Time.fixedDeltaTime);
    }

    void OnCollisionEnter(Collision collision)
    {
        // Check if the character has landed on the ground
        if (collision.gameObject.CompareTag("Ground") && !isGrounded)
        {
            isGrounded = true;
            animator.SetBool("IsJumping", false);
        }
    }
}
