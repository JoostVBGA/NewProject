using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class PlayerControllerWar : MonoBehaviour
{
    [Header("Waypoints")]

    [SerializeField] private WayPoints wayPointsScript;

    [SerializeField] private float wayPointDistance = 0.2f;

    private Transform lastWayPoint;

    [Header("MovementParameters")]
    [SerializeField] private float moveSpeed = 5f;

    [SerializeField] private float distanceThreshold = 0.1f;

    [Header("NextWayPoint")]
    private Transform currentWayPoint;

    public Transform wayPointParent;

    public GameObject wayPoint;

    private bool didCollide = false;

    [Header("References")]
    [SerializeField] private LayerMask Ground;

    [SerializeField] private LayerMask Collide;

    [SerializeField] private Camera mainCamera;

    [SerializeField] private string playername;

    private void Awake()
    {
        wayPointsScript = GameObject.Find ("WayPoints").GetComponent<WayPoints>();
        wayPointParent = GameObject.Find("WayPoints").transform;
        mainCamera = Camera.main;
       
    }

    private void Start()
    {
        playername = this.gameObject.name;
        Debug.Log(this.gameObject.name);

        //spawn parent

        //var waypointparent = 
    }

    //FirstWayPoint
    private void OnMouseDown()
    {

        if (wayPointParent.childCount > 0)
        {
            foreach (Transform child in wayPointParent)
            {
                GameObject.Destroy(child.gameObject);
            }
            var firstObject = Instantiate(wayPoint, transform.position, Quaternion.identity, wayPointParent);
            firstObject.name = "wayPoint";
            lastWayPoint = firstObject.transform;
            didCollide = false;
            Invoke("Delay", 0);

        }

        else
        {
            var firstObject = Instantiate(wayPoint, transform.position, Quaternion.identity, wayPointParent);
            firstObject.name = "wayPoint";
            lastWayPoint = firstObject.transform;
            didCollide = false;
            Invoke("Delay", 0);
        }
    }
    void Delay()
    {
        currentWayPoint = wayPointsScript.GetNextWaypoint(currentWayPoint);
    }

    //Drag
    private void OnMouseDrag()
    {
        //Call the raycast from input mouseposition
        Ray ray = mainCamera.ScreenPointToRay(Input.mousePosition);

        //If raycast hits instantiatie a new waypoint object under waypoint parent

        if (Physics.Raycast(ray, out RaycastHit raycasthit, float.MaxValue,Collide))
        {
            didCollide = true;
            return;

        }

        if (Physics.Raycast(ray, out RaycastHit raycastHit, float.MaxValue,Ground) && !didCollide)
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

    //If there is only 1 waypoint at MouseUp destroy that waypoint
    private void OnMouseUp()
    {
        
        if (wayPointParent.childCount < 2)
        {
            foreach (Transform child in wayPointParent)
            {
                GameObject.Destroy(child.gameObject);
            }
        }
    }

    //Walking
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
                currentWayPoint = wayPointsScript.GetNextWaypoint(currentWayPoint);

    }
}
