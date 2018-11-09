using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


abstract public class TweenBase : MonoBehaviour
{
    public virtual void RegisterActionOnComplete(System.Action callback)
    {

    }

    public virtual void Play()
    {

    }

    public virtual void ResetToBeginning()
    {

    }

    public virtual void ResetToEnd()
    {

    }
}

// Generic T type for different variable types
abstract public class Tween<T> : TweenBase
{
    [SerializeField]
    protected T from = default(T);
    [SerializeField]
    protected T to = default(T);
    [SerializeField]
    protected float duration = 1.0f;
    [SerializeField]
    protected bool loop = false;
    [SerializeField]
    protected bool resetOnEnable = true;

    protected float scaler = 0.0f;

    protected float timer = 0.0f;

    protected System.Action onTweenComplete = null;

    // Register callbacks to listen for when tween is completed
    public override void RegisterActionOnComplete(System.Action callback)
    {
        onTweenComplete += callback;
    }

    private void OnEnable()
    {
        if (resetOnEnable)
        {
            timer = 0.0f;
        }
    }

    [ContextMenu("Execute")]
    private void Execute()
    {
        timer = 0.0f;
    }

    // Reset timer to 0.0 to play
    public override void Play()
    {
        timer = 0.0f;
    }

    private void Update()
    {
        // Update while timer is less than total duration
        if (timer < duration)
        {
            // Add in time 
            timer += Time.deltaTime;

            // 0.0f = Progress goes from 0 to 1
            // 1.0f = Progress goes from  1 - ( 0 to 1 );
            UpdateProperty(Mathf.Abs(scaler - (timer / duration)));

            if (timer >= duration)
            {
                if(onTweenComplete != null)
                {
                    onTweenComplete.Invoke();
                    onTweenComplete = null;
                }
               
                if (loop)
                {
                    timer = 0.0f;
                }
            }
        }
    }

    protected virtual void UpdateProperty(float progress)// Progress between 0 and 1f
    {

    }

    // Set scaler to 0 to play forward
    // Update property to 0 progress to intial values
    public override void ResetToBeginning()
    {
        scaler = 0.0f;
        UpdateProperty(0.0f);

    }

    // Set scaler to 1 to play backwards
    // Update property to 1 progress as initial values
    public override void ResetToEnd()
    {
        scaler = 1.0f;
        UpdateProperty(1.0f);

    }
}