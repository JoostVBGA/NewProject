using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SC_Interactable : MonoBehaviour
{
    //Interact function
    public bool isInRange;
    private PlayerControls playerControls;

    //pulling ScriptableObject
    [SerializeField] private ScriptableObject interactableObject;  

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

    private void OnTriggerEnter(Collider other)
    {
        isInRange = true;
        Debug.Log("Enter");
    }

    private void OnTriggerExit(Collider other)
    {
        isInRange = false;
        Debug.Log("Exit");
    }

    private void Update()
    {
        if (!isInRange)
        {
            return;
        }

        if (playerControls.OverWorldState.PlayerInteract.ReadValue<float>() == 1)
        {
            OnInteract();
            Debug.Log("Interacting");
        }

    }

    private void OnInteract()
    {
        //if lock type 1 is none
        {
            //giveitem
        }
    }

}
