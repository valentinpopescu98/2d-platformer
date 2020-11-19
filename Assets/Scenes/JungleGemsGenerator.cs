using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class JungleGemsGenerator : MonoBehaviour
{
    [Tooltip("The Tilemap to draw onto")]
    public Tilemap tilemap;
    [Tooltip("The Tile to draw (use a RuleTile for best results)")]
    public TileBase tile;

    public int startX;
    public int startY;
    public int endX;
    public int endY;
    public static int lungimeSpatiuMin = 1;
    public static int lungimeSpatiuMax = 6;
    System.Random rand = new System.Random();

    void Start()
    {
        for (int i = 0; i < endX - startX; i++)
        {
            int pozitieVerticala = rand.Next(startY, endY);

            tilemap.SetTile(new Vector3Int(startX + i, pozitieVerticala, 0), tile);

            int lungimeSpatiu = rand.Next(lungimeSpatiuMin, lungimeSpatiuMax);
            i += lungimeSpatiu;
        }
    }
}
