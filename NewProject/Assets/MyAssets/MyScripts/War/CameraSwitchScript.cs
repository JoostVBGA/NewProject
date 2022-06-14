using UnityEngine;
using UnityEngine.InputSystem;

public class CameraSwitchScript : MonoBehaviour
{
    [SerializeField] private InputAction action;

    private Animator animator;

    public Transform WarCameraLA;

    public Transform PlayerPos;

    private bool playerCamera = false;

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
        playerCamera = false;
    }

    private void BattleStateOff()
    {
        animator.Play("PlayerCamera");
        playerCamera = true;
    }

    public void CameraInActive()
    {
        //Time Delay

        //check for closest camera
        animator.Play("PlayerCamera");
    }

    public void CameraActive()
    {
        if (playerCamera == true)
        {
            WarCameraLA.position = PlayerPos.position;
            animator.Play("WarCamera");
        }

        
    }

    private void OnDestroy()
    {
        EventSystem.current.OnCharacterTriggerEnter -= BattleStateOn;
        EventSystem.current.OnBattleStateExit -= BattleStateOff;
        EventSystem.current.OnCameraActive -= CameraActive;
        EventSystem.current.OnCameraInActive -= CameraInActive;
    }
}
