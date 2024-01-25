using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LibraryRandom : MonoBehaviour
{
    private int temp;
    private int randTemp;
    public int[] permutationTable = new int[256];
    //List<int> permutationList;


    public float randomFloatFromVector2(Vector2Int randSeed)
    {

        //return (float)( permutationTable[ ( randSeed.y + permutationTable[randSeed.x & 255] ) & 255 ] ) / 255;
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

    public Vector2 randomVector2FromVector2(Vector2Int randSeed)
    {

        //return (float)( permutationTable[ ( randSeed.y + permutationTable[randSeed.x & 255] ) & 255 ] ) / 255;
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
        for (int x = 0; x < 255; x++)
        {
            permutationTable[x] = x;
        }

        Random.InitState(42);
        for (int x = 1; x < 512; x++)
        {
            randTemp = (int)(Random.value * 256);
            temp = permutationTable[x];
            permutationTable[x] = permutationTable[randTemp];
            permutationTable[randTemp] = temp;
        }

    }
}
