using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriangleManager : MonoBehaviour
{

    public GameObject TriangleObj;


    public GameObject LeftWall;
    public GameObject RightWall;

    float offsetLeft;
    float offsetRight = -0.7f;


    int NumberOfTriangles;

    [Space]
    [Range(0.5f, 2.0f)]
    public float scale = 1;


    [Space]
    [Range(0, 15)]
    public int NumberOfTriangles_Start;
    [Range(1, 15)]
    public int NumberOfTriangles_Max;
    [Range(1, 10)]
    public int TriangleCountUpScore;





    void Start()
    {
        NumberOfTriangles = NumberOfTriangles_Start;

        Debug.Log("LeftWall.transform.localScale : " + LeftWall.transform.localScale);
        offsetLeft = (LeftWall.transform.localScale.x / 2f);
        offsetRight = -(RightWall.transform.localScale.x / 2f);

        StartCoroutine(CreateTriangles("Left"));
        StartCoroutine(CreateTriangles("Right"));
    }




    public void WallTouched(string LeftOrRight)
    {
        DeleteTriangles(LeftOrRight);
        StartCoroutine(CreateTriangles(LeftOrRight));
    }





    IEnumerator CreateTriangles(string LeftOrRight)
    {

        yield return new WaitForSeconds(0.1f);

        for (int i = 0; i < NumberOfTriangles; i++)  // Multiple triangles may appear in the same place.
        {
            int randomY = Random.Range(-6, 7);
            if (LeftOrRight == "Left")
            {
                GameObject tempObj = Instantiate(TriangleObj, new Vector2(LeftWall.transform.position.x + offsetLeft, randomY * 1.5f), LeftWall.transform.rotation);
                SetScale(tempObj);
                tempObj.transform.SetParent(LeftWall.transform);
            }
            else if (LeftOrRight == "Right")
            {
                GameObject tempObj = Instantiate(TriangleObj, new Vector2(RightWall.transform.position.x + offsetRight, randomY * 1.5f), RightWall.transform.rotation);
                SetScale(tempObj);
                tempObj.transform.SetParent(RightWall.transform);
            }

            yield return new WaitForSeconds(0.01f);
        }


        IncreaseNumberOfTriangles();


        yield break;
    }

    void SetScale(GameObject go)
    {
        go.transform.GetChild(0).transform.localScale = new Vector2(scale, scale);
        go.transform.GetChild(1).transform.localScale = new Vector2(scale, scale);
        go.transform.GetChild(2).transform.localScale = new Vector2(scale, scale);
    }





    void DeleteTriangles(string LeftOrRight)
    {
        if (LeftOrRight == "Left")
        {
            foreach (Transform child in LeftWall.transform)
            {
                GameObject.Destroy(child.gameObject);
            }
        }

        if (LeftOrRight == "Right")
        {
            foreach (Transform child in RightWall.transform)
            {
                GameObject.Destroy(child.gameObject);
            }
        }
    }


    void IncreaseNumberOfTriangles()
    {
        if (NumberOfTriangles >= NumberOfTriangles_Max) return;
        NumberOfTriangles = GameObject.Find("GameManager").GetComponent<GameManager>().score / TriangleCountUpScore + 1;
    }



}
