using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FightSystem : MonoBehaviour
{
<<<<<<< HEAD
    private Vector3 posBattle;

    [SerializeField]private float battleRange;

    [SerializeField] private GameObject battleCollider;
=======
    public bool specialMove = false;

    public Behaviour PlayerScript;
>>>>>>> parent of 21ea885 (Finds all fighters in battle range)

    [SerializeField] private List<GameObject> players;

    [SerializeField] private List<GameObject> enemys;

    [SerializeField] private float playerPower = 1;

    [SerializeField] private float enemyPower = 1;

    [SerializeField] private string enemyMove;

    [SerializeField] private string useDodge = null;

    [SerializeField] private float playerBonus = 1f;

    [SerializeField] private float enemyBonus = 1f;

    [SerializeField] private float enemyStatBonus;

    [SerializeField] private float playerStatBonus;



    private void Start()
    {
        EventSystem.current.OnCharacterTriggerEnter += BattleStateOn;
        EventSystem.current.OnBattleStateExit += BattleStateOff;
<<<<<<< HEAD
=======
        //PlayerScript = GameObject.Find("player").GetBehaviour<PlayerControllerWar>;
    }

    public void SpecialMove()
    {
        EventSystem.current.BattleStateExit();
>>>>>>> parent of 21ea885 (Finds all fighters in battle range)
    }

    private void BattleStateOn()
    {
<<<<<<< HEAD
        //Disabling Scripts

        Debug.Log("InBattle");

        GameObject[] taggedPlayers = GameObject.FindGameObjectsWithTag("Player");

        foreach (GameObject obj in taggedPlayers)
        {
            obj.GetComponent<PlayerControllerWar>().enabled = false;

        }

        GameObject[] taggedEnemys = GameObject.FindGameObjectsWithTag("Enemy");

        foreach (GameObject obj in taggedEnemys)
        {
            obj.GetComponent<EnemyControllerWar>().enabled = false;
        }

        //Finding Battlers
        foreach (GameObject obj in taggedPlayers)
        {
            if (obj.GetComponent<PlayerControllerWar>().inBattle)
            {
                posBattle = obj.GetComponent<PlayerControllerWar>().battleCollision;

                Collider[] hitColliders = Physics.OverlapSphere(posBattle, battleRange);
                foreach (var hitCollider in hitColliders)
                {
                    if(hitCollider.gameObject.CompareTag("Player"))
                    {
                        players.Add(hitCollider.gameObject);
                    }

                    if (hitCollider.gameObject.CompareTag("Enemy"))
                    {
                        enemys.Add(hitCollider.gameObject);

                        if (hitCollider.gameObject.GetComponent<EnemyControllerWar>().inBattle)
                        {
                            enemyMove = hitCollider.gameObject.GetComponent<EnemyControllerWar>().chosenMove;
                        }
                    } 
                }
            }
        }
=======
        PlayerScript.enabled = false;
>>>>>>> parent of 21ea885 (Finds all fighters in battle range)
    }

    public void Passive()
    {
        if(enemyMove == "Dodge")
        {
            foreach (var obj in enemys)
            {
                //enemyStatBonus = enemyStatBonus + (obj.GetComponent * obj.GetComponent<EnemyControllerWar>().level);
            }
            
            if (enemys.Count > 1)
            {
                enemyStatBonus = enemyStatBonus / (enemys.Count * 0.65f);
            }
            
            useDodge = "Enemy";
            enemyBonus = 1.2f;
        }
        if (enemyMove == "Aggressive")
        {
            foreach (var obj in enemys)
            {
               enemyStatBonus = enemyStatBonus + (obj.GetComponent<EnemyControllerWar>().damage * obj.GetComponent<EnemyControllerWar>().level);
            }

            if (enemys.Count > 1)
            {
                enemyStatBonus = enemyStatBonus / (enemys.Count * 0.65f);
            }

            playerBonus = 1.2f;
        }
        if (enemyMove == "Passive")
        {
            foreach (var obj in enemys)
            {
               enemyStatBonus = enemyStatBonus + (obj.GetComponent<EnemyControllerWar>().defense * obj.GetComponent<EnemyControllerWar>().level);
            }

            if (enemys.Count > 1)
            {
                enemyStatBonus = enemyStatBonus / (enemys.Count * 0.65f);
            }
        }

        //playerBonus
        foreach (var obj in players)
        {
            playerStatBonus = playerStatBonus + (obj.GetComponent<PlayerControllerWar>().speed * obj.GetComponent<PlayerControllerWar>().level);
        }

        if (players.Count > 1)
        {
            playerStatBonus = playerStatBonus / (players.Count * 0.65f);
        }

        Calculate();
    }

    public void Agressive()
    {

    }

    public void Dodge()
    {

    }

    private void Calculate()
    {
        playerPower = playerPower * playerBonus * playerStatBonus;
        Debug.Log(playerPower);
        enemyPower = enemyPower * enemyBonus * enemyStatBonus;
        Debug.Log(playerPower);

        if (useDodge != null)
        {
            if (useDodge == ("Player"))
            {

            }

            if (useDodge == ("Enemy"))
            {

            }
        }
    }

    public void SpecialMove()
    {
        EventSystem.current.BattleStateExit();
    }
    private void BattleStateOff()
    {
        PlayerScript.enabled = true;
    }
}
