using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

abstract public class TweenBase : MonoBehaviour
{
    public virtual  void ResetToBeginning()
    {

    }
}
abstract public class Tween<T> : TweenBase
{
    [SerializeField]
    protected T from;
    [SerializeField]
    protected T to;
    [SerializeField]
    protected float duration = 1.0f;
    [SerializeField]
    protected bool loop = false;
    [SerializeField]
    protected bool reset = true;
    protected float timer = 0.0f;


    private void OnEnable()
    {
        if(reset)
        {
            timer = 0.0f;
        }
    }

    [ContextMenu("Execute")]
    public void Excute()
    {
        timer = 0.0f;
    }

    private void Update()
    {
        if (timer < duration)
        {
            timer += Time.deltaTime;

            UpdateProperty(timer / duration);

            if (timer >= duration && loop)
            {
                timer = 0.0f;
            }
        }
    }

    protected virtual void UpdateProperty(float progress)
    {

    }
    public override void ResetToBeginning()
    {
        UpdateProperty(0.0f);
    }
}
