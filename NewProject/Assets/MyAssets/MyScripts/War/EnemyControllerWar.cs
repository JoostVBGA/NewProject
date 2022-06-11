using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyControllerWar : MonoBehaviour
{

    private void OnTriggerEnter(Collider other)
    {
        EventSystem.current.CharacterTriggerEnter();
    }

}
