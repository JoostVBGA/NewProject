using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class SC_EventSystem : MonoBehaviour
{
    public static SC_EventSystem current;

    private void Awake()
    {
        current = this;
    }

    //2 Characters walk into each other
    public event Action OnCharacterTriggerEnter;
    public void CharacterTriggerEnter()
    {
        if (OnCharacterTriggerEnter != null)
        {
            OnCharacterTriggerEnter();
        }
    }

    //2 Characters walk into each other
    public event Action OnBattleStateExit;
    public void BattleStateExit()
    {
        if (OnBattleStateExit != null)
        {
            OnBattleStateExit();
        }
    }

    //Camera Active
    public event Action OnCameraActive;
    public void CameraActive()
    {
        if (OnCameraActive != null)
        {
            OnCameraActive();
        }
    }

    //Camera InActive
    public event Action OnCameraInActive;
    public void CameraInactive()
    {
        if (OnCameraInActive != null)
        {
            OnCameraInActive();
        }
    }
}