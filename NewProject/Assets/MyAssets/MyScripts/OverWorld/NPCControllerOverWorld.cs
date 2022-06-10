using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCControllerOverWorld : MonoBehaviour
{

    private void OnTriggerEnter(Collider other)
    {
        if (Input.GetKey("e"))
        {
            EventSystem.current.NPCInteract();
        }

        if (Input.GetKey(KeyCode.Mouse0))
        {
            EventSystem.current.NPCInteract();
        } 
    }
}
