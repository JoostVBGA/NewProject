using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LootAble : MonoBehaviour
{
    //Interact function
    public bool isInRange;
    private PlayerControls playerControls;

    //pulling ScriptableObject
    [SerializeField] private ScriptableObject LootTable;

    [SerializeField] private float LootTime;

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
    }

    private void OnTriggerExit(Collider other)
    {
        isInRange = false;
    }

    private void Update()
    {
        if (!isInRange)
        {
            return;
        }

        if (playerControls.WarState.Loot.triggered)
        {
            Debug.Log("Interacting");
            GiveLoot();
        }

    }

    public void GiveLoot()

    {
        Debug.Log("giving loot");
    }

}
