using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovementWar: MonoBehaviour
{
    private PlayerControls playerControls;

    public float panSpeed = 5f;

    public Vector2 panLimit;

    private void Awake()
    {
        playerControls = new PlayerControls();
    }

    private void OnEnable()
    {
        playerControls.Enable();
    }

    private void OnDisable()
    {
        playerControls.Disable();
    }

    // Update is called once per frame
    void Update()
    {


        Vector3 pos = transform.position;

        if (playerControls.WarState.CameraUp.ReadValue<float>() == 1)
        {
            pos.z += panSpeed * Time.deltaTime;
        }

        transform.position = pos;

        if (playerControls.WarState.CameraDown.ReadValue<float>() == 1)
        {
            pos.z -= panSpeed * Time.deltaTime;
        }

        transform.position = pos;

        if (playerControls.WarState.CameraLeft.ReadValue<float>() == 1)
        {
            pos.x -= panSpeed * Time.deltaTime;
        }

        transform.position = pos;

        if (playerControls.WarState.CameraRight.ReadValue<float>() == 1)
        {
            pos.x += panSpeed * Time.deltaTime;
        }

        pos.x = Mathf.Clamp(pos.x, -panLimit.x, panLimit.x);
        pos.z = Mathf.Clamp(pos.z, -panLimit.y, panLimit.y);

        transform.position = pos;
    }
}