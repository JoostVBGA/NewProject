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



    // Start is called before the first frame update
    void Start()
    {
        // set initial position to the first waypoint
        currentWayPoint = waypoints.GetNextWaypoint(currentWayPoint);
        transform.position = currentWayPoint.position;

        // set next waypoint target
        currentWayPoint = waypoints.GetNextWaypoint(currentWayPoint);

        
    }

    // Update is called once per frame
    void Update()
    {
        transform.LookAt(currentWayPoint);

        transform.position = Vector3.MoveTowards(transform.position, currentWayPoint.position, moveSpeed * Time.deltaTime);
        if (Vector3.Distance(transform.position, currentWayPoint.position) < distanceThreshold)
        {
            currentWayPoint = waypoints.GetNextWaypoint(currentWayPoint);
        }
    }
}
