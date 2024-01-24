using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;
using UnityEditor;

public class ProceduralTilemap : MonoBehaviour
{
    // Start is called before the first frame update

    private GameObject player;
    private Vector3 playerPos;
    private Vector3 chunkSize;
    private Vector2 print1;
    private Vector2 print2;

    public Tilemap tilemap;
    public TileBase[] tileSet;

    void Start()
    {
        player = GameObject.Find("Player");
    }

    void GenerateTilemap(int chunkX, int chunkY)
    {
        for (int x = 0; x < 8; x++)
        {
            for (int y = 0; y < 8; y++)
            {
                Vector3Int tilePosition = new Vector3Int( chunkX*8 + x, chunkY*8 + y, 0 );
                if (x == 3)
                {
                    tilemap.SetTile( tilePosition, tileSet[ (int)(Random.value*2) ] );
                }
                else
                {
                    tilemap.SetTile( tilePosition, tileSet[ (int)(Random.value*2) ] );
                }
            }
        }
    }

    bool checkTileExists(Vector3 unitPosition)
    {
        return tilemap.GetTile(new Vector3Int( (int)Mathf.Floor(unitPosition.x) >> 2, (int)Mathf.Floor(unitPosition.y) >> 2 ) ) == false;
    }

    void checkChunkAndGenerate(Vector3 unitPosition)
    {
        if (checkTileExists(unitPosition)) // Checks if the tile the player is currently on exists or not
        {
            GenerateTilemap( (int)Mathf.Floor(unitPosition.x) >> 5, (int)Mathf.Floor(unitPosition.y) >> 5 ); // Generates a new chunk where the player is
        }
    }
    

    // Update is called once per frame
    void Update()
    {
        playerPos = player.transform.position;

        checkChunkAndGenerate(playerPos - (new Vector3(32, 0, 0)));
        checkChunkAndGenerate(playerPos);
        checkChunkAndGenerate(playerPos + (new Vector3(32, 0, 0)));
    }

}
