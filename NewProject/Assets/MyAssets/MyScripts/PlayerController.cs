using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private void Start()
    {
        EventSystem.current.PlayerDrag += OnPlayerDrag;
        EventSystem.current.OnCharacterTriggerEnter += OnCharacterCollision;
    }

    private void OnPlayerDrag()
    {
        
    }

    private void OnCharacterCollision()
    {
        Debug.Log("Collision");
    }
    private void OnDestroy()
    {
        EventSystem.current.PlayerDrag -= OnPlayerDrag;
        EventSystem.current.PlayerDrag -= OnCharacterCollision;
    }

}
