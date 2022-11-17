using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LootAble : MonoBehaviour
{
    //Interact function
    public bool isInRange;
    private PlayerControls playerControls;
    private bool isUnLocking = false;
    private bool isUnLocked = false;

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

        if (!isInRange && isUnLocking)
        {
            isUnLocking = false;
            return;
        }

        if (playerControls.WarState.Loot.triggered && !isUnLocked)
        {
            Debug.Log("Interacting");
            isUnLocking = true;
        }

        if (playerControls.WarState.Loot.triggered && isUnLocked)
        {
            Debug.Log("Interacting");
            GiveLoot();
        }

        if (LootTime > 0 && isUnLocking)
        {
            LootTime -= Time.deltaTime;

            if (LootTime < 0)
            {
                GiveLoot();
                isUnLocking = false;
                isUnLocked = true;
            }
        }

        

    }

    public void GiveLoot()

    {
        Debug.Log("giving loot");
    }

}
