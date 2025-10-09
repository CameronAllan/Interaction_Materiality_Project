using System;
using System.Collections;
using UnityEngine;

public abstract class InteractionChain : MonoBehaviour
{
    protected Coroutine _playRoutine;

    public virtual void Play()
    {
        if (_playRoutine != null)
            Stop();

        _playRoutine = StartCoroutine(PlayCoroutine());
    }

    public virtual void Stop()
    {
        StopCoroutine(_playRoutine);

        _playRoutine = null;
    }

    protected abstract IEnumerator PlayCoroutine();


    public abstract void AddEffect();

    public abstract void RemoveEffect();
}
