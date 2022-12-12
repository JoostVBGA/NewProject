using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FightSystem : MonoBehaviour
{
    public bool specialMove = false;

    private Vector3 posBattle;

    [SerializeField]private float battleRange;

    [SerializeField] private GameObject battleCollider;

    [SerializeField] private List<GameObject> players;

    [SerializeField] private List<GameObject> enemys;

    [SerializeField] private float useDodge = 0f;

    [SerializeField] private float enemyMove = 0;

    [SerializeField] private float enemyPower = 1f;

    [SerializeField] private float playerPower = 1f;

    [SerializeField] private GameObject directEnemy;

    private void Start()
    {
        EventSystem.current.OnCharacterTriggerEnter += BattleStateOn;
        EventSystem.current.OnBattleStateExit += BattleStateOff;
    }

    private void BattleStateOn()
    {
        //Disabling Scripts

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

        foreach (GameObject obj in enemys)
        {
            if (obj.GetComponent<EnemyControllerWar>().randomMove == 0)
            {
                return;
            }

           obj.GetComponent<EnemyControllerWar>().randomMove = enemyMove;
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
                    }
                }
            }
        }

        foreach (var enemy in enemys)
        {

            if (enemys.Count -1 == enemys.IndexOf(enemy))
            {
                directEnemy = enemy;
                enemyMove = enemy.GetComponent<EnemyControllerWar>().randomMove;
            }
        }

    }

    
    public void Defensive()
    {
        //Dodge
        if (enemyMove == 1)
        {
            foreach (var obj in enemys)
            {
                //calculate enemy power
            }

            useDodge = 2;
            enemyPower = enemyPower * 1.2f;
        }

        //Agressive
        if (enemyMove == 2)
        {
            foreach (var obj in enemys)
            {
                //calculate enemy power
            }
            playerPower = playerPower * 1.2f;
        }

        //Defensive
        if (enemyMove == 3)
        {
            foreach (var obj in enemys)
            {
                //calculate enemy power
            }
            playerPower = playerPower * 1.02f;
        }
        Calculate();
    }
    public void Agressive()
    {
        {
            //Dodge
            if (enemyMove == 1)
            {
                foreach (var obj in enemys)
                {
                    //calculate enemy power
                }

                useDodge = 2;
                playerPower = playerPower * 1.2f;
            }

            //Agressive
            if (enemyMove == 2)
            {
                foreach (var obj in enemys)
                {
                    //calculate enemy power
                }
                playerPower = playerPower * 1.02f;
            }

            //Defensive
            if (enemyMove == 3)
            {
                foreach (var obj in enemys)
                {
                    //calculate enemy power
                }
                enemyPower = enemyPower * 1.2f;
            }
            Calculate();
        }
    }

    public void Dodge()
    {
        {
            //Dodge
            if (enemyMove == 1)
            {
                foreach (var obj in enemys)
                {
                    //calculate enemy power
                }

                useDodge = 3;
                playerPower = playerPower * 1.02f;
            }

            //Agressive
            if (enemyMove == 2)
            {
                foreach (var obj in enemys)
                {
                    //calculate enemy power
                }
                enemyPower = enemyPower * 1.2f;
                useDodge = 1;
            }

            //Defensive
            if (enemyMove == 3)
            {
                foreach (var obj in enemys)
                {
                    //calculate enemy power
                }
                playerPower = playerPower * 1.2f;
                useDodge = 1;
            }
            Calculate();
        }
    }

    private void Calculate()
    {
        //playerBonus
        foreach (var obj in players)
        {
            //calculate player stat bonus
        }

        if (enemys.Count > 1)
        {
            enemyPower = enemyPower + (enemys.Count * 0.35f);
        }

        if (players.Count > 1)
        {
            playerPower = playerPower + (players.Count * 0.35f);
        }

        Debug.Log("PlayerPower" + playerPower);
        Debug.Log("EnemyPower" + enemyPower);

        if (enemyPower > playerPower)
        {
            if (useDodge == 2 || useDodge == 3)
            {
                Debug.Log("EnemyWins");
                //assign invincibility
            }
        }

        if (playerPower > enemyPower)
        {
            //playerWins
            if (useDodge == 1 || useDodge == 3)
            {
                Debug.Log("PlayerWins");
                //assign invincibility
            }
        }
    }

    public void SpecialMove()
    {
        return;
        //EventSystem.current.BattleStateExit();
    }
    private void BattleStateOff()
    {
        Debug.Log("OutOfBattle");

        GameObject[] taggedObjects = GameObject.FindGameObjectsWithTag("Player");

        foreach (GameObject obj in taggedObjects)
        {
            obj.GetComponent<PlayerControllerWar>().enabled = true;
        }
    }
}
