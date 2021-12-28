using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementScript : MonoBehaviour
{
    public Transform groundCheck;

    public float baseSpeed = 5f;
    public float gravityForce = -9.8f;
    public float sphereRadius = 0.4f;
    public float jumpHeight = 3f;

    public LayerMask groundMask;

    private Vector3 velocity;
    private bool isGrounded;
    private float moveSpeed = 0f;


    public CharacterController controller;
    

    void Start()
    {
        
    }

    void Update()
    {
        isGrounded = Physics.CheckSphere(groundCheck.position, sphereRadius, groundMask);

        if(isGrounded && velocity.y < 0) //Ground Check to stop applying gravity if the player is on the ground
        {
            velocity.y = -2f;
        }

        if(Input.GetButtonDown("Jump") && isGrounded)
        {
            velocity.y = Mathf.Sqrt(jumpHeight * -2 * gravityForce);
        }

        if (Input.GetKey(KeyCode.LeftShift))
        {
            moveSpeed = baseSpeed * 2;
        }
        else
        {
            moveSpeed = baseSpeed;
        }

        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        Vector3 moveDirection = transform.right * x + transform.forward * z;

        controller.Move(moveDirection * moveSpeed * Time.deltaTime);

        velocity.y += gravityForce * Time.deltaTime;

        controller.Move(velocity * Time.deltaTime);
    }
}
