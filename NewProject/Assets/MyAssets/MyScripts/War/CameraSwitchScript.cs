using UnityEngine;
using UnityEngine.InputSystem;

public class CameraSwitchScript : MonoBehaviour
{
    [SerializeField] private InputAction action;

    private Animator animator;

    public Behaviour PlayerScript;

    private void Awake()
    {
        animator = GetComponent<Animator>();
    }

    private void OnEnable()
    {
        action.Enable();
    }

    private void OnDisable()
    {
        action.Disable();
    }

    private void Start()
    {
        EventSystem.current.OnCharacterTriggerEnter += BattleStateOn;
        EventSystem.current.OnBattleStateExit += BattleStateOff;
    }

    private void BattleStateOn()
    {
        animator.Play("BattlePlayerCamera");
     
        PlayerScript.enabled= false;

        Debug.Log("ToBattleCamera");
    }

    private void BattleStateOff()
    {
        animator.Play("WarCamera");

        Debug.Log("ToWarCamera");
    }

    private void OnDestroy()
    {
        EventSystem.current.OnCharacterTriggerEnter -= BattleStateOn;
        EventSystem.current.OnBattleStateExit -= BattleStateOff;
    }
}
