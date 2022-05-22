using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowTrial : MonoBehaviour
{
    // stores a reference to the waypoint system this object wil use
    [SerializeField] private WayPoints waypoints;

    // how fast object moves
    [SerializeField] private float moveSpeed = 5f;

    [SerializeField] private float distanceThreshold = 0.1f;

    // current target that the object moves toward
    private Transform currentWayPoint;

    public Transform wayPointParent;

    public Transform player;

    public GameObject playerhit;

    public GameObject wayPoint;

    [SerializeField] private Camera mainCamera;


    private void OnMouseDown()
    {
       if (wayPointParent.childCount > 0) 
        {
            foreach (Transform child in wayPointParent)
            {
                GameObject.Destroy(child.gameObject);
            }
            var firstObject = Instantiate(wayPoint, player.position, Quaternion.identity, wayPointParent);
            firstObject.name = "wayPoint";
            currentWayPoint = waypoints.GetNextWaypoint(currentWayPoint);
        }

        else 
        {
            Debug.Log("Click");
            var firstObject = Instantiate(wayPoint, player.position, Quaternion.identity, wayPointParent);
            firstObject.name = "wayPoint";
            currentWayPoint = waypoints.GetNextWaypoint(currentWayPoint);
        }
    }


    private void OnMouseDrag()
    {

        Ray ray = mainCamera.ScreenPointToRay(Input.mousePosition);

        if (Physics.Raycast(ray, out RaycastHit raycastHit))
        {
            playerhit = raycastHit.transform.gameObject;
            raycastHit.point = new Vector3(raycastHit.point.x, 0f, raycastHit.point.z);
            var newObject = Instantiate(wayPoint, raycastHit.point, Quaternion.identity, wayPointParent);
            newObject.name = "wayPoint (" + newObject.transform.GetSiblingIndex() + ")";
        }
    }



        // Update is called once per frame
        void Update() 
        {
        transform.LookAt(currentWayPoint);

        transform.position = Vector3.MoveTowards(transform.position, currentWayPoint.position, moveSpeed * Time.deltaTime);
        if (Vector3.Distance(transform.position, currentWayPoint.position) < distanceThreshold)
            currentWayPoint = waypoints.GetNextWaypoint(currentWayPoint);
        }

}
