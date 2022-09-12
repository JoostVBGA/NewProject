using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    private GameInputs controls;

    public float moveSpeed = 6f;

    public float moveSpeedLimit = 20;

    private Vector3 velocity;

    public float gravity = -9.81f;

    private Vector2 move;

    public float jumpHeight = 2.4f;

    private CharacterController controller;

    public Transform Ground;

    public float distanceToGround = 0.4f;

    public LayerMask groundMask;

    private bool isGrounded;

    private void Awake()
    {
        controls = new GameInputs();
        controller = GetComponent<CharacterController>();
    }

    private void Update()
    {
        Grav();
        PlayerMovement();
        Jump();
        Ability();
    }

    private void Grav()
    {
        isGrounded = Physics.CheckSphere(Ground.position, distanceToGround, groundMask);

        if(isGrounded && velocity.y < 0)
        {
            velocity.y = -1f;
        }

        velocity.y += gravity * Time.deltaTime;

        controller.Move(velocity * Time.deltaTime);
    }

    private void PlayerMovement()
    {
        move = controls.Player.Movement.ReadValue<Vector2>();

        Vector3 movement = (move.y * transform.forward) + (move.x * transform.right);

        controller.Move(movement * moveSpeed * Time.deltaTime);
    }

    private void Jump()
    {
        if (controls.Player.Jump.triggered && isGrounded)
        {
            velocity.y = Mathf.Sqrt(jumpHeight * -2f * gravity);
        }
    }

    private void Ability()
    {
        if (controls.Player.StartMagic.triggered)
        {

        }
    }

    private void OnEnable()
    {
        controls.Enable();
    }

    private void OnDisable()
    {
        controls.Disable();
    }


}
