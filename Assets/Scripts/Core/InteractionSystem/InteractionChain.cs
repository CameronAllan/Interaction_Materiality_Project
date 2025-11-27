using System.Collections.Generic;
using System;
using System.Collections;
using UnityEngine;

public abstract class InteractionChain : MonoBehaviour
{
    public InteractionManager.InteractionTypes interactionType;
    protected Coroutine _playRoutine;

    [SerializeField] protected List<EffectSlot> _slots;
    [SerializeField] protected EffectSlot _effectSlotPrefab;

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

    public abstract void AddEffectSlot();

    public abstract void RemoveEffect();

    public EffectSlot TryGetSlotAtIndex(int index)
    {
        if(index < _slots.Count)
        {
            return _slots[index];
        } else
        {
            return null;
        }
    }

    public List<EffectSlot> GetSlots()
    {
        return _slots;
    }

    public int GetSlotCount()
    {
        return _slots.Count;
    }

    public abstract List<string> GetSlotNames();

}
