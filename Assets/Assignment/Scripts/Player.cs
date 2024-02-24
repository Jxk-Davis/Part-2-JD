using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    //state machine!
    //idle : do nothing but wait for mouse to be clicked on you, then swap to primed
    //primed : do nothing but wait for mouse to be clicked somewhere, then save the click position and swap to move
    //move : move towards the saved click position, once arrived swap to idle

    //seperate to the state machine, a bool which records whether player has picked up an item

    public enum STATE
    {
        idle, primed, move
    }
    public STATE state;
    Vector2 movement;
    Vector2 target;
    public bool carrying;
    public float spe;
    Rigidbody2D rb2d;

    void Start()
    {
        carrying = false;
        state = STATE.idle;
        rb2d = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
    {
        if (state == STATE.move)
        {
            Move();
        }
    }

    void Update()
    {
        if (state == STATE.primed)
        {
            Primed();
        }
    }

    void Primed()
    {
        //wait for mouse to be clicked somewhere, then save clicked position then swap to move
        if (Input.GetMouseButtonDown(0)) 
        {
            target = Camera.main.ScreenToWorldPoint(Input.mousePosition); //save target
            
            //transition
            state = STATE.move;
        }
    }

    void Move()
    {
        //start moving towards the cursor position, when arrived, swap to idle
        movement = target - (Vector2)transform.position;
        rb2d.MovePosition(rb2d.position + movement.normalized * spe * Time.deltaTime);

        if (movement.magnitude <= 0.1) //if you get close enough to your destination...
        {
            movement = Vector2.zero; //stop moving
            state = STATE.idle; //swap to idle
        }
    }

    private void OnMouseUp()
    {
        state = STATE.primed;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        target = transform.position; //stop moving if you run into something.
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (carrying == false) return;
    }
}
