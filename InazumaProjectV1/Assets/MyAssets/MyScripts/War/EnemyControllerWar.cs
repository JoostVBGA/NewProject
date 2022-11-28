using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyControllerWar : MonoBehaviour
{
    [SerializeField] public ScriptableObject enemyInfo;
    [SerializeField] public bool isAware;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            return;
        }

        return;
    }

}
