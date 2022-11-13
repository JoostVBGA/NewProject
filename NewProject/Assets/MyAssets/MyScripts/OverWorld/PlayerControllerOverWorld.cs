using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class SC_PlayerControllerOverWorld : MonoBehaviour
{
    //input fields
    private PlayerControls playerControls;

    private InputAction move;

    //movement fields
    private Rigidbody rb;

    [SerializeField]
    private float movementForce = 1f;

    [SerializeField]
    private float maxSpeed = 5f;
    private Vector3 forceDirection = Vector3.zero;

    [SerializeField]
    private float turnSpeed = 1f;

    [SerializeField]
    private Camera playerCamera;

    private void Awake()
    {
        rb = this.GetComponent<Rigidbody>();
        playerControls = new PlayerControls();

    }

    private void OnEnable()
    {
        playerControls.Enable();
        move = playerControls.OverWorldState.Movement;
        playerControls.OverWorldState.Enable();
    }

    private void OnDisable()
    {
        playerControls.Disable();
        move = playerControls.OverWorldState.Movement;
        playerControls.OverWorldState.Enable();
    }

    private void FixedUpdate()
    {
        forceDirection += move.ReadValue<Vector2>().x * GetCameraRight(playerCamera) * movementForce;
        forceDirection += move.ReadValue<Vector2>().y * GetCameraForward(playerCamera) * movementForce;

        rb.AddForce(forceDirection, ForceMode.Impulse);
        forceDirection = Vector3.zero;

        Vector3 horizonalVelocity = rb.velocity;
        horizonalVelocity.y = 0;

        if (horizonalVelocity.sqrMagnitude > maxSpeed * maxSpeed)
        {
            rb.velocity = horizonalVelocity.normalized * maxSpeed;
        }

        LookAt();
    }

    private void LookAt()
    {
        Vector3 direction = rb.velocity;
        direction.y = 0f;

        if (move.ReadValue<Vector2>().sqrMagnitude > 0.1f && direction.sqrMagnitude > 0.1f)
            this.rb.rotation = Quaternion.LookRotation(direction, Vector3.up * turnSpeed);

        else
            rb.angularVelocity = Vector3.zero;
    }

    private Vector3 GetCameraForward(Camera playerCamera)
    {
        Vector3 forward = playerCamera.transform.forward;
        forward.y = 0;
        return forward.normalized;
    }

    private Vector3 GetCameraRight(Camera playerCamera)
    {
        Vector3 right = playerCamera.transform.right;
        right.y = 0;
        return right.normalized;
    }
}