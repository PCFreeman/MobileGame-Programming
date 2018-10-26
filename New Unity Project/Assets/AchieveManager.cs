using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AchieveManager  {

    public void Initialize()
    {
        Vector3 v1 = Vector3.up;
        Vector3 v2 = Vector3.right;

        for (int i = 0; i < 1000000; ++i)
        {
            AddVector(v1, v2);
        }
    }

    private Vector3 AddVector(Vector3 v1, Vector3 v2)
    {
        return v1 + v2;
    }
}
