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

    private void Start()
    {
        EventSystem.current.PlayerDrag += OnPlayerDrag;
    }

    private void OnPlayerDrag()
    {

    }

    private void OnDestroy()
    {
        EventSystem.current.PlayerDrag -= OnPlayerDrag;
    }

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

            Invoke("Delay", 1);
            
        }



        else 
        {
            Debug.Log("Click");
            var firstObject = Instantiate(wayPoint, player.position, Quaternion.identity, wayPointParent);
            firstObject.name = "wayPoint";
            Invoke("Delay", 1);
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
        if (Physics.Raycast(ray, out RaycastHit raycastHit))
        {
            playerhit = raycastHit.transform.gameObject;
            raycastHit.point = new Vector3(raycastHit.point.x, 0f, raycastHit.point.z);
            var newObject = Instantiate(wayPoint, raycastHit.point, Quaternion.identity, wayPointParent);
            newObject.name = "wayPoint (" + newObject.transform.GetSiblingIndex() + ")";
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
        
        //looks at next waypoint
        transform.LookAt(currentWayPoint);

        // follows to the nextwaypoint
        transform.position = Vector3.MoveTowards(transform.position, currentWayPoint.position, moveSpeed * Time.deltaTime);

        //if nextwaypoint is reached set next waypoint
        if (Vector3.Distance(transform.position, currentWayPoint.position) < distanceThreshold)
            currentWayPoint = waypoints.GetNextWaypoint(currentWayPoint);
        }

}
