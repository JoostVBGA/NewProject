using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Exit : MonoBehaviour
{

    private bool allExiting = false;

    [SerializeField]private float exitTime = 4;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            GameObject[] taggedObjects = GameObject.FindGameObjectsWithTag("Player");

            foreach (GameObject obj in taggedObjects)
            {
                if (!obj.GetComponent<PlayerControllerWar>().inExit)
                {
                    return;
                }
            }

            Debug.Log("StartTimer");
            allExiting = true;
        }
    }

    private void Update()
    {
        if (allExiting)
        {
            exitTime  -= Time.deltaTime;
        }

        if (exitTime < 0)
        {
            //Exit
            Debug.Log("DoneWaiting");
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            allExiting = false;
            exitTime = 4;
            Debug.Log("Exited");
        }
    }
}
