using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public List<Sprite> sprites;
    public GameObject plane;
    private float timer = 0;
    private float delay = 1;

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
        Debug.Log("spawning!!");
        Vector2 pos = new Vector2(Random.Range(-5, 5), Random.Range(-5, 5)); //random place
        Vector3 rot = new Vector3(0, 0, Random.Range(1,360)); //random direction
        transform.Rotate(0, 0, rot);
        Instantiate(plane, pos, rot);
        //instantiate the guy at a random place
        //with a random rotation
        //with a random sprite
        delay = Random.Range(1, 5); // reset the timer
    }
}
