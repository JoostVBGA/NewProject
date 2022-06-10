using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyControllerBattle : MonoBehaviour
{

    private void OnTriggerEnter(Collider other)
    {
        EventSystem.current.CharacterTriggerEnter();
    }

}
