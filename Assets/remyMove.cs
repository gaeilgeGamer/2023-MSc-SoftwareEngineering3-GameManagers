using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class remyMove : MonoBehaviour
{
    public float walkSpeed = 2.0f;
    public float jumpForce = 5.0f;

    private Animator animator; 
    private Rigidbody rb; 
    private Vector3 movement; 
    public GameObject cube; 
    private bool isGrounded; 
    // Start is called before the first frame update
    void Awake()
    {
        animator = GetComponent<Animator>();
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");
        movement = new Vector3(horizontal, 0, vertical);

        animator.SetFloat("Speed", movement.magnitude);

        if(movement.magnitude>0)
        {
            Quaternion toRotation = Quaternion.LookRotation(movement, Vector3.up);
            transform.rotation = Quaternion.RotateTowards(transform.rotation, toRotation, walkSpeed*Time.deltaTime);
        }

        if(Input.GetButtonDown("Jump")&& isGrounded){
            rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            cube.SetActive(true);

            animator.SetBool("isJumping", true);


            isGrounded = false;             
        }
    }
    void FixedUpdate()
    {
        rb.MovePosition(rb.position + movement * walkSpeed*Time.fixedDeltaTime);
    }
    void OnCollisionEnter(Collision collision){
        if(collision.gameObject.CompareTag("Ground")&& !isGrounded){
            isGrounded = true; 
            animator.SetBool("isJumping", false);
        }
    }
}
