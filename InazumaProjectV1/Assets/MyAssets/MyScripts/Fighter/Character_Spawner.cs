using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character_Spawner : MonoBehaviour
{

    [Header("Players")]
    
    [SerializeField] private GameObject playerPrefab;

    [SerializeField] public ScriptableObject player1;

    [SerializeField] public ScriptableObject player2;

    [SerializeField] public ScriptableObject player3;

    [SerializeField] public ScriptableObject player4;

    [SerializeField] public ScriptableObject player5;


    [Header("Spawners")]

    [SerializeField] private Transform SpawnLocation1;

    [SerializeField] private Transform SpawnLocation2;

    [SerializeField] private Transform SpawnLocation3;

    [SerializeField] private Transform SpawnLocation4;

    [SerializeField] private Transform SpawnLocation5;

    void Awake()
    {
        var spawn1 = Instantiate(playerPrefab, SpawnLocation1.position, Quaternion.identity, this.transform );
        spawn1.name = player1.name;

        if (spawn1.CompareTag("Player"))
        {
            spawn1.GetComponent<PlayerControllerWar>().playerInfo = player1;
        }
        if (spawn1.CompareTag("Enemy"))
        {
            spawn1.GetComponent<EnemyControllerWar>().enemyInfo = player1;
        }

        var spawn2 = Instantiate(playerPrefab, SpawnLocation2.position, Quaternion.identity, this.transform);
        spawn2.name = player2.name;

        if (spawn2.CompareTag("Player"))
        {
            spawn2.GetComponent<PlayerControllerWar>().playerInfo = player2;
        }
        if (spawn2.CompareTag("Enemy"))
        {
            spawn2.GetComponent<EnemyControllerWar>().enemyInfo = player2;
        }

        var spawn3 = Instantiate(playerPrefab, SpawnLocation3.position, Quaternion.identity, this.transform);
        spawn3.name = player3.name;

        if (spawn3.CompareTag("Player"))
        {
            spawn3.GetComponent<PlayerControllerWar>().playerInfo = player3;
        }
        if (spawn3.CompareTag("Enemy"))
        {
            spawn3.GetComponent<EnemyControllerWar>().enemyInfo = player3;
        }

        var spawn4 = Instantiate(playerPrefab, SpawnLocation4.position, Quaternion.identity, this.transform);
        spawn4.name = player4.name;

        if (spawn4.CompareTag("Player"))
        {
            spawn4.GetComponent<PlayerControllerWar>().playerInfo = player4;
        }
        if (spawn4.CompareTag("Enemy"))
        {
            spawn4.GetComponent<EnemyControllerWar>().enemyInfo = player4;
        }

        var spawn5 = Instantiate(playerPrefab, SpawnLocation5.position, Quaternion.identity, this.transform);
        spawn5.name = player5.name;

        if (spawn5.CompareTag("Player"))
        {
            spawn5.GetComponent<PlayerControllerWar>().playerInfo = player5;
        }
        if (spawn5.CompareTag("Enemy"))
        {
            spawn5.GetComponent<EnemyControllerWar>().enemyInfo = player5;
        }

    }
}
