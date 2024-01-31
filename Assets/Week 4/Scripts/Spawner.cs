using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public Sprite[] sprites;
    public GameObject plane;
    private float timer = 0;
    private float delay = 5;
    public Sprite test;
    
    Vector3 position;
    Quaternion rotation; //!!!!

    void Start()
    {

    }

    void Update()
    {
        timer += Time.deltaTime;
        if (timer > delay)
        {
            Spawn();
        }
    }

    private void Spawn()
    {
        Vector2 pos = new Vector2(Random.Range(-5, 5), Random.Range(-5, 5)); //random place
        Vector3 rot = new Vector3(0, 0, Random.Range(1,360)); //random direction
        GameObject newPlane = Instantiate(plane, pos, Quaternion.identity);//instatiation
        newPlane.transform.Rotate(0, 0, Random.Range(1, 360));//random rotation
        //with a random sprite
        SpriteRenderer planeSpr = newPlane.GetComponent<SpriteRenderer>();
        planeSpr.sprite = sprites[Random.Range(0,4)];

        //time management
        delay = Random.Range(1, 5); // reset the delay
        timer = 0; //reset the times
    }
}
