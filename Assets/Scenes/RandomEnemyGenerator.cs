using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class RandomEnemyGenerator : MonoBehaviour
{
    [Tooltip("The Tilemap to draw onto")]
    public Tilemap tilemap;
    [Tooltip("The Tile to draw Ken enemies")]
    public TileBase tile1;
    [Tooltip("The Tile to draw Dragon enemies")]
    public TileBase tile2;

    public int startX;
    public int startY;
    public int endX;
    public int endY;
    public static int lungimeSpatiuMin = 20;
    public static int lungimeSpatiuMax = 60;
    System.Random rand = new System.Random();

    void Start()
    {
        for (int i = 0; i < endX - startX; i++)
        {
            int pozitieVerticala = rand.Next(startY, endY);
            int enemyTypeSpawned = rand.Next(2);

            if(enemyTypeSpawned==0)
                tilemap.SetTile(new Vector3Int(startX + i, pozitieVerticala, 0), tile1);
            else
                tilemap.SetTile(new Vector3Int(startX + i, pozitieVerticala, 0), tile2);

            int lungimeSpatiu = rand.Next(lungimeSpatiuMin, lungimeSpatiuMax);
            i += lungimeSpatiu;
        }
    }
}
