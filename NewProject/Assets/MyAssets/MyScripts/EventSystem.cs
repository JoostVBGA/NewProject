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
}