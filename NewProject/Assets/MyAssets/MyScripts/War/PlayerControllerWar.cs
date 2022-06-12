using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class PlayerControllerWar : MonoBehaviour
{
    // stores a reference to the waypoint system this object wil use
    [SerializeField] private WayPoints waypoints;

    [SerializeField] private float wayPointDistance = 0.2f;

    private Transform lastWayPoint;

    // how fast object moves
    [SerializeField] private float moveSpeed = 5f;

    [SerializeField] private float distanceThreshold = 0.1f;

    // current target that the object moves toward
    private Transform currentWayPoint;

    public Transform wayPointParent;

    public GameObject wayPoint;

    [SerializeField] private LayerMask Ground;

    [SerializeField] private Camera mainCamera;
    private void OnMouseDown()
    {

        Debug.Log("Click");
        if (wayPointParent.childCount > 0)
        {
            foreach (Transform child in wayPointParent)
            {
                GameObject.Destroy(child.gameObject);
            }
            var firstObject = Instantiate(wayPoint, transform.position, Quaternion.identity, wayPointParent);
            firstObject.name = "wayPoint";
            lastWayPoint = firstObject.transform;
            Invoke("Delay", 0);

        }

        else
        {
            Debug.Log("Click");
            var firstObject = Instantiate(wayPoint, transform.position, Quaternion.identity, wayPointParent);
            firstObject.name = "wayPoint";
            lastWayPoint = firstObject.transform;
            Invoke("Delay", 0);
        }
    }
    void Delay()
    {
        currentWayPoint = waypoints.GetNextWaypoint(currentWayPoint);
    }

    private void OnMouseDrag()
    {
        //Call the raycast from input mouseposition
        Ray ray = mainCamera.ScreenPointToRay(Input.mousePosition);

        //If raycast hits instantiatie a new waypoint object under waypoint parent
        if (Physics.Raycast(ray, out RaycastHit raycastHit, float.MaxValue,Ground))
        {
            raycastHit.point = new Vector3(raycastHit.point.x, 0f, raycastHit.point.z);

            if(lastWayPoint == null)
            {
                return;
            }
            float distance = Vector3.Distance(raycastHit.point, lastWayPoint.transform.position);

            if (distance < wayPointDistance)
            {
                return;
            }

            var newObject = Instantiate(wayPoint, raycastHit.point, Quaternion.identity, wayPointParent);
            newObject.name = "wayPoint (" + newObject.transform.GetSiblingIndex() + ")";
            lastWayPoint = newObject.transform;
        }
    }

    private void OnMouseUp()
    {
        //If there is only 1 waypoint at MouseUp destroy that waypoint
        if (wayPointParent.childCount < 2)
        {
            foreach (Transform child in wayPointParent)
            {
                GameObject.Destroy(child.gameObject);
            }
        }
    }

    void Update()
    {
        if (wayPointParent.childCount < 2)
        {
            return;
        }

        //looks at next waypoint
        transform.LookAt(currentWayPoint);

        if (currentWayPoint == null)
        {
            return;
        }

        // follows to the nextwaypoint
        transform.position = Vector3.MoveTowards(transform.position, currentWayPoint.position, moveSpeed * Time.deltaTime);
        
        //if nextwaypoint is reached set next waypoint
        if (Vector3.Distance(transform.position, currentWayPoint.position) < distanceThreshold)
                currentWayPoint = waypoints.GetNextWaypoint(currentWayPoint);
        
        
    }

}
