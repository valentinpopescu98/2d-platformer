using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class JungleGenerator : MonoBehaviour
{
    [Tooltip("The Tilemap to draw onto terrain")]
    public Tilemap tilemap1;
    [Tooltip("The Tilemap to draw onto background")]
    public Tilemap tilemap2;
    [Tooltip("The Tile to draw terrain(use a RuleTile for best results)")]
    public TileBase tile1;
    [Tooltip("The Tile to draw background(use a RuleTile for best results)")]
    public TileBase tile2;

    public int startX;
    public int startY;
    public int endX;
    public static int lungimePlatformaMin = 2;
    public static int lungimePlatformaMax = 20;
    public static int lungimeGauraMin = 1;
    public static int lungimeGauraMax = 6;
    System.Random rand = new System.Random();

    void Start()
    {
        int i = 0;

        while(i<endX)
        {
            int lungimePlatforma = rand.Next(lungimePlatformaMin, lungimePlatformaMax);

            for (int j=0;j<lungimePlatforma;j++)
            {
                if (startX >= endX)
                    break;

                tilemap1.SetTile(new Vector3Int(startX, startY, 0), tile1);
                tilemap1.SetTile(new Vector3Int(startX, startY - 1, 0), tile1);
                tilemap1.SetTile(new Vector3Int(startX, startY - 2, 0), tile1);
                tilemap2.SetTile(new Vector3Int(startX, startY + 1, 0), tile2);

                startX++;
                i++;
            }

            int lungimeGaura = rand.Next(lungimeGauraMin, lungimeGauraMax);
            startX += lungimeGaura;
            i += lungimeGaura;
        }
    }
}
