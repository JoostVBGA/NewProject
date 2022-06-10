using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TransferControllerOverWorld : MonoBehaviour
{

    private void OnTriggerEnter(Collider other)
    {
            EventSystem.current.TransferTriggerEnter();
    }
}
