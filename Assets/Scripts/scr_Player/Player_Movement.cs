using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Movement : MonoBehaviour
{
    [Header("Assignables")]
    [SerializeField] private float baseSpeed = 5f;
    [SerializeField] private float gravityForce = -9.8f;
    [SerializeField] private float sphereRadius = 0.4f;
    [SerializeField] private float jumpHeight = 3f;
    [SerializeField] private LayerMask groundMask;
    [SerializeField] private Transform groundCheck;
    [SerializeField] private CharacterController controller;
    [SerializeField] private Manager_PauseMenu PauseMenuScript;

    //private variables
    private Vector3 velocity;
    private bool isGrounded;
    private float moveSpeed = 0f;

    private void Update()
    {
        isGrounded = Physics.CheckSphere(groundCheck.position, sphereRadius, groundMask);

        if(isGrounded && velocity.y < 0) //Ground Check to stop applying gravity if the player is on the ground
        {
            velocity.y = -2f;
        }

        if (PauseMenuScript.keyboardLayout == Manager_PauseMenu.KeyboardLayout.english)
        {
            float x = Input.GetAxis("HorizontalEnglish");
            float z = Input.GetAxis("VerticalEnglish");
            Vector3 moveDirection = transform.right * x + transform.forward * z;
            controller.Move(moveDirection * moveSpeed * Time.deltaTime);
            velocity.y += gravityForce * Time.deltaTime;
            controller.Move(velocity * Time.deltaTime);
        }
        else if (PauseMenuScript.keyboardLayout == Manager_PauseMenu.KeyboardLayout.french)
        {
            float x = Input.GetAxis("HorizontalFrench");
            float z = Input.GetAxis("VerticalFrench");
            Vector3 moveDirection = transform.right * x + transform.forward * z;
            controller.Move(moveDirection * moveSpeed * Time.deltaTime);
            velocity.y += gravityForce * Time.deltaTime;
            controller.Move(velocity * Time.deltaTime);
        }

        if (Input.GetButtonDown("Jump") && isGrounded)
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
    }
}