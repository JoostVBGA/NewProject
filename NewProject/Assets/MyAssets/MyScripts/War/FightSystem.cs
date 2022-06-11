using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FightSystem : MonoBehaviour
{
    private void Start()
    {
        EventSystem.current.OnCharacterTriggerEnter += BattleStateOn;
    }

    private void BattleStateOn()
    {
        Debug.Log("BattleState");
    }
}
