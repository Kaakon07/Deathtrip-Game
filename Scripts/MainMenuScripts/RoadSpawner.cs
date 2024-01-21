using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoadSpawner : MonoBehaviour
{
    // referanse bla bla bla
    public GameObject road;

    // hvor ofte det lager en kopi
    public float spawnrate = 2f;

    // timer
    private float timer = 0;

    // Start is called before the first frame update
    void Start()
    {
        // lager en kopi på start
        Instantiate(road, transform.position, transform.rotation);
    }

    // Update is called once per frame
    void Update()
    {
        // hvor ofte det lager kopi
        if (timer < spawnrate)
        {
            timer = timer + Time.deltaTime;
        }
        else
        {
            // lager kopi
            Instantiate(road, transform.position, transform.rotation);
            timer = 0;
        }
        
    }
}
