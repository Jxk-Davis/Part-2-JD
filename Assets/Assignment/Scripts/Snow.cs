using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Snow : MonoBehaviour
{
    //do nothing but wait for the mouse to click on you.
    //each time the mouse clicks on you, reduce HP by 1. when HP is zero, dis-appear....
    public int HP;

    private void Update()
    {
        if (HP <= 0) Destroy(gameObject);
    }

    private void OnMouseDown()
    {
        HP -= 1;
    }
}
