using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyControllerWar : MonoBehaviour
{
    [SerializeField] public ScriptableObject enemyInfo;
    [SerializeField] public bool isAware;
    [SerializeField] public float randomMove = 0;
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            randomMove = Random.Range(1, 4);
        }

        return;
    }

    private void Update()
    {

    }

}
