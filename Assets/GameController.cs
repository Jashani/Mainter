using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    public enum Tile
    {
        Air,
        Wall,
        CleanTile,
        PaintedTile
    }

    private const int MAX_SIZE = 12;
    public static int[,] field = 
        {{1,1,1,1,1,1,1,1,1,1,1,1},
        {1,2,2,1,2,2,2,2,1,2,2,1},
        {1,2,2,2,2,2,2,2,1,2,2,1},
        {1,2,2,2,2,2,2,2,2,2,2,1},
        {1,1,2,2,2,2,2,2,2,2,2,1},
        {1,2,2,2,1,2,2,2,2,2,2,1},
        {1,2,2,1,1,1,1,1,1,1,2,1},
        {1,2,2,2,1,2,2,2,2,2,2,1},
        {1,2,2,2,1,2,2,2,2,2,2,1},
        {1,2,2,2,1,2,2,2,2,2,2,1},
        {1,2,2,2,1,2,2,2,2,2,2,1},
        {1,1,1,1,1,1,1,1,1,1,1,1}};

    public static Vector3 Move(Vector3 src, Vector2 direction)
    {
        Vector2 dst = new Vector2(src.x + 0.5f, src.z + 0.5f);

        while (dst.x < MAX_SIZE && dst.y < MAX_SIZE)
        {
            if (field[MAX_SIZE-(int)dst.y - 1, (int)dst.x] == (int)Tile.Wall)
                break;
            dst += direction;
        }

        Vector2 ret = dst - direction;
        dst -= direction;

        return new Vector3(ret.x - 0.5f, src.y, ret.y - 0.5f);
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
