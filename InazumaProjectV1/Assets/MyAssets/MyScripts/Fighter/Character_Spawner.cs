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

        var spawn2 = Instantiate(playerPrefab, SpawnLocation2.position, Quaternion.identity, this.transform);
        spawn2.name = player2.name;

        var spawn3 = Instantiate(playerPrefab, SpawnLocation3.position, Quaternion.identity, this.transform);
        spawn3.name = player3.name;

        var spawn4 = Instantiate(playerPrefab, SpawnLocation4.position, Quaternion.identity, this.transform);
        spawn4.name = player4.name;

        var spawn5 = Instantiate(playerPrefab, SpawnLocation5.position, Quaternion.identity, this.transform);
        spawn5.name = player5.name;

    }
}
