using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Plane : MonoBehaviour
{
    public List<Vector2> points;
    public float newPointThreshold = 0.2f;
    Vector2 lastPos;
    Rigidbody2D rb2d;
    LineRenderer lineRenderer;
    Vector2 currentPosition;
    private float spe;
    public float speMax;
    public float speMin;
    public AnimationCurve landing;
    float landingTimer;
    SpriteRenderer sprRend;
    public float safe;

    private void Start()
    {
        spe = Random.Range(speMin, speMax);
        sprRend = GetComponent<SpriteRenderer>();
        lineRenderer = GetComponent<LineRenderer>();
        rb2d = GetComponent<Rigidbody2D>();
        ResetLineRenderer(transform.position);
    }

    private void OnMouseDown()
    {
        //arrays---------------------
        points = new List<Vector2>();
        Vector2 currentPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        points.Add(currentPos);

        //lines----------------------
        ResetLineRenderer(transform.position);
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

    private void FixedUpdate()
    {
        currentPosition = new Vector2(transform.position.x, transform.position.y);

        if(points.Count > 0 )
        {
            Vector2 dir = points[0] - currentPosition; //??????????? gets the direction between 2 points?
            float angle = Mathf.Atan2(dir.x, dir.y)* Mathf.Rad2Deg;
            rb2d.rotation = -angle;
        }

        rb2d.MovePosition(rb2d.position + (Vector2)transform.up * spe * Time.deltaTime);
    }

    private void Update()
    {
        if(Input.GetKey(KeyCode.Space))
        {
            landingTimer += 0.1f * Time.deltaTime;
            float interpolation = landing.Evaluate(landingTimer);
            transform.localScale = Vector3.Lerp(transform.localScale, Vector3.zero, interpolation);

            if (transform.localScale.x < 0.1)
            {
                Destroy(gameObject); //when the beat drops...
            }
        }

        if(points.Count > 0)
        {
            if(Vector2.Distance(currentPosition, points[0]) < newPointThreshold)
            {
                points.RemoveAt(0);

                for(int i = 0; i < lineRenderer.positionCount - 2; i++) //write 1 to 0, 2 to 1, 3 to 2.... etc. turn 1 into the new zero
                {
                    lineRenderer.SetPosition(i, lineRenderer.GetPosition(i + 1));//bring value from ahead to here

                }
                lineRenderer.positionCount -= 1; //get rid of the now redundant final number
            }
        }
    }

    private void ResetLineRenderer(Vector3 position)
    {
        lineRenderer.positionCount = 1;
        lineRenderer.SetPosition(0, position);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        sprRend.material.color = Color.red;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Destroy(gameObject); ///when the beat drops...
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        Debug.Log("Onion");
        float dist = Vector3.Distance(collision.transform.position, transform.position);
        if (dist < safe)
        {
            Destroy(gameObject);
        }
    }

    private void OnBecameInvisible()
    {
        Destroy(gameObject);
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        sprRend.material.color = Color.white;
    }
}