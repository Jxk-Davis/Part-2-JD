using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Plane : MonoBehaviour
{
    public List<Vector2> points;
    public float newPointThreshold = 0.2f;
    Vector2 lastPos;
    LineRenderer lineRenderer;

    private void Start()
    {
        lineRenderer = GetComponent<LineRenderer>();
        lineRenderer.positionCount = 1;
        lineRenderer.SetPosition(0, transform.position);
    }

    private void OnMouseDown()
    {
        //arrays---------------------
        points = new List<Vector2>();
        Vector2 currentPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        points.Add(currentPos);

        //lines----------------------
        lineRenderer.positionCount = 1;
        lineRenderer.SetPosition(0, transform.position);
    }

    private void OnMouseDrag()
    {
        Vector2 currentPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        if(Vector2.Distance(currentPos, lastPos) > newPointThreshold)
            {
                points.Add(currentPos);
                lineRenderer.positionCount += 1;
                lineRenderer.SetPosition(lineRenderer.positionCount - 1, currentPos);
                lastPos = currentPos;
            }
        //do something smart
    }
}
