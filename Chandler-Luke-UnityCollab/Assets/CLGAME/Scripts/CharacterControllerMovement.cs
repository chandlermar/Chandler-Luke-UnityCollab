using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterControllerMovement : MonoBehaviour
{
    Vector3 velocity;
    Vector3 playerMovementInput;
    Vector2 PlayerMouseInput;
    Vector3 MoveVector;

    float xRot;


    Transform playerCamera;

    CharacterController controller;

    public float speed;
    [SerializeField] float jumpForce;
    [SerializeField] float mouseSensitivity;
    [SerializeField] float gravity = -9.81f;



    //mechanic variables
    public bool isCrouching = false;
    [SerializeField] float crouchingHeight = 1.25f;
    [SerializeField] float standingHeight = 1.8f;

    public float walkSpeed;
    public float crouchSpeed;
    public float sprintSpeed;


    void Start()
    {
        playerCamera = GameObject.FindGameObjectWithTag("MainCamera").transform;
        controller = GetComponent<CharacterController>();
        speed = walkSpeed;
    }

    void Update()
    {
        playerMovementInput = new Vector3(Input.GetAxisRaw("Horizontal"), 0f, Input.GetAxisRaw("Vertical")).normalized;
        PlayerMouseInput = new Vector2(Input.GetAxisRaw("Mouse X"), Mathf.Clamp(Input.GetAxisRaw("Mouse Y"), -90, 90));

        MovePlayer();
        MoveCamera();
        Crouch();
        Sprint();
    }

    void MovePlayer()
    {
        if (controller.isGrounded)
        {
            MoveVector = transform.TransformDirection(playerMovementInput);
            velocity.y = -1;

            if (Input.GetKeyDown(KeyCode.Space))
            {
                velocity.y = jumpForce;
            }
        }
        else
        {
            MoveVector = transform.TransformDirection(playerMovementInput);
            velocity.y -= gravity * -2f * Time.deltaTime;
        }

        controller.Move(MoveVector * speed * Time.deltaTime);
        controller.Move(velocity * Time.deltaTime);

    }

    void MoveCamera()
    {
        xRot -= PlayerMouseInput.y * mouseSensitivity;

        xRot = Mathf.Clamp(xRot, -90, 90);

        transform.Rotate(0f, PlayerMouseInput.x * mouseSensitivity, 0f);
        playerCamera.transform.localRotation = Quaternion.Euler(xRot, 0f, 0f);
    }

    void Crouch()
    {
        if (Input.GetKey(KeyCode.LeftControl))
        {
            controller.height = crouchingHeight;
            speed = crouchSpeed;
        }
        else
        {
            controller.height = standingHeight;
            speed = walkSpeed;
        }
    }

    void Sprint()
    {
        if (Input.GetKey(KeyCode.LeftShift))
        {
            speed = sprintSpeed;
        }
        else
        {
            speed = walkSpeed;
        }
    }
}
