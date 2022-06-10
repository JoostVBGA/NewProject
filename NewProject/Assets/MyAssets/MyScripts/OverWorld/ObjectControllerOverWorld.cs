using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectControllerOverWorld : MonoBehaviour
{

    private void OnTriggerEnter(Collider other)
    {
        if (Input.GetKey("e"))
        {
            EventSystem.current.ObjectInteract();
        }

        if (Input.GetKey(KeyCode.Mouse0))
        {
            EventSystem.current.ObjectInteract();
        }
    }

}
