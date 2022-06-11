using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BattleCanvasSystem : MonoBehaviour
{
    private void Start()
    {
        EventSystem.current.OnCharacterTriggerEnter += BattleStateOn;
        EventSystem.current.OnBattleStateExit += BattleStateOff;
    }

    private void BattleStateOn()
    {
        transform.GetChild(0).gameObject.SetActive(true);
        Debug.Log("BattleCanvasOn");
    }

    private void BattleStateOff()
    {
        transform.GetChild(0).gameObject.SetActive(false);
        Debug.Log("BattleCanvasOff");
    }

    private void OnDestroy()
    {
        EventSystem.current.OnCharacterTriggerEnter -= BattleStateOn;
        EventSystem.current.OnBattleStateExit -= BattleStateOff;
    }
}
