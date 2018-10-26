using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotation : Tween<Vector3> {

    protected override void UpdateProperty(float progress)
    {
        this.transform.eulerAngles = Vector3.Lerp(from, to, timer / progress);
    }
}
