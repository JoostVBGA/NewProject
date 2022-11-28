using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SC_CanvasController : MonoBehaviour
{
    [SerializeField]private GameObject battleCanvas;
    [SerializeField]private GameObject warCanvas;

    private void Awake()
    {
        battleCanvas = gameObject.transform.GetChild(1).gameObject;
        warCanvas = gameObject.transform.GetChild(0).gameObject;
    }

    private void Start()
    {
        EventSystem.current.OnCharacterTriggerEnter += BattleStateOn;
        EventSystem.current.OnBattleStateExit += BattleStateOff;
    }

    private void BattleStateOn()
    {
        battleCanvas.SetActive(true);
        warCanvas.SetActive(false);
    }

    private void BattleStateOff()
    {
        battleCanvas.SetActive(false);
        warCanvas.SetActive(true);
    }

    private void OnDestroy()
    {
        EventSystem.current.OnCharacterTriggerEnter -= BattleStateOn;
        EventSystem.current.OnBattleStateExit -= BattleStateOff;
    }

}
