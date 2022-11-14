using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragObject : MonoBehaviour
{
    private GameInputs controls;
    PlayerMagicSystem playerMagicSystem;

    [Header("Pickup Settings")]
    [SerializeField] Transform holdArea;
    [SerializeField]private GameObject heldOBJ;
    private Rigidbody heldObjRB;


    [Header("Physics Parameters")]
    [SerializeField] private float pickupRange = 5.0f;
    [SerializeField] private float pickupForce = 150.0f;


    private void Awake()
    {
        controls = new GameInputs();
        playerMagicSystem = GameObject.Find("PlayerEmpty").GetComponent<PlayerMagicSystem>();
        
    }
    private void Update()
    {
        Drag();
    }

    private void Drag()
    {
        if (controls.Player.LeftMousePress.triggered)
        {
            Debug.Log("LeftMousePress");

            if (heldOBJ == null)
            {
                Debug.Log("Grabbing");
                RaycastHit hit;
                if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out hit, pickupRange))
                {
                    PickUpObject(hit.transform.gameObject);
                }
            }

            if (heldOBJ != null)
            {
                MoveObject();
            }
        }

        if (controls.Player.LeftMouseRelease.triggered && heldOBJ != null)
        {
            Debug.Log("LetGO");
            LetGo();
        }





    }

    void MoveObject()
    {
        if (Vector3.Distance(heldOBJ.transform.position, holdArea.position) > 0.1f)
        {
            Vector3 moveDirection = (holdArea.position - heldOBJ.transform.position);
            heldObjRB.AddForce(moveDirection * pickupForce);
        }

    }

    void PickUpObject(GameObject pickOBJ)
    {
        if (pickOBJ.GetComponent<Rigidbody>())
        {
            heldObjRB = pickOBJ.GetComponent<Rigidbody>();
            heldObjRB.useGravity = false;
            heldObjRB.drag = 10;
            heldObjRB.constraints = RigidbodyConstraints.FreezeRotation;

            heldObjRB.transform.parent = holdArea;
            heldOBJ = pickOBJ;
        }
    }

    void LetGo()
    {
        heldObjRB.useGravity = true;
        heldObjRB.drag = 1;
        heldObjRB.constraints = RigidbodyConstraints.None;

        heldObjRB.transform.parent = null;
        heldOBJ = null;

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
