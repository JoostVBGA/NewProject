using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    private GameInputs controls;

    private float moveSpeed = 6f;

    private Vector3 Velocity;

    private float gravity = -9.81f;

    private Vector2 move;

    private float jumpHeight = 2.4f;

    private CharacterController controller;

    public Transform Ground
}
