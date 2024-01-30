using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LibraryRandom : MonoBehaviour
{
    private int temp;
    private int randTemp;


    public float randomFloatFromVector2(Vector2Int randSeed)
    {

        if (randSeed.y > randSeed.x)
        {
            Random.InitState(randSeed.y * randSeed.y + randSeed.x);
        }
        else
        {
            Random.InitState(randSeed.x * randSeed.x + randSeed.x + randSeed.y);
        }
        temp = (int)Random.value;
        return Random.value;
    }



    public int random32Bit(int randSeed)
    {
        Random.InitState(randSeed);
        randTemp = (int)Random.value;
        return (int)(Random.value*0xFFFFFFFF) ;
    }



    public Vector2 randomVector2FromVector2(Vector2Int randSeed)
    {

        if (randSeed.y > randSeed.x)
        {
            Random.InitState(randSeed.y * randSeed.y + randSeed.x);
        }
        else
        {
            Random.InitState(randSeed.x * randSeed.x + randSeed.x + randSeed.y);
        }
        temp = (int)Random.value;
        return new Vector2(Random.value, Random.value);
    }

    void Start()
    {

    }
}
