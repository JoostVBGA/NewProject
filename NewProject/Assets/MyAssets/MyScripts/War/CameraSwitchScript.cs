using UnityEngine;
using UnityEngine.InputSystem;

public class CameraSwitchScript : MonoBehaviour
{
    [SerializeField] private InputAction action;

    private Animator animator;

    public Transform WarCamera;

    public Transform PlayerCamera;

    private bool BattleState = false;

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
        EventSystem.current.OnCameraActive += CameraActive;
        EventSystem.current.OnCameraInActive += CameraInActive;
    }

    private void BattleStateOn()
    {
        animator.Play("BattleCamera");
        BattleState = true;
    }

    private void BattleStateOff()
    {
        animator.Play("PlayerCamera");
        BattleState = false;
    }

    public void CameraInActive()
    {
        //Time Delay

        //check for closest camera
        animator.Play("PlayerCamera");
    }

    public void CameraActive()
    {
        if (BattleState == true)
        {
            return;
        }

        animator.Play("WarCamera");
    }

    private void OnDestroy()
    {
        EventSystem.current.OnCharacterTriggerEnter -= BattleStateOn;
        EventSystem.current.OnBattleStateExit -= BattleStateOff;
        EventSystem.current.OnCameraActive -= CameraActive;
        EventSystem.current.OnCameraInActive -= CameraInActive;
    }
}
