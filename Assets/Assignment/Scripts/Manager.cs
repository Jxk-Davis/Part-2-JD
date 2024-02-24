using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Manager : MonoBehaviour
{
    //wait for a timer to finish, then spawn a snow object in a random spot.
    //wait for a timer to finish, then spawn an item object in a random spot.

    public GameObject snow;
    public GameObject item;
    public float snowTimer;
    public float itemTimer;
    public float snowDelay;
    public float itemDelay;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        snowTimer -= Time.deltaTime;
        itemTimer -= Time.deltaTime;

        if (snowTimer <= 0) DropSnow();
        if (itemTimer <= 0) DropItem();
    }

    void DropItem() 
    {
        
    }
    void DropSnow()
    {
        //pick a random spot on the rightmost 2/3rds of the screen and instantiate 1 snow object

        Vector2 pos = new Vector2(Random.Range(-6, 8), Random.Range(-4, 4)); //random place
        Instantiate(snow, pos, Quaternion.identity);

        snowTimer = snowDelay;
    }
}
