using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class CameraLook : MonoBehaviour
{
    private GameInputs controls;

    public float mouseSensitivity = 100f;

    private Vector2 mouseLook;

    private float XRotation = 0f;

    private Transform playerBody;

    private void Awake()
    {
        playerBody = transform.parent;

        controls = new GameInputs();

        Cursor.lockState = CursorLockMode.Locked;
    }

    void Update()
    {
        Look();
    }

    private void Look()
    {
        mouseLook = controls.Player.Look.ReadValue<Vector2>();

        float mouseX = mouseLook.x * mouseSensitivity * Time.deltaTime;
        float mouseY = mouseLook.y * mouseSensitivity * Time.deltaTime;

        XRotation -= mouseY;
        XRotation = Mathf.Clamp(XRotation, -90f, 90);

        transform.localRotation = Quaternion.Euler(XRotation, 0, 0);
        playerBody.Rotate(Vector3.up * mouseX);
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
