using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WarCanvasSystem : MonoBehaviour
{
    private void Start()
    {
        EventSystem.current.OnCharacterTriggerEnter += BattleStateOn;
        EventSystem.current.OnBattleStateExit += BattleStateOff;
    }

    private void BattleStateOn()
    {
        transform.GetChild(0).gameObject.SetActive(false);
        Debug.Log("WarCanvasOff");
    }

    private void BattleStateOff()
    {
        Debug.Log("WarCanvasOnn");
        transform.GetChild(0).gameObject.SetActive(true);
    }

    private void OnDestroy()
    {
        EventSystem.current.OnCharacterTriggerEnter -= BattleStateOn;
        EventSystem.current.OnBattleStateExit -= BattleStateOff;
    }
}
