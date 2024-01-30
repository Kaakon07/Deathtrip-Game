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
    private Vector2 randTemp;


    public Tilemap tilemap;
    public TileBase[] tileSet;
    public Rigidbody2D playerRB;
    public MoveScript moveScript;
    public LibraryRandom libRand;

    float randFromVector2(Vector2Int randSeed)
    {
        return 0.5f;
    }

    void Start()
    {
        player = GameObject.Find("Player");

        // Generate the chunks around spawn
        checkChunkAndGenerate(new Vector3(0, 0));
        checkChunkAndGenerate(new Vector3(-1, 0));
        checkChunkAndGenerate(new Vector3(0, -1));
        checkChunkAndGenerate(new Vector3(-1, -1));
    }

    bool tileRoad(Vector3Int tilePos, Vector2Int deltaPos) // Checks if the current tile lies on the road or in the sand
    {
        randTemp = libRand.randomVector2FromVector2(tileToChunkPosition(tilePos)); // Creates a random Vector2Int

        if (deltaPos.x == 0 && randTemp.x > 0.5f) // Checks if randTemp is true and the tile lies on the left edge of the chunk
        {
            return true;
        }
        else
        {
            if (deltaPos.y == 0 && randTemp.y > 0.5f) // Checks if randTemp is true and the tile lies on the bottom edge of the chunk
            {
                return true;
            }
            else
            {
                return false; // Returns false if the tile is sand
            }
        }
    }

    int tileConnect(Vector3Int tilePos, Vector2Int deltaPos) // Connects textures
    {
        if ( !tileRoad(tilePos, deltaPos) ) // Checks if the tile is road or sand
        {
            return 0;
        }
        int tileConnectedCount = 0;
        if ( tileRoad(tilePos + new Vector3Int(1, 0, 0), new Vector2Int((deltaPos.x + 1) & 7, (deltaPos.y) & 7)) ) // Checks the tile to the right
        {
            tileConnectedCount += 1;
        }
        if ( tileRoad(tilePos + new Vector3Int(0, 1, 0), new Vector2Int((deltaPos.x) & 7, (deltaPos.y + 1) & 7)) ) // Checks the tile above
        {
            tileConnectedCount += 2;
        }
        if ( tileRoad(tilePos + new Vector3Int(-1, 0, 0), new Vector2Int((deltaPos.x - 1) & 7, (deltaPos.y) & 7)) ) // Checks the tile to the left
        {
            tileConnectedCount += 4;
        }
        if ( tileRoad(tilePos + new Vector3Int(0, -1, 0), new Vector2Int((deltaPos.x) & 7, (deltaPos.y - 1) & 7)) ) // Checks the tile below
        {
            tileConnectedCount += 8;
        }

        return tileConnectedCount; // Returns index
    }

    void GenerateTilemap(int chunkX, int chunkY) // Generates the tilemap
    {
        for (int x = 0; x < 8; x++) // Loop for x axis
        {
            for (int y = 0; y < 8; y++) // Loop for y axis
            {
                Vector3Int tilePosition = new Vector3Int( chunkX*8 + x, chunkY*8 + y, 0 ); // Creates a tile position variable
                Vector2Int deltaPosition = new Vector2Int(x, y); // Creates a vector that represents where the tile lies in the chunk

                tilemap.SetTile(tilePosition, tileSet[ tileConnect(tilePosition, deltaPosition) ]); // Generates a tile
            }
        }
    }

    Vector3Int unitToTilePosition(Vector3 unitPosition) // Converts unity units to tile position
    {
        return new Vector3Int((int)Mathf.Floor(unitPosition.x) >> 2, (int)Mathf.Floor(unitPosition.y) >> 2);
    }

    Vector2Int tileToChunkPosition(Vector3Int tilePosition) // Converts tiles to chunks
    {
        return new Vector2Int((int)Mathf.Floor(tilePosition.x) >> 3, (int)Mathf.Floor(tilePosition.y) >> 3);
    }

    bool checkTileExists(Vector3 unitPosition) // Checks if the tile at unitPosition exists
    {
        return tilemap.GetTile(unitToTilePosition(unitPosition)) == false;
    }

    void checkChunkAndGenerate(Vector3 unitPosition)
    {
        if (checkTileExists(unitPosition)) // Checks if the tile at unitPosition exists
        {
            GenerateTilemap( (int)Mathf.Floor(unitPosition.x) >> 5, (int)Mathf.Floor(unitPosition.y) >> 5 ); // Generates a new chunk at unitPosition
        }
    }

    bool checkTileMoved() // Checks if the player has moved into a new tile
    {
        playerPos = player.transform.position;
        return unitToTilePosition(moveScript.previousPlayerPosition) != unitToTilePosition(playerPos);
    }
    

    void Update()
    {
        playerPos = player.transform.position;

        if (checkTileMoved()) // Checks if the player has moved into a new tile
        {
            //Debug.Log("Player entered a new tile!"); // Prints a message when the player moves into a new tile

            // Generates chunks from (-1, -1) to (1, -1)
            checkChunkAndGenerate(playerPos + new Vector3(-32, -32, 0) );
            checkChunkAndGenerate(playerPos + new Vector3(0, -32, 0) );
            checkChunkAndGenerate(playerPos + new Vector3(32, -32, 0) );

            // Generates chunks from (-1, 0) to (1, 0)
            checkChunkAndGenerate(playerPos + new Vector3(-32, 0, 0) );
            checkChunkAndGenerate(playerPos);
            checkChunkAndGenerate(playerPos + new Vector3(32, 0, 0) );

            // Generates chunks from (-1, 1) to (1, 1)
            checkChunkAndGenerate(playerPos + new Vector3(-32, 32, 0));
            checkChunkAndGenerate(playerPos + new Vector3(0, 32, 0));
            checkChunkAndGenerate(playerPos + new Vector3(32, 32, 0));

            // Sets the previousPlayerPosition variable to the current position to not repeat the same thing too many times
            moveScript.previousPlayerPosition = playerPos;
        }
    }

}
