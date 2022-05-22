using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    [SerializeField] private float movespeed = 5f;


    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.W))
        {
            gameObject.transform.position += new Vector3(0, 0, movespeed);
        }

        if (Input.GetKeyDown(KeyCode.A))
        {
            gameObject.transform.position += new Vector3(-movespeed, 0, 0);
        }

        if (Input.GetKeyDown(KeyCode.S))
        {
            gameObject.transform.position += new Vector3(0, 0, -movespeed);
        }

        if (Input.GetKeyDown(KeyCode.D))
        {
            gameObject.transform.position += new Vector3(movespeed, 0, 0);
        }
    }
}
