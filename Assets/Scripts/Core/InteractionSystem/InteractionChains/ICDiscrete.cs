using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ICDiscrete : InteractionChain
{
    //This baby has a list of discrete interaction slots that all line up

    [SerializeField] private List<EffectSlot> _slots;
    [SerializeField] private List<string> _slotsNames;

    protected override IEnumerator PlayCoroutine()
    {
        foreach(EffectSlot s in _slots)
        {
            s.CurrentEffect.Play();

            //yield return new WaitForSeconds(s.CurrentEffect.CurrentTime);
        }


        yield break;
    }


    public override void AddEffect()
    {
        throw new NotImplementedException();
    }

    public override void RemoveEffect()
    {
        throw new NotImplementedException();
    }

}
