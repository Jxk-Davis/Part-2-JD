using UnityEngine.UI;
using UnityEngine.EventSystems;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallPlayer : MonoBehaviour
{
    public Color idleCol;
    public Color selectCol;
    SpriteRenderer sprite;
    Rigidbody2D rb2d;
    public float spe = 50;

    public bool selected;
    void Start()
    {
        sprite = GetComponent<SpriteRenderer>();
        rb2d = GetComponent<Rigidbody2D>();
        sprite.color = idleCol;
        selected = false;
    }

    void Update()
    {
        
    }

    public void Select()
    {
        
        if (selected == false)
        {//if selected is false: set selected to true, change colour to bright red
            sprite.color = selectCol;
            selected = true;
        } 
        else if (selected == true)
        {//if selected is true: set selected to false, change colour to dark red
            sprite.color = idleCol;
            selected = false;
        }
    }

    private void OnMouseDown()
    {
        //if player is clicked on, report to TeamCTRL
        TeamCTRL.SetSelectedPlayer(this);
    }

    public void Move(Vector2 direction)
    {
        rb2d.AddForce(direction * spe, ForceMode2D.Impulse);
    }
}
