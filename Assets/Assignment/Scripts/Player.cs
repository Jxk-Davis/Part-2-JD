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

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
         
    }

    void Move()
    { 
        //start moving towards the cursor position
    }
}
