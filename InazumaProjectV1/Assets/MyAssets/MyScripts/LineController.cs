using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LineController : MonoBehaviour
{
    private LineRenderer _lineRenderer;
    [SerializeField] private Transform[] _wayPoints;

    // Start is called before the first frame update
    void Start()
    {
        _lineRenderer = GetComponent<LineRenderer>(); 
    }

    // Update is called once per frame
    void Update()
    {
        _lineRenderer.positionCount = _wayPoints.Length;
        for (int i = 0; i < _wayPoints.Length; i++)
        {
            _lineRenderer.SetPosition(i, _wayPoints[i].position);
        }
    }
}
