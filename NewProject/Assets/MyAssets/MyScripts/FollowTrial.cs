using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowTrial : MonoBehaviour
{
    public float speed;
    public float MaxiNum;
    int pointIndex;
    Transform movePoint;
    public Transform[] points;

    // Start is called before the first frame update
    void Start()
    {
        pointIndex = 0;
        movePoint = points[pointIndex];
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = Vector2.MoveTowards(transform.position, movePoint.position, speed * Time.deltaTime);
        if (Vector2.Distance(transform.position, movePoint.position) <= 0)

        {

            if (pointIndex > MaxiNum)
            {
                pointIndex = 0;
            }

            pointIndex++;
            movePoint = points[pointIndex];
        }
           
        Vector2 pos = movePoint.position = transform.position;
        float angle = Mathf.Atan2(pos.y, pos.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0, 0, angle - 90);
    }
}
