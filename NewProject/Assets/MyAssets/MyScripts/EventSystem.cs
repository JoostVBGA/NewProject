using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class EventSystem : MonoBehaviour
{
    public static EventSystem current;

    private void Awake()
    {
        current = this;
    }

    public event Action PlayerDrag;
    //player start spawning Waypoints
    public void PlayerDragStart()
    {
        if (PlayerDrag != null)
        {
            PlayerDrag();
        }
    }

    public event Action OnCharacterTriggerEnter;
    //2 Characters walk into each other
    public void CharacterTriggerEnter()
    {
        if (OnCharacterTriggerEnter != null)
        {
            OnCharacterTriggerEnter();
        }
    }

    public event Action OnFightMenuTriggerEnter;
    //Trigger to show the Fight Menu
    public void FightMenuTriggerEnter()
    {
        if (OnCharacterTriggerEnter != null)
        {
            FightMenuTriggerEnter();
        }
    }

    public event Action OnNPCInteract;
    //player start spawning Waypoints
    public void NPCInteract()
    {
        if (OnNPCInteract != null)
        {
            OnNPCInteract();
        }
    }

    public event Action OnTransferTriggerEnter;
    //player start spawning Waypoints
    public void TransferTriggerEnter()
    {
        if (OnTransferTriggerEnter != null)
        {
            OnTransferTriggerEnter();
        }
    }

    public event Action OnObjectInteract;
    //player start spawning Waypoints
    public void ObjectInteract()
    {
        if (OnObjectInteract != null)
        {
            OnObjectInteract();
        }
    }
}