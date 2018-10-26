using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallManager : MonoBehaviour
{

    float mapX = 100.0f;
    float mapY = 100.0f;

    public GameObject Wall_Left;
    public GameObject Wall_Right;
    public GameObject Wall_Top;
    public GameObject Wall_Bottom;

    [Space]
    public bool removeWall;
    [Range(1, 5)]
    public float wallThickness;
    float positionOffset;


    void Awake()
    {
        if (removeWall)
        {
            wallThickness = 1;
            positionOffset = (wallThickness / 2);
        }
        else
        {
            positionOffset = 0;
        }


        float vertExtent = Camera.main.orthographicSize;
        float horzExtent = vertExtent * Screen.width / Screen.height;

        float minX = horzExtent - mapX / 2.0f;
        float maxX = mapX / 2.0f - horzExtent;
        float minY = vertExtent - mapY / 2.0f;
        float maxY = mapY / 2.0f - vertExtent;

        Wall_Left.transform.position = new Vector2(maxX - 50 - positionOffset, 0);
        Wall_Left.transform.localScale = new Vector2(wallThickness, (minY + 50) * 2);

        Wall_Right.transform.position = new Vector2(minX + 50 + positionOffset, 0);
        Wall_Right.transform.localScale = new Vector2(wallThickness, (minY + 50) * 2);

        Wall_Top.transform.position = new Vector2(0, minY + 50 + positionOffset);
        Wall_Top.transform.localScale = new Vector2((maxX - 50) * 2, wallThickness);

        Wall_Bottom.transform.position = new Vector2(0, maxY - 50 - positionOffset);
        Wall_Bottom.transform.localScale = new Vector2((maxX - 50) * 2, wallThickness);

    }

}
