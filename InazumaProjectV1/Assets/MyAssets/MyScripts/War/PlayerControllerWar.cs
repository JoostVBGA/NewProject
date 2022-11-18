using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class PlayerControllerWar : MonoBehaviour
{
    [Header("Waypoints")]

    private WayPoints wayPointsScript;

    [SerializeField] private float wayPointDistance = 0.2f;

    [SerializeField]private Transform lastWayPoint;

    [Header("MovementParameters")]
    [SerializeField] private float moveSpeed = 5f;

    [SerializeField] private float distanceThreshold = 0.1f;

    [Header("NextWayPoint")]
    private Transform currentWayPoint;

    [SerializeField] private GameObject wayPointParent;

    [SerializeField] private GameObject wayPoint;

    [SerializeField] private GameObject rendererObject;

    private bool didCollide = false;

    [Header("References")]
    [SerializeField] private LayerMask Ground;

    [SerializeField] private LayerMask Collide;

    private Camera mainCamera;

    private string playername;

    [Header("Renderer")]

    [SerializeField] private LineRenderer lineRenderer;
    [SerializeField] private int Target;


    private void Awake()
    {
        mainCamera = Camera.main;
    }

    private void Start()
    {
        playername = this.gameObject.name;

        //spawn parent

        var spawnparent = Instantiate (wayPointParent);
        spawnparent.transform.position = new Vector3(0, 0, 0);
        spawnparent.name = playername + "Parent";

        wayPointsScript = GameObject.Find(playername + "Parent").GetComponent<WayPoints>();
        wayPointParent = GameObject.Find(playername + "Parent");

        var spawnrenderer = Instantiate(rendererObject);
        spawnrenderer.transform.position = new Vector3(0, 0, 0);
        spawnrenderer.name = playername + "renderer";

        rendererObject = GameObject.Find(playername + "renderer");
        lineRenderer = rendererObject.GetComponent<LineRenderer>();

    }

    //FirstWayPoint
    private void OnMouseDown()
    {

        if (wayPointParent.transform.childCount > 0)
        {
            foreach (Transform child in wayPointParent.transform)
            {
                GameObject.Destroy(child.gameObject);
                lineRenderer.positionCount = 0;
            }
            var firstObject = Instantiate(wayPoint, transform.position, Quaternion.identity, wayPointParent.transform);
            firstObject.name = "wayPoint";
            lastWayPoint = firstObject.transform;
            didCollide = false;
            Invoke("Delay", 0);

        }

        else
        {
            var firstObject = Instantiate(wayPoint, transform.position, Quaternion.identity, wayPointParent.transform);
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

            var newObject = Instantiate(wayPoint, raycastHit.point, Quaternion.identity, wayPointParent.transform);
            newObject.name = "wayPoint (" + newObject.transform.GetSiblingIndex() + ")";
            lastWayPoint = newObject.transform;
            AssignTarget();
        }
    }

    //If there is only 1 waypoint at MouseUp destroy that waypoint
    private void OnMouseUp()
    {
        
        if (wayPointParent.transform.childCount < 2)
        {
            foreach (Transform child in wayPointParent.transform)
            {
                GameObject.Destroy(child.gameObject);
            }
        }
    }

    //Walking
    void Update()
    {

        if (wayPointParent.transform.childCount < 1 && lineRenderer.positionCount > 0)
        {
            lineRenderer.positionCount = 0;
        }
        if (wayPointParent.transform.childCount < 2)
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

    public void AssignTarget()
    {
        lineRenderer.positionCount = lineRenderer.positionCount + 1;

        Target = lineRenderer.positionCount - 1;

        Debug.Log(lastWayPoint.position);

        lineRenderer.SetPosition(Target, lastWayPoint.position);

    }
}
