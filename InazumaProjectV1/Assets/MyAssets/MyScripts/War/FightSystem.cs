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
        //PlayerScript = GameObject.Find("player").GetBehaviour<PlayerControllerWar>;
    }

    public void SpecialMove()
    {
        EventSystem.current.BattleStateExit();
    }

    private void BattleStateOn()
    {
        PlayerScript.enabled = false;
    }

    private void BattleStateOff()
    {
        PlayerScript.enabled = true;
    }
}
