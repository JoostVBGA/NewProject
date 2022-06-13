using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FightSystem : MonoBehaviour
{
    public bool specialMove = false;

    public Behaviour PlayerScript;

    private void Start()
    {
        EventSystem.current.OnCharacterTriggerEnter += BattleStateOn;
        EventSystem.current.OnBattleStateExit += BattleStateOff;
    }

    public void SpecialMove()
    {
        EventSystem.current.BattleStateExit();
    }

    private void BattleStateOn()
    {
        PlayerScript.enabled = false;
        Debug.Log("BattleState");
    }

    private void BattleStateOff()
    {
        PlayerScript.enabled = true;
        Debug.Log("WarState");
    }
}
