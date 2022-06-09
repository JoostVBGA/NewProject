using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{

    private void OnTriggerEnter(Collider other)
    {
        EventSystem.current.CharacterTriggerEnter();
    }

}
