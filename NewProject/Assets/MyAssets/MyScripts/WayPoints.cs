using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WayPoints : MonoBehaviour
{

    [Range(0f, 2f)]
    [SerializeField] private float waypointSize = 1f;

    //Draw Gizmos in Editor
    private void OnDrawGizmos()
    {
        
        foreach(Transform t in transform)
        {
            Gizmos.color = Color.red;
            Gizmos.DrawWireSphere(t.position, waypointSize);
        }

        Gizmos.color = Color.red;
        for (int i = 0; i <transform.childCount - 1; i++) 
        {
            Gizmos.DrawLine(transform.GetChild(i).position, transform.GetChild(i + 1).position);
        } 
    }

    //Waypoint System, get next waypoint, Destroy when at last waypoint
    public Transform GetNextWaypoint(Transform currentWaypoint)
    {
        if (transform.childCount < 1)
        {
            return null;
        }

        if (currentWaypoint == null)
        {
            return transform.GetChild(0);
        }

        if (currentWaypoint.GetSiblingIndex() < transform.childCount - 1)
        {
            return transform.GetChild(currentWaypoint.GetSiblingIndex() + 1);
        }

        if (currentWaypoint.GetSiblingIndex() > 1)
        {
            Debug.Log("LastWayPoint");
            foreach (Transform child in transform)
            {
                GameObject.Destroy(child.gameObject);
            }
            Debug.Log("DestroyWayPoints");
        }
        return null;

    }
}
