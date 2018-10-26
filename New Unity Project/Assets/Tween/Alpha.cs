using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CanvasGroup))]
public class Alpha :Tween<float>{
    protected override void UpdateProperty(float progress)
    {
        this.GetComponent<CanvasGroup>().alpha = Mathf.Lerp(from, to, progress);
    }
}
