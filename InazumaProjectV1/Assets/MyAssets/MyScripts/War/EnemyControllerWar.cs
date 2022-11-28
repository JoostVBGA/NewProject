using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyControllerWar : MonoBehaviour
{
<<<<<<< HEAD
    [SerializeField] public FighterBase enemyInfo;
    [SerializeField] public bool isAware = false;
    [SerializeField] public bool inBattle = false;
    [SerializeField] public string chosenMove;
    [SerializeField] private List<string> moves;
    [SerializeField] public float level = 10;

    [Header("EnemyInfo")]

    [SerializeField] public int maxHP;
    [SerializeField] public int maxMana;
    [SerializeField] public int speed;
    [SerializeField] public int damage;
    [SerializeField] public int defense;
    [SerializeField] public int agility;

    void Awake()
    {
        chosenMove = moves[Random.Range(0, 3)];
        //speed = enemyInfo.Speed;
        //damage = enemyInfo.Damage;
        //defense = enemyInfo.Defense;
        //agility = enemyInfo.Agility;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            inBattle = true; 
            return;
        }

        return;
=======

    private void OnTriggerEnter(Collider other)
    {
        EventSystem.current.CharacterTriggerEnter();
>>>>>>> parent of 21ea885 (Finds all fighters in battle range)
    }

}
