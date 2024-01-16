using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoadSpawner : MonoBehaviour
{
    public GameObject road;
    public float spawnrate = 2f;
    private float timer = 0;

    // Start is called before the first frame update
    void Start()
    {
        Instantiate(road, transform.position, transform.rotation);
    }

    // Update is called once per frame
    void Update()
    {
        if (timer < spawnrate)
        {
            timer = timer + Time.deltaTime;
        }
        else
        {
            Instantiate(road, transform.position, transform.rotation);
            timer = 0;
        }
        
    }
}
