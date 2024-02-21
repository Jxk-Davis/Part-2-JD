using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Manager : MonoBehaviour
{
    //wait for a timer to finish, then spawn a snow object in a random spot.
    //wait for a timer to finish, then spawn an item object in a random spot.

    public GameObject snow;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        DropSnow();
    }

    void DropSnow()
    {
        //pick a random spot on the rightmost 2/3rds of the screen and instantiate 1 snow object
    }
}
