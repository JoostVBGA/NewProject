using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FightSystem : MonoBehaviour
{
    public bool specialMove = false;

    private Vector3 posBattle;

    [SerializeField]private float battleRange;

    [SerializeField] private GameObject battleCollider;

    private void Start()
    {
        EventSystem.current.OnCharacterTriggerEnter += BattleStateOn;
        EventSystem.current.OnBattleStateExit += BattleStateOff;
        
    }

    public void SpecialMove()
    {
        EventSystem.current.BattleStateExit();
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
                        Debug.Log("Player" + hitCollider.name);
                    }

                    if (hitCollider.gameObject.CompareTag("Enemy"))
                    {
                        Debug.Log("Enemy" + hitCollider.name);
                    }
                    
                }
            }
        }
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
